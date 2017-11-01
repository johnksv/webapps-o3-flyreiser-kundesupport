import * as React from "react";
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";
import Sporsmal from "./Sporsmal";
import Svar from "./Svar";


export default class SporsmalOgSvar extends React.Component<SporsmalOgSvarIProps, {}> {

    public render() {
        return <div>
            <Sporsmal Sporsmal={this.props.SporsmalOgSvar.Sporsmal} />
            <Svar Svar={this.props.SporsmalOgSvar.Svar} />
        </div>

    }

}