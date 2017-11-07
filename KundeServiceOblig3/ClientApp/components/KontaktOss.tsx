﻿import * as React from "react";
import { RouteComponentProps } from 'react-router';
import Skjema from "./Skjema";

export default class KontaktOss extends React.Component<RouteComponentProps<{}>, {} > {

    public render() {
        return <div>
            <h1>Kontakt oss</h1>
            <p>Fant du ikke svar på spørsmålet du lurte på? Fortvil ikke. Kontakt oss via skjemaet under.</p>
            <div className="col-md-6">
                <Skjema />
            </div>
        </div>;
    }

}