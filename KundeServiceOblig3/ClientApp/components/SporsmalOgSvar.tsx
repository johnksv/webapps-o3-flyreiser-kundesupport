import * as React from "react";
import "isomorphic-fetch";
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";
import Sporsmal from "./Sporsmal";
import Svar from "./Svar";
import { SporsmalOgSvarI, SporsmalI, SvarI } from "ClientApp/interfaces/ModelInterface";

export default class SporsmalOgSvar extends React.Component<SporsmalOgSvarIProps, SporsmalOgSvarI> {

    constructor(props: any) {
        super(props)

        this.state = {
            sporsmal: this.props.sporsmalOgSvar.sporsmal,
            id: this.props.sporsmalOgSvar.id,
            svar: this.props.sporsmalOgSvar.svar,
            publisert: this.props.sporsmalOgSvar.publisert,
            kategori: this.props.sporsmalOgSvar.kategori,
            kunde: this.props.sporsmalOgSvar.kunde,
            requestTilbakemelding: undefined
        };

        this.endrePublisert = this.endrePublisert.bind(this);
        this.onEndreSvar = this.onEndreSvar.bind(this);
        this.lagreEndringer = this.lagreEndringer.bind(this);
        this.slettSporsmal = this.slettSporsmal.bind(this);
    }

    public render() {
        let redigeringModus;
        if (!this.props.ossModus) {
            let oppdatering;
            if (this.state.requestTilbakemelding != undefined) {
                oppdatering = <p>{this.state.requestTilbakemelding}</p>;
            }

            redigeringModus = <div className="panel-footer">
                <div className="checkbox">
                    <label>
                        <input type="checkbox" defaultChecked={this.state.publisert} onClick={this.endrePublisert} />
                        Publisert
                    </label>
                </div>
                <button className="btn btn-primary" onClick={this.lagreEndringer}>Lagre enringer</button>
                <button className="btn btn-danger marginVenstre" onClick={this.slettSporsmal}>Slett</button>
                {oppdatering}
            </div>;
        }

        return <div className="panel-group">
            <div className="panel panel-default">
                <div className="panel-heading">
                    <Sporsmal sporsmal={this.state.sporsmal} ossModus={this.props.ossModus} />
                </div>
                <div className="panel-body">
                    <Svar svar={this.state.svar} ossModus={this.props.ossModus} svarEndres={this.onEndreSvar} redigeringsModus={this.props.redigeringsModus} />
                </div>
                {redigeringModus}
            </div>
        </div>;
    }

    private endrePublisert() {
        this.setState({
            publisert: !this.state.publisert
        });
    }


    private lagreEndringer() {
        const skjemadata = {
            sporsmal: this.state.sporsmal,
            id: this.state.id,
            svar: this.state.svar,
            publisert: this.state.publisert,
            kategori: this.state.kategori,
            kunde: this.state.kunde
        };

        const skjemadataJson = JSON.stringify(skjemadata);
        fetch("api/SporsmalOgSvar/", {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "PUT",
            body: skjemadataJson
        }).then(res => {
            if (res.status == 200 || res.status == 204) {
                this.setState({
                    requestTilbakemelding: "Oppdatering OK."
                });
            } else {
                console.log(`Feilmelding: ${res.statusText}`);
                this.setState({
                    requestTilbakemelding: "Oppdatering feilet. Prøv igjen senere."
                });
            }

            var interval = setInterval( () => {
                clearInterval(interval);
                this.setState({
                    requestTilbakemelding: undefined
                });   
            }, 2000);
        });
    }

    private slettSporsmal() {
        if (!confirm("Denne handlingen vil fjerne spørsmålet.")) return;
        fetch(`api/SporsmalOgSvar/${this.state.id}`, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "DELETE"
        }).then(res => {
            if (res.status == 200 || res.status == 204) {
                this.props.onDelete(this.state.id);
            } else {
                console.log(`Feilmelding: ${res.statusText}`);
                this.setState({
                    requestTilbakemelding: "En feil oppsto. Kunne ikke slette."
                });
            }
        });
    }

    private onEndreSvar(innhold: string) {
        const nyttSvar = {
            svar: innhold,
            besvart: (new Date()).toJSON(),
            besvartAv: "Ola"
        } as SvarI;

        this.setState({
            svar: nyttSvar
        });
    }
}