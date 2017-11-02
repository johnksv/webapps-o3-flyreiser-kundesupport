import * as React from "react";
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";
import Sporsmal from "./Sporsmal";
import Svar from "./Svar";
import { SporsmalOgSvarI, SporsmalI } from "ClientApp/interfaces/ModelInterface";


export default class SporsmalOgSvar extends React.Component<SporsmalOgSvarIProps, SporsmalOgSvarI> {

    public render() {
        return <div className="sporsmalogsvar">
                <Sporsmal sporsmal={this.props.sporsmalOgSvar.sporsmal} />
                <Svar svar={this.props.sporsmalOgSvar.svar} />
            </div>;
    }

}