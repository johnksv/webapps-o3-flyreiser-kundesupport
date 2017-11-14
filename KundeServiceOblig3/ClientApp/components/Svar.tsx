import * as React from "react";
import { SvarIProps } from "../interfaces/PropsInterface";
import { SvarI } from "../interfaces/ModelInterface";

export default class Svar extends React.Component<SvarIProps, { svar: string }> {

    constructor(props: any) {
        super(props);

        let propSvar = "";
        if (this.props.svar) {
            propSvar = this.props.svar.svar;
        }

        this.state = {
            svar: propSvar
        };

        this.onEndreSvar = this.onEndreSvar.bind(this);
    }

    public render() {
        if (this.props.redigeringsModus) {
            return <div className="svar">
                <textarea rows={3} cols={75} onChange={this.onEndreSvar} value={this.state.svar}></textarea>
            </div>;
        }

        if (this.props.svar) {
            const date = new Date(this.props.svar.besvart);

            return <div className="svar">
                <p>{this.props.svar.svar}</p>
                {this.props.ossModus ? "" : <p className="text-info">Besvart av {this.props.svar.besvartAv}, den {date.toLocaleDateString()}.</p>}
            </div>;
        }


        return <div className="svar">
            <p>Dette spørsmålet mangler svar.</p>
        </div>;

    }


    private onEndreSvar(event: React.ChangeEvent<HTMLTextAreaElement>) {
        const value = event.currentTarget.value;
        this.setState({
            svar: value
        });

        this.props.svarEndres(value);
    }

}