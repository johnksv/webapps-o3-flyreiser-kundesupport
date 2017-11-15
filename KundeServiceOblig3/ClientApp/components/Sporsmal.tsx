import * as React from "react";
import { SporsmalIProps } from "../interfaces/PropsInterface";
import { SporsmalI } from "../interfaces/ModelInterface";

export default class Sporsmal extends React.Component<SporsmalIProps, SporsmalI> {

    public render() {
        let date = new Date(this.props.sporsmal.stilt);

        if (this.props.ossModus) {
            return <div> {this.props.sporsmal.sporsmal.split("\n").map(i => {
                return <div>{i}</div>;
            })}</div>;
        }


        return <div>
            <small>Stilt den {date.toLocaleDateString()}</small>
            {this.props.sporsmal.sporsmal.split("\n").map(i => {
                return <div>{i}</div>;
            })}
        </div>;
    }
}