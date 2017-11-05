import * as React from "react";
import { RouteComponentProps } from 'react-router';

interface SkjemaState {
    fornavn: string;
    etternavn: string;
    epost: string;
    telefon: string;
    sporsmal: string;
    validForm: boolean;
}


export default class Skjema extends React.Component<RouteComponentProps<{}>, SkjemaState> {

    constructor(props: any) {
        super(props);
        this.state = {
            fornavn:"",
            etternavn:"",
            epost:"",
            telefon: "",
            sporsmal: "",
            validForm: false
        };

        this.validerNavn = this.validerNavn.bind(this);
        this.validerEpost = this.validerEpost.bind(this);
        this.validerTel = this.validerTel.bind(this);
        this.validerSporsmal = this.validerSporsmal.bind(this);
        this.submitSkjema = this.submitSkjema.bind(this);

    }

    public render() {
        return <form onSubmit={this.submitSkjema}>
            <div className="form-group">
                <label htmlFor="fornavn">Fornavn</label>
                <input type="text" name="fornavn" id="fornavn" className="form-control" value={this.state.fornavn}
                    required autoComplete="given-name additional-name" onChange={this.validerNavn} />
            </div>
            <div className="form-group">
                <label htmlFor="etternavn">Etternavn</label>
                <input type="text" name="etternavn" id="etternavn" className="form-control" value={this.state.etternavn}
                    required autoComplete="family-name" onChange={this.validerNavn} />
            </div>
            <div className="form-group">
                <label htmlFor="epost">E-post</label>
                <input type="email" name="epost" id="epost" className="form-control" value={this.state.epost}
                    required autoComplete="email" onChange={this.validerEpost} />
            </div>
            <div className="form-group">
                <label htmlFor="telefon">Telefon</label>
                <input type="tel" name="telefon" id="telefon" className="form-control" value={this.state.telefon}
                    required autoComplete="tel" onChange={this.validerTel} />
            </div>
            <div className="form-group">
                <label htmlFor="sporsmal">Spørsmål</label>
                <input type="text" name="sporsmal" id="sporsmal" className="form-control" value={this.state.sporsmal}
                    required onChange={this.validerSporsmal} />
            </div >
            <button type="submit" className="btn btn-primary">Send inn</button>
        </form>;
    }

    private validerNavn(event: React.ChangeEvent<HTMLInputElement>) {
        if (event.currentTarget.name == "fornavn") {
            this.setState({ fornavn: event.currentTarget.value.toUpperCase() });
        } else if (event.currentTarget.name == "etternavn") {
            this.setState({ etternavn: event.currentTarget.value.toUpperCase() });
        }
    }

    private validerEpost(event: React.ChangeEvent<HTMLInputElement>) {

    }

    private validerTel(event: React.ChangeEvent<HTMLInputElement>) {

    }

    private validerSporsmal(event: React.ChangeEvent<HTMLInputElement>) {

    }

    private submitSkjema(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        console.log(event.currentTarget);
    }
}