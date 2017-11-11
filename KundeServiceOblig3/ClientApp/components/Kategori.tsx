﻿import * as React from "react";
import { KategoriIProps } from "../interfaces/PropsInterface";
import { KategoriI, SporsmalOgSvarI } from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

export default class Kategori extends React.Component<KategoriIProps, KategoriI> {

    constructor(props: any) {
        super(props);
        this.state = {
            navn: this.props.kategori.navn,
            sporsmalOgSvar: this.props.kategori.sporsmalOgSvar,
            laster: true
        };

        this.renderSporsmal = this.renderSporsmal.bind(this);
        this.onDeleteSporsmal = this.onDeleteSporsmal.bind(this);
    }


    public render() {
        if (this.state.sporsmalOgSvar.length == 0) return <div> </div>;

        let antall;
        if (!this.props.ossModus) {
            antall = "(" + this.state.sporsmalOgSvar.length + " spørsmål)";
        }
        return <div className="panel-group">
            <div className="panel panel-default">
                <div className="panel-heading kategori" data-toggle="collapse" data-target={"#collapse" + this.props.index}>
                    <h4 className="panel-title">
                        {this.state.navn} {antall}
                    </h4>
                </div>
                <div id={"collapse" + this.props.index} className="panel-collapse collapse">
                    <div className="panel-body">
                        {this.renderSporsmal(this.state.sporsmalOgSvar)}
                    </div>
                </div>
            </div>
        </div>;
    }

    private renderSporsmal(sporsmalOgSvar: SporsmalOgSvarI[]): any {
        return sporsmalOgSvar.map(sporOgSvar => <SporsmalOgSvar key={sporOgSvar.id} sporsmalOgSvar={sporOgSvar} ossModus={this.props.ossModus} onDelete={this.onDeleteSporsmal} />)
    }


    private onDeleteSporsmal(id: number) {
        var sporsmal = this.state.sporsmalOgSvar.filter(s => s.id != id);
        this.setState({
            sporsmalOgSvar: sporsmal
        });
    }

}