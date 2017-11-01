import * as React from "react";
import { SvarIProps } from "../interfaces/PropsInterface";
import { SvarI } from "../interfaces/ModelInterface";

export default class Svar extends React.Component<SvarIProps, {}> {

    constructor() {
        super();
    }

    public render() {
        if (this.props.Svar) {
            return <div>
                <p>Besvar av {this.props.Svar.BesvartAv}, klokken {this.props.Svar.Besvart.toDateString()}</p>
                <p>{this.props.Svar}</p>
            </div>;
        }
        return <div>
            <p>Dette spørsmålet mangler svar</p>
        </div>;
    }


}