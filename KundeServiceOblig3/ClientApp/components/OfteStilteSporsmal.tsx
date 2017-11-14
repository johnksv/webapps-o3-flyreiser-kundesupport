import * as React from "react";
import "isomorphic-fetch";
import { RouteComponentProps } from "react-router";
import { KategoriI, SporsmalOgSvarI } from "../interfaces/ModelInterface";
import Kategori from "./Kategori";

interface StateInterface {
    kategorier: KategoriI[];
    kategorierFilter: KategoriI[];
    laster: boolean;
    sokVerdi: string;
}

export default class OfteStilteSporsmal extends React.Component<RouteComponentProps<{}>, StateInterface> {

    constructor(props: any) {
        super(props);
        this.state = {
            kategorier: [],
            kategorierFilter: [],
            laster: true,
            sokVerdi: ""
        };

        this.sokEndre = this.sokEndre.bind(this);
        this.filterSporsmalList = this.filterSporsmalList.bind(this);
    }

    componentDidMount() {
        this.hentAlleKategorierMedSvar();
    }

    public render() {
        let lastemelding;
        let sokfelt;
        if (this.state.laster) {
            lastemelding = <p>Laster</p>;
        } else if (this.state.kategorier.length == 0) {
            //Antar at det alltid skal finnes minst 1 spørsmål i databasen
            lastemelding = <p className="text-danger">En feil oppsto under henting av spørsmål. Vennligst prøv igjen senere. (Se konsollen for feilmelding)</p>;
        } else {
            sokfelt = <input type="text" className="form-control" placeholder="Søk etter spørsmål" onChange={this.sokEndre} defaultValue={this.state.sokVerdi} />;
        }

        return <div className="sporsmalContainer">
            <h1>Ofte stilte spørsmål</h1>
            <p>Spørsmålene er delt inn i kategorier slik at du enkelt kan finne frem til hva du lurer på.</p>
            <p>Trykk på kategorien for å utvide eller kollapse den.</p>
            <hr/>
            {lastemelding}

            {sokfelt}
            <br/>
            {this.state.kategorierFilter.map((kategori, i) => <Kategori kategori={kategori} index={i} ossModus={true} key={kategori.navn + kategori.sporsmalOgSvar.length} />)}
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
                json.sort((s1, s2) => {
                    if (s1.navn.toLowerCase() == "generelt") return -1;
                    if (s2.navn.toLowerCase() == "generelt") return 1;
                    return 0;
                });

                this.setState({
                    kategorier: json,
                    kategorierFilter: json,
                    laster: false
                });
            })
            .catch(error => {
                this.setState({ laster: false });
                console.log("En feil oppsto med: " + error)
            });
    }

    private sokEndre(event: React.ChangeEvent<HTMLInputElement>) {
        const nyVerdi = event.currentTarget.value;
        const filtrertListe: KategoriI[] = this.state.kategorier.map(kat => {
            let navn = kat.navn;
            let sporsmal = this.filterSporsmalList(kat.sporsmalOgSvar, nyVerdi)
            return { navn: navn, sporsmalOgSvar: sporsmal } as KategoriI;
        });

        this.setState({
            sokVerdi: nyVerdi,
            kategorierFilter: filtrertListe
        });
    }

    private filterSporsmalList(liste: SporsmalOgSvarI[], verdi: string): SporsmalOgSvarI[] {
        const sokverdi = verdi.toLowerCase();

        const nyListe = liste.filter((sporsmalOgSvar) => {
            const sporsmal = sporsmalOgSvar.sporsmal.sporsmal.toLowerCase();

            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/search
            return sporsmal.search(sokverdi) != -1;
        });

        return nyListe;
    }

}