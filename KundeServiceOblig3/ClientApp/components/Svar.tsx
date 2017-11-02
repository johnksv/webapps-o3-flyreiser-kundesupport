import * as React from "react";
import { SvarIProps } from "../interfaces/PropsInterface";
import { SvarI } from "../interfaces/ModelInterface";

export default class Svar extends React.Component<SvarIProps, {}> {
    public render() {
        if (this.props.svar) {
            const date = new Date(this.props.svar.besvart);

            return <div className="svar">
                <p>Besvar av , {date.toLocaleDateString()}</p>
                <p>{this.props.svar.svar}</p>
            </div>;
        }
        return <div className="svar">
            <p>Dette spørsmålet mangler svar</p>
        </div>;
    }


}