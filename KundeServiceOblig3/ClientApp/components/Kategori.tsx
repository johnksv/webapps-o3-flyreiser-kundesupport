import * as React from "react";
import { KategoriIProps } from "../interfaces/PropsInterface";
import { KategoriI, SporsmalOgSvarI } from "../interfaces/ModelInterface";
import SporsmalOgSvar from "./SporsmalOgSvar";

export default class Kategori extends React.Component<KategoriIProps, KategoriI> {

    constructor(props: any) {
        super(props);

        let sos = this.props.kategori.sporsmalOgSvar;
        if (this.props.ossModus) {
            sos = this.props.kategori.sporsmalOgSvar.filter(s => s.publisert);
        }

        this.state = {
            navn: this.props.kategori.navn,
            sporsmalOgSvar: sos
        };

        this.renderSporsmal = this.renderSporsmal.bind(this);
        this.onDeleteSporsmal = this.onDeleteSporsmal.bind(this);
        this.antallUbsvarteSporsmal = this.antallUbsvarteSporsmal.bind(this);
        
    }

    public render() {
        if (this.state.sporsmalOgSvar.length == 0) return <div> </div>;

        let antall = this.state.sporsmalOgSvar.length + " spørsmål";
        let ubesvart;
        let cssKlasser = {
            className: "panel-collapse collapse "
        };
        if (!this.props.ossModus) {
            const antall = this.antallUbsvarteSporsmal();
            const ending = this.antallUbsvarteSporsmal() == 1 ? " ubsvart" : " ubesvarte";
            ubesvart = ", " + antall + ending;
        }

        return <div className="panel-group">
            <div className="panel panel-default">
                <div className="panel-heading kategori" data-toggle="collapse" data-target={"#collapse" + this.props.index}>
                    <h4 className="panel-title">
                        {this.state.navn} <small> - {antall} {ubesvart} </small>
                    </h4>
                </div>
                <div id={"collapse" + this.props.index} {...cssKlasser}>
                    <div className="panel-body">
                        {this.renderSporsmal(this.state.sporsmalOgSvar)}
                    </div>
                </div>
            </div>
        </div>;
    }

    private renderSporsmal(sporsmalOgSvar: SporsmalOgSvarI[]): any {
        return sporsmalOgSvar.map(sporOgSvar => <SporsmalOgSvar key={sporOgSvar.id} sporsmalOgSvar={sporOgSvar} ossModus={this.props.ossModus} onDelete={this.onDeleteSporsmal} redigeringsModus={this.props.redigeringsModus} />)
    }


    private onDeleteSporsmal(id: number) {
        const sporsmal = this.state.sporsmalOgSvar.filter(s => s.id != id);
        this.setState({
            sporsmalOgSvar: sporsmal,
        });
    }

    private antallUbsvarteSporsmal() {
        return this.state.sporsmalOgSvar.filter(sos => sos.svar == undefined).length;
    }
}