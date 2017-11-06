import * as React from "react";
import { RouteComponentProps } from 'react-router';

interface SkjemaState {
    fornavn: string;
    etternavn: string;
    epost: string;
    telefon: string;
    sporsmal: string;
    validForm: boolean;
    validFornavn: boolean;
    validEtternavn: boolean;
    validEpost: boolean;
    validTlf: boolean;
    validSporsmal: boolean;
}


export default class Skjema extends React.Component<RouteComponentProps<{}>, SkjemaState> {

    constructor(props: any) {
        super(props);
        this.state = {
            fornavn: "",
            etternavn: "",
            epost: "",
            telefon: "",
            sporsmal: "",
            validForm: false,
            validFornavn: true,
            validEtternavn: true,
            validEpost: true,
            validTlf: true,
            validSporsmal: true
        };

        this.genererFeilmeldingClassName = this.genererFeilmeldingClassName.bind(this);
        this.genererClassNameInputGroup = this.genererClassNameInputGroup.bind(this);
        this.validerNavn = this.validerNavn.bind(this);
        this.validerEpost = this.validerEpost.bind(this);
        this.validerTel = this.validerTel.bind(this);
        this.validerSporsmal = this.validerSporsmal.bind(this);
        this.submitSkjema = this.submitSkjema.bind(this);

    }

    public render() {
        return <form onSubmit={this.submitSkjema}>
            <div className={this.genererClassNameInputGroup("Fornavn")}>
                <label htmlFor="Fornavn">Fornavn</label>
                <input type="text" name="Fornavn" id="Fornavn" className="form-control" value={this.state.fornavn}
                    required autoComplete="given-name additional-name" onChange={this.validerNavn} />
                <span className={this.genererSpanClassNameForInput("Fornavn")} aria-hidden="true"></span>
                <span className={this.genererFeilmeldingClassName("Fornavn")}>Fornavn kan kun være bokstaver (A-Å).</span>

            </div>
            <div className={this.genererClassNameInputGroup("Etternavn")}>
                <label htmlFor="Etternavn">Etternavn</label>
                <input type="text" name="Etternavn" id="Etternavn" className="form-control" value={this.state.etternavn}
                    required autoComplete="family-name" onChange={this.validerNavn} />
                <span className={this.genererSpanClassNameForInput("Etternavn")} aria-hidden="true"></span>
                <span className={this.genererFeilmeldingClassName("Etternavn")}>Etternavn kan kun være bokstaver (A-Å).</span>

            </div>
            <div className={this.genererClassNameInputGroup("Epost")}>
                <label htmlFor="Epost">E-post</label>
                <input type="email" name="Epost" id="Epost" className="form-control" value={this.state.epost}
                    required autoComplete="email" onChange={this.validerEpost} />
                <span className={this.genererSpanClassNameForInput("Epost")} aria-hidden="true"></span>

                <span className={this.genererFeilmeldingClassName("Epost")}>Ugyldig format på e-postadressen.</span>

            </div>
            <div className={this.genererClassNameInputGroup("Tlf")}>
                <label htmlFor="Telefon">Telefon</label>
                <input type="tel" name="Telefon" id="Telefon" className="form-control" value={this.state.telefon}
                    required autoComplete="tel" onChange={this.validerTel} />
                <span className={this.genererSpanClassNameForInput("Tlf")} aria-hidden="true"></span>

                <span className={this.genererFeilmeldingClassName("Tlf")}>Telefonnummer må bestå av 8 tall, og ikke starte på 0.</span>


            </div>
            <div className="form-group">
                <label htmlFor="Sporsmal">Spørsmål</label>
                <input type="text" name="Sporsmal" id="Sporsmal" className="form-control" value={this.state.sporsmal}
                    required onChange={this.validerSporsmal} />

            </div >
            <button type="submit" className="btn btn-primary">Send inn</button>
        </form>;
    }

    private genererClassNameInputGroup(felt: string): string {
        const feltNavn = "valid" + felt;
        const { [feltNavn]: erValid } = this.state;

        let resultat = "form-group has-feedback ";
        if (erValid) {
            return resultat + "has-success";
        }

        return resultat + "has-warning";
    }

    private genererSpanClassNameForInput(felt: string): string {
        const feltNavn = "valid" + felt;
        const { [feltNavn]: erValid } = this.state;

        let resultat = "glyphicon form-control-feedback ";
        if (erValid) {
            return resultat + "glyphicon-ok";
        }

        return resultat + "glyphicon-remove";
    }

    private genererFeilmeldingClassName(felt: string): string {
        const feltNavn = "valid" + felt;
        const { [feltNavn]: erValid } = this.state;

        let resultat = "text-danger field-validation-error ";
        if (erValid) {
            resultat += "hidden";
        }

        return resultat;
    }

    private validerNavn(event: React.ChangeEvent<HTMLInputElement>) {
        const value = event.currentTarget.value;
        const regex = new RegExp("^[A-Za-zæøåÆØÅ\\- ]{2,}$");
        const resultat = regex.test(value);

        if (event.currentTarget.name == "Fornavn") {
            this.setState({
                fornavn: event.currentTarget.value,
                validFornavn: resultat
            });
        } else if (event.currentTarget.name == "Etternavn") {
            this.setState({
                etternavn: event.currentTarget.value,
                validEtternavn: resultat
            });
        }
    }

    private validerEpost(event: React.ChangeEvent<HTMLInputElement>) {
        const value = event.currentTarget.value;
        const regex = new RegExp("^[A-Za-zæøåÆØÅ\\- ]{2,}$");
        const resultat = regex.test(value);

        this.setState({
            epost: event.currentTarget.value,
            validEpost: resultat
        });
    }

    private validerTel(event: React.ChangeEvent<HTMLInputElement>) {
        const value = event.currentTarget.value;
        const regex = new RegExp("^[1-9][0-9]{7}$");
        const resultat = regex.test(value);

        this.setState({
            telefon: event.currentTarget.value,
            validTlf: resultat
        });
    }

    private validerSporsmal(event: React.ChangeEvent<HTMLInputElement>) {
        const value = event.currentTarget.value;
        const regex = new RegExp("^[A-Za-zæøåÆØÅ\\-,.\"!? ]{2,}$", "m");
        const resultat = regex.test(value);

        this.setState({
            sporsmal: event.currentTarget.value,
            validSporsmal: resultat
        });
    }

    private submitSkjema(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        console.log(event.currentTarget);
    }
}