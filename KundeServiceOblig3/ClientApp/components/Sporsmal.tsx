import * as React from "react";
import { SporsmalIProps } from "../interfaces/PropsInterface";
import { SporsmalI } from "../interfaces/ModelInterface";

export default class Sporsmal extends React.Component<SporsmalIProps, SporsmalI> {

    public render() {
        let date = new Date(this.props.sporsmal.stilt);
        
        if (this.props.ossModus) {
            return <h5>{this.props.sporsmal.sporsmal}</h5>;
        }

        return <h5>{this.props.sporsmal.sporsmal} <small>- Stilt den {date.toLocaleDateString()}</small></h5>;
    }
}