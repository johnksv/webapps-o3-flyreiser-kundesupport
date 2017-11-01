import * as React from "react";
import { SporsmalIProps } from "../interfaces/PropsInterface";
import { SporsmalI } from "../interfaces/ModelInterface";

export default class Sporsmal extends React.Component<SporsmalIProps, {}> {

    public render() {
        return <div>
            <p>{this.props.Sporsmal.Sporsmal}</p>
            <span>{this.props.Sporsmal.Stilt.toDateString()}</span>
        </div>;
    }
}