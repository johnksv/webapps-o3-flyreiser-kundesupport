import * as React from "react";
import "isomorphic-fetch";
import { RouteComponentProps } from "react-router";
import { KategoriI} from "../interfaces/ModelInterface";
import Kategori from "./Kategori";

interface StateInterface {
    kategorier: KategoriI[];
    laster: boolean;
}

export default class OfteStilteSporsmal extends React.Component<RouteComponentProps<{}>, StateInterface> {

    constructor(props: any) {
        super(props);
        this.state = {
            kategorier: [],
            laster: true
        };
    }

    componentDidMount() {
        this.hentAlleKategorierMedSvar();
    }

    public render() {
        let lastemelding;
        if (this.state.laster) {
            lastemelding = <p>Laster</p>;
        }

        if (this.state.kategorier.length == 0 && lastemelding == undefined) {
            //Antar at det alltid skal finnes minst 1 spørsmål i databasen
            lastemelding = <p className="text-danger">En feil oppsto under henting av spørsmål. Vennligst prøv igjen senere. (Se konsollen for feilmelding)</p>;
        }

        return <div className="sporsmalContainer">
            <h1>Ofte stilte spørsmål</h1>
            <p>Spørsmålene er delt inn i kategorier slik at du enkelt kan finne frem til hva du lurer på.</p>
            {lastemelding}
            {this.state.kategorier.map((kategori, i) =>
                <Kategori kategori={kategori} index={i} ossModus={true} key={i} />
            )}
        </div>;
    }
    private hentAlleKategorierMedSvar(): void {
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
                console.log("En feil oppsto med: " + error)
            });
    }
}