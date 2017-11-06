import * as React from "react";
import { RouteComponentProps } from 'react-router';
import { SkjemaStateI } from "../interfaces/ModelInterface";
import { InputI } from "../interfaces/PropsInterface";
import Input from "./Input";

export default class Skjema extends React.Component<RouteComponentProps<{}>, SkjemaStateI> {

    constructor(props: any) {
        super(props);
        this.state = {
            validForm: false
        };

        this.submitSkjema = this.submitSkjema.bind(this);

    }

    public render() {
        return <form onSubmit={this.submitSkjema}>

            <Input validering={true} navn="Fornavn" feilmelding="Fornavn kan kun være bokstaver (A-Å)." regex="^[A-Za-zæøåÆØÅ\\- ]{2,}$"/>

            <Input validering={true} navn="Etternavn" feilmelding="Etternavn kan kun være bokstaver (A-Å)." regex="^[A-Za-zæøåÆØÅ\\- ]{2,}$" />

            <Input validering={true} navn="Epost" feilmelding="Ugyldig format på e-postadressen." regex="^[A-Za-zæøåÆØÅ0-9_\\-,\\.+ ]+@[a-zA-Z0-9]+\\.[a-zA-Z]+$" />

            <Input validering={true} navn="Telefon" feilmelding="Telefonnummer må bestå av 8 tall, og ikke starte på 0." regex="^[1-9][0-9]{7}$" />

            <Input validering={true} navn="Sporsmal" feilmelding="Spørsmål inneholder ugyldig tegn." regex="^[A-Za-zæøåÆØÅ\\- ]+$" regexFlags="m" />
            
            <button type="submit" className="btn btn-primary">Send inn</button>
        </form>;
    }

    private submitSkjema(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        console.log(event.currentTarget);
    }
}