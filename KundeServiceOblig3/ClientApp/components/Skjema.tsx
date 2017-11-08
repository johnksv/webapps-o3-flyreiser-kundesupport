import * as React from "react";
import 'isomorphic-fetch';
import { SkjemaStateI } from "../interfaces/ModelInterface";
import { SkjemaIProps, InputI } from "../interfaces/PropsInterface";
import Input from "./Input";

export default class Skjema extends React.Component<SkjemaIProps, SkjemaStateI> {

    constructor(props: any) {
        super(props);
        this.state = {
            validForm: true
        };

        this.submitSkjema = this.submitSkjema.bind(this);
        this.settValid = this.settValid.bind(this);
    }

    settValid(feltNavn: string, valid: boolean, verdi: string) {
        this.setState({
            ["valid" + feltNavn]: valid,
            [feltNavn]: verdi
        });
    }

    public render() {
        let feilmelding: JSX.Element | undefined;
        if (!this.state.validForm) {
            feilmelding = <span className="text-danger field-validation-error ">Et eller flere felter inneholder ugyldig verdi. Rett dette før du kan sende inn spørsmål.</span>;
        }

        return <form onSubmit={this.submitSkjema}>

            <Input navn="Fornavn" feilmelding="Fornavn kan kun være bokstaver (A-Å)." regex="^[A-Za-zæøåÆØÅ\\- ]{2,}$" settValid={this.settValid} />

            <Input navn="Etternavn" feilmelding="Etternavn kan kun være bokstaver (A-Å)." regex="^[A-Za-zæøåÆØÅ\\- ]{2,}$" settValid={this.settValid} />

            <Input navn="Epost" feilmelding="Ugyldig format på e-postadressen." regex="^[A-Za-zæøåÆØÅ0-9_\\-,\\.+ ]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$" settValid={this.settValid} />

            <Input navn="Telefon" feilmelding="Telefonnummer må bestå av 8 tall, og ikke starte på 0." regex="^[1-9][0-9]{7}$" settValid={this.settValid} />

            <Input navn="Sporsmal" tittel="Spørsmål" feilmelding="Spørsmål inneholder ugyldig tegn." regex="^[0-9A-Za-zæøåÆØÅ\\-?!., ]+$" regexFlags="m" settValid={this.settValid} disableAutocomplete={true} />

            {feilmelding}

            <br />
            <button type="submit" className="btn btn-primary">Send inn</button>

        </form>;
    }

    private submitSkjema(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const inputfelter = ["Fornavn", "Etternavn", "Epost", "Telefon", "Sporsmal"];

        const gyldigeFelter = inputfelter.map(element => {
            const { ["valid" + element]: valid } = this.state;
            return valid;
        });

        const antallUgyldige = gyldigeFelter.filter(gyldig => !gyldig).length;
        if (antallUgyldige != 0) {
            console.log("Form er ikke gyldig " + antallUgyldige);
            this.setState({ validForm: false });
            return;
        }
        this.setState({ validForm: true });

        const skjemadata = {
            Fornavn: this.state.Fornavn,
            Etternavn: this.state.Etternavn,
            Epost: this.state.Epost,
            Telefon: this.state.Telefon,
            Sporsmal: this.state.Sporsmal
        };

        const json = JSON.stringify(skjemadata);
        fetch("api/SporsmalOgSvar/", {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: json
        }).then(res => {
            if (res.status >= 200 && res.status < 300) {
                this.props.onSubmit(true);
            } else {
                console.log(`Feilmelding: ${res.statusText}`);
                this.props.onSubmit(false);
            }
        });
    }
}