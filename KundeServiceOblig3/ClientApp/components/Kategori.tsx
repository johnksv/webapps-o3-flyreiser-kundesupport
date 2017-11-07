import * as React from "react";
import 'isomorphic-fetch';
import { RouteComponentProps } from 'react-router';
import { KategoriI, SporsmalOgSvarI } from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

interface StateInterface {
    kategorier: KategoriI[];
    laster: boolean;
}

export default class Kategori extends React.Component<RouteComponentProps<{}>, StateInterface> {

    constructor(props: any) {
        super(props);
        this.state = {
            kategorier: [],
            laster: true
        };

        this.renderSporsmal = this.renderSporsmal.bind(this);
    }

    componentDidMount() {
        this.hentAlleSporsmalOgSvar();
    }

    public render() {
        if (this.state.laster) {
            return <p>Laster</p>
        }

        if (this.state.kategorier.length == 0) {
            //Antar at det alltid skal finnes minst 1 spørsmål i databasen
            return <p>En feil oppsto under henting av spørsmål. Vennligst prøv igjen senere.</p>
        }

        return <div className="sporsmalContainer">
            <h1>Ofte stilte spørsmål</h1>
            <p>Spørsmålene er delt inn i kategorier slik at du enkelt kan finne frem til hva du lurer på.</p>
            {this.state.kategorier.map((kategori, i) =>
                this.renderKategori(kategori, i)
            )}
        </div>;
    }

    private renderKategori(kategori: KategoriI, index: number): any {
        return <div className="panel-group" key={kategori.navn} >
            <div className="panel panel-default">
                <div className="panel-heading kategori" data-toggle="collapse" data-target={"#collapse" + index}>
                    <h4 className="panel-title">
                        {kategori.navn}
                    </h4>
                </div>
                <div id={"collapse" + index} className="panel-collapse collapse">
                    <div className="panel-body">
                        {this.renderSporsmal(kategori.sporsmalOgSvar)}
                    </div>
                </div>
            </div>
        </div>
    }

    private renderSporsmal(sporsmalOgSvar: SporsmalOgSvarI[]): any {
        return sporsmalOgSvar.map(sporOgSvar => <SporsmalOgSvar key={sporOgSvar.id} sporsmalOgSvar={sporOgSvar} />)
    }


    private hentAlleSporsmalOgSvar(): void {
        fetch("api/sporsmalogsvar/")
            .then(response => {
                if (response.status >= 200 && response.status < 300) {
                    return response.json() as Promise<KategoriI[]>;
                } else {
                    return Promise.reject(new Error(response.statusText))
                }
            })
            .then(json => {
                this.setState({
                    kategorier: json,
                    laster: false
                });
            })
            .catch(error => {
                this.setState({ laster: false });
                console.log("En feil oppsto med kommunikasjon til serveren: " + error)
            });
    }
}