import * as React from "react";
import { RouteComponentProps } from 'react-router';
import Skjema from "./Skjema";

interface KontaktOssI {
    harPostet: boolean;

    success: boolean | undefined;
}


export default class KontaktOss extends React.Component<RouteComponentProps<{}>, KontaktOssI> {

    constructor(props: any) {
        super(props);

        this.state = {
            harPostet: false,
            success: undefined
        };

        this.onSkjemaSubmit = this.onSkjemaSubmit.bind(this);
        this.resetState = this.resetState.bind(this);
    }

    public render() {
        let data;
        if (this.state.harPostet) {
            if (this.state.success) {
                data = <div>
                    <p>Spørsmålet ditt er sendt inn!</p>
                    <button className="btn btn-primary" onClick={this.resetState}>Send nytt spørsmål</button>
                </div>;
            } else {
                data = <div>
                    <p>En feil oppsto under innsending. Prøv igjen senere.</p>
                    <button className="btn btn-primary" onClick={this.resetState}>Prøv igjen</button>
                </div>;
            }
        } else {
            data = <div className="col-md-6">
                <Skjema onSubmit={this.onSkjemaSubmit} />
            </div>;
        }


        return <div>
            <h1>Kontakt oss</h1>
            <p>Fant du ikke svar på spørsmålet du lurte på? Fortvil ikke. Kontakt oss via skjemaet under.</p>

            {data}
        </div>;
    }

    private onSkjemaSubmit(success: boolean) {
        this.setState({
            harPostet: true,
            success: success
        });
    }

    private resetState() {
        this.setState({
            harPostet: false,
            success: undefined
        });
    }

}