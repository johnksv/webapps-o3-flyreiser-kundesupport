import * as React from "react";
import { InputI } from "../interfaces/PropsInterface";

interface InputState {
    verdi: string;
    valid: boolean;
}


export default class Textarea extends React.Component<InputI, InputState> {
    constructor(props: any) {
        super(props);
        this.state = {
            valid: false,
            verdi: ""
        };


        this.genererFeilmeldingClassName = this.genererFeilmeldingClassName.bind(this);
        this.genererClassNameInputGroup = this.genererClassNameInputGroup.bind(this);
        this.validerInput = this.validerInput.bind(this);
    }

    public render() {
        const navn = this.props.navn;
        const id = this.props.id ? this.props.id : navn;
        const tittel = this.props.tittel ? this.props.tittel : navn;
        let htmlProps = {
            name: navn,
            id: id,
            autoComplete: "",
            required: true,
            value: this.state.verdi,
            onChange: this.validerInput
        };

        if (this.props.disableAutocomplete) {
            htmlProps.autoComplete = "off";
        }

        return <div className={this.genererClassNameInputGroup()}>
            <label htmlFor={navn}>{tittel}</label>

            <span className={this.genererFeilmeldingClassName()}>{"- " + this.props.feilmelding}</span>

            <textarea type="text" {...htmlProps} className="form-control"></textarea>
            <span className={this.genererSpanClassNameForInput()} aria-hidden="true"></span>

        </div>;
    }

    private genererClassNameInputGroup(): string {
        let resultat = "form-group ";

        resultat += "has-feedback ";
        resultat += this.state.valid ? "has-success" : "has-warning";
        return resultat;
    }

    private genererSpanClassNameForInput(): string {
        let resultat = "glyphicon form-control-feedback ";
        resultat += this.state.valid ? "glyphicon-ok" : "glyphicon-remove";
        return resultat;
    }

    private genererFeilmeldingClassName(): string {
        let resultat = "text-danger field-validation-error ";
        if (this.state.valid || this.state.verdi.length == 0) {
            resultat += "hidden";
        }
        return resultat;
    }

    private validerInput(event: React.ChangeEvent<HTMLTextAreaElement>) {
        let resultat = true;
        const value = event.currentTarget.value;

        if (this.props.regex) {
            let regex = new RegExp(this.props.regex);
            let values = value.split("\n");
            resultat = values.every(v => regex.test(v));
        }

        resultat = resultat && value.trim().length > 0;

        const verdi = event.currentTarget.value;
        this.setState({
            verdi: verdi,
            valid: resultat
        });
        this.props.settValid(this.props.navn, resultat, verdi);
    }

}