import * as React from "react";
import "isomorphic-fetch";
import { RouteComponentProps } from "react-router";
import { KategoriI } from "../interfaces/ModelInterface";
import Kategori from "./Kategori";

interface StateInterface {
    kategorier: KategoriI[];
    laster: boolean;
}

export default class Brukersporsmaladministrering extends React.Component<RouteComponentProps<{}>, StateInterface>{

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
        return <div> 
            {this.state.kategorier.map((kategori, i) =>
                <Kategori kategori={kategori} index={i} ossModus={false} key={i} />
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