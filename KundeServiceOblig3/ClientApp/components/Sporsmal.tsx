import * as React from "react";
import { SporsmalIProps } from "../interfaces/PropsInterface";
import { SporsmalI } from "../interfaces/ModelInterface";

export default class Sporsmal extends React.Component<SporsmalIProps, SporsmalI> {

    public render() {
        let date = new Date(this.props.sporsmal.stilt);

        return <div className="sporsmal">
            <p>{this.props.sporsmal.sporsmal}</p>
            <span>{date.toLocaleDateString()}</span>
        </div>;
    }
}