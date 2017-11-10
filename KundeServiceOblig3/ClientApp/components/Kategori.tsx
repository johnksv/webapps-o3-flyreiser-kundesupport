import * as React from "react";
import { KategoriIProps } from "../interfaces/PropsInterface";
import { KategoriI, SporsmalOgSvarI } from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

export default class Kategori extends React.Component<KategoriIProps, {}> {

    constructor(props: any) {
        super(props);
        this.state = {
            kategorier: [],
            laster: true
        };

        this.renderSporsmal = this.renderSporsmal.bind(this);
    }


    public render() {
        let antall;
        if (!this.props.ossModus) {
            antall = "(" + this.props.kategori.sporsmalOgSvar.length + " spørsmål)";
        }
        return <div className="panel-group">
            <div className="panel panel-default">
                <div className="panel-heading kategori" data-toggle="collapse" data-target={"#collapse" + this.props.index}>
                    <h4 className="panel-title">
                        {this.props.kategori.navn} {antall}
                    </h4>
                </div>
                <div id={"collapse" + this.props.index} className="panel-collapse collapse">
                    <div className="panel-body">
                        {this.renderSporsmal(this.props.kategori.sporsmalOgSvar)}
                    </div>
                </div>
            </div>
        </div>;
    }

    private renderSporsmal(sporsmalOgSvar: SporsmalOgSvarI[]): any {
        return sporsmalOgSvar.map(sporOgSvar => <SporsmalOgSvar key={sporOgSvar.id} sporsmalOgSvar={sporOgSvar} ossModus={this.props.ossModus} />)
    }
}