import * as React from "react";
import { SporsmalIProps } from "../interfaces/PropsInterface";
import { SporsmalI } from "../interfaces/ModelInterface";

export default class Sporsmal extends React.Component<SporsmalIProps, SporsmalI> {

    componentWillReceiveProps(nextProps: SporsmalIProps) {
        if (nextProps && nextProps.Sporsmal) {

            this.setState({
                Sporsmal: nextProps.Sporsmal.Sporsmal,
                Stilt: nextProps.Sporsmal.Stilt
            });
        }
    }

    public render() {
      //  console.log(this.state);
        if (this.state && this.state.Sporsmal) {

            return <div>
                <p>{this.state.Sporsmal}</p>
                <span>{this.state.Stilt.toDateString()}</span>
            </div>;
        }
        return <p>sa</p>
    }
}