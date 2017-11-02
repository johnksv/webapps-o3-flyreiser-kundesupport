import * as React from "react";
import 'isomorphic-fetch';
import { RouteComponentProps } from 'react-router';
import { SporsmalOgSvarI, SporsmalI, SvarI } from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

interface StateInterface {
    sprosmal: SporsmalOgSvarI[];
    laster: boolean;
}

export default class SporsmalOgSvarContainer extends React.Component<RouteComponentProps<{}>, StateInterface> {

    constructor(props : any) {
        super(props);
        this.state= {
            sprosmal: [],
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

        if (this.state.sprosmal.length == 0) {
            return <p>Lengde er null</p>
        }

        return this.samlingAvAlleSporsmal();
    }

    private samlingAvAlleSporsmal(): any {
        return <div>
            <p>Sporsmal</p>
            {this.state.sprosmal.map((sporOgSvar, i) => {
                console.log(sporOgSvar.Sporsmal.Sporsmal);
                return <SporsmalOgSvar key={i} SporsmalOgSvar={sporOgSvar} />
            }
            )}
        </div>;
    }


    private hentAlleSporsmalOgSvar(): void {
        fetch("api/sporsmalogsvar/")
            .then(response => {
                if (response.status >= 200 && response.status < 300) {
                    return response.json() as Promise<SporsmalOgSvarI[]>;
                } else {
                    return Promise.reject(new Error(response.statusText))
                }
            })
            .then(json => {
                this.setState({
                    sprosmal: json,
                    laster: false
                });
                console.log("Oppdatert state: " + this.state.sprosmal);
            })
            .catch(error => {
                this.setState({ laster: false });
                console.log("En feil oppsto med kommunikasjon til serveren: " + error)
            });
    }
}