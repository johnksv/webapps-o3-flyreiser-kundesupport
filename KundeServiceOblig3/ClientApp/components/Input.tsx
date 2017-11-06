import * as React from "react";
import { InputI } from "../interfaces/PropsInterface";

interface InputState {
    verdi: any;
    valid: boolean;
}


export default class Input extends React.Component<InputI, InputState> {
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
        if (this.props.validering) {
            return <div className={this.genererClassNameInputGroup()}>
                <label htmlFor={navn}>{navn}</label>
                <input type="text" name={navn} id={id} className="form-control" value={this.state.verdi}
                    required onChange={this.validerInput} />
                <span className={this.genererSpanClassNameForInput()} aria-hidden="true"></span>
                <span className={this.genererFeilmeldingClassName()}>{this.props.feilmelding}</span>

            </div>;
        } else {
            return <div className={this.genererClassNameInputGroup()}>
                <label htmlFor={navn}>{navn}</label>
                <input type="text" name={navn} id={id} className="form-control" value={this.state.verdi} required onChange={this.validerInput} />
            </div>;
        }
    }

    private genererClassNameInputGroup(): string {
        let resultat = "form-group ";
        if (!this.props.validering) {
            return resultat;
        }

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
        if (this.state.valid) {
            resultat += "hidden";
        }
        return resultat;
    }

    private validerInput(event: React.ChangeEvent<HTMLInputElement>) {
        let resultat = true;

        if (this.props.regex) {
            const value = event.currentTarget.value;
            let regex;
            if (this.props.regexFlags) {
                regex = new RegExp(this.props.regex, this.props.regexFlags);
            } else {
                regex = new RegExp(this.props.regex);
            }
            resultat = regex.test(value);
        }

        this.setState({
            verdi: event.currentTarget.value,
            valid: resultat
        });
    }

}