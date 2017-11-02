import * as React from "react";
import 'isomorphic-fetch';
import { RouteComponentProps } from 'react-router';
import * as Model from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

interface StateInterface {
    sporOgSvar: Model.SporsmalOgSvarI[];
    laster: boolean;
}

export default class SporsmalOgSvarContainer extends React.Component<RouteComponentProps<{}>, StateInterface> {

    constructor(props : any) {
        super(props);
        this.state= {
            sporOgSvar: [],
            laster: true
        };
    }

    componentDidMount() {
        this.hentAlleSporsmalOgSvar();
    }

    public render() {
        if (this.state.laster) {
            return <p>Laster</p>
        }

        if (this.state.sporOgSvar.length == 0) {
            return <p>Lengde er null</p>
        }

        return <div className="sporsmalContainer">
            {this.state.sporOgSvar.map(sporOgSvar =>
                <SporsmalOgSvar key={sporOgSvar.id} sporsmalOgSvar={sporOgSvar} />
            )}
        </div>;
    }

    private hentAlleSporsmalOgSvar(): void {
        fetch("api/sporsmalogsvar/")
            .then(response => {
                if (response.status >= 200 && response.status < 300) {
                    return response.json() as Promise<Model.SporsmalOgSvarI[]>;
                } else {
                    return Promise.reject(new Error(response.statusText))
                }
            })
            .then(json => {
                this.setState({
                    sporOgSvar: json,
                    laster: false
                });
            })
            .catch(error => {
                this.setState({ laster: false });
                console.log("En feil oppsto med kommunikasjon til serveren: " + error)
            });
    }
}