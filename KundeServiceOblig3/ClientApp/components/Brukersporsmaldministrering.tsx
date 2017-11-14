import * as React from "react";
import "isomorphic-fetch";
import { RouteComponentProps } from "react-router";
import { KategoriI } from "../interfaces/ModelInterface";
import Kategori from "./Kategori";

interface BrukersporsmalI {
    kategorier: KategoriI[];
    laster: boolean;
}

export default class Brukersporsmaladministrering extends React.Component<RouteComponentProps<{}>, BrukersporsmalI>{

    constructor(props: any) {
        super(props);

        this.state = {
            kategorier: [],
            laster: true
        };

        this.hentAlleBrukerSporsmal = this.hentAlleBrukerSporsmal.bind(this);
    }

    componentDidMount() {
        this.hentAlleBrukerSporsmal();
    }

    public render() {
        let lastemelding;
        if (this.state.laster) {
            lastemelding = <p>Laster</p>;
        } else if (this.state.kategorier.length == 0) {
            //Antar at det alltid skal finnes minst 1 spørsmål i databasen
            lastemelding = <p className="text-danger">En feil oppsto under henting av spørsmål. Vennligst prøv igjen senere. (Se konsollen for feilmelding)</p>;
        }

        return <div>
            <h1>Spørsmåladministrering</h1>
            <p>Her kan du administrere spørsmål som allerede ligger inne i databasen. Ubesvarte brukerspørsmål kan besvares.</p>
            {lastemelding}
            {this.state.kategorier.map((kategori, i) =>
                <Kategori kategori={kategori} index={i} ossModus={false} key={i} redigeringsModus={true} />
            )}
        </div>
    }

    private hentAlleBrukerSporsmal() {
        fetch("api/sporsmalogsvar/")
            .then(response => {
                if (response.status >= 200 && response.status < 300) {
                    return response.json() as Promise<KategoriI[]>;
                } else {
                    return Promise.reject(new Error(response.statusText))
                }
            })
            .then(json => {
                json.sort((s1, s2) => {
                    if (s1.navn.toLowerCase() == "generelt") return -1;
                    if (s2.navn.toLowerCase() == "generelt") return 1;
                    return 0;
                });

                this.setState({
                    kategorier: json,
                    laster: false
                });
            })
            .catch(error => {
                this.setState({ laster: false });
                console.log("En feil oppsto med: " + error)
            });
    }

}