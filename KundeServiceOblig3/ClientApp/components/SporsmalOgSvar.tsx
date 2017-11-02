import * as React from "react";
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";
import Sporsmal from "./Sporsmal";
import Svar from "./Svar";
import { SporsmalOgSvarI, SporsmalI } from "ClientApp/interfaces/ModelInterface";


export default class SporsmalOgSvar extends React.Component<SporsmalOgSvarIProps, SporsmalOgSvarI> {

    constructor(props: SporsmalOgSvarIProps) {
        super(props);
        //console.log("construct " + props.SporsmalOgSvar.Svar);
        this.state = {
            id: props.SporsmalOgSvar.id,
            Sporsmal: props.SporsmalOgSvar.Sporsmal,
            Svar: props.SporsmalOgSvar.Svar,
            publisert: props.SporsmalOgSvar.publisert
        };


    }

    componentDidMount() {
      //  console.log("SporsmalOgSvarErMounted");
    }

    componentWillReceiveProps(nextProps: SporsmalOgSvarIProps) {
        console.log("Oppdatert props sporsmalOgSvar");
        if (nextProps && nextProps.SporsmalOgSvar) {

            this.setState({
                id: nextProps.SporsmalOgSvar.id,
                Sporsmal: nextProps.SporsmalOgSvar.Sporsmal,
                Svar: nextProps.SporsmalOgSvar.Svar,
                publisert: nextProps.SporsmalOgSvar.publisert
            });
        }
    }

    public render() {
        console.log("asd " + this.state)
        if (this.state && this.state.Sporsmal) {

        return <div>
            <p>Hello</p>
            <Sporsmal Sporsmal={this.state.Sporsmal} />
            
        </div>
        }
        return <div>
            <p>Ingen state</p>
        </div>

    }

}