import * as React from "react";
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";
import Sporsmal from "./Sporsmal";
import Svar from "./Svar";
import { SporsmalOgSvarI, SporsmalI } from "ClientApp/interfaces/ModelInterface";


export default class SporsmalOgSvar extends React.Component<SporsmalOgSvarIProps, SporsmalOgSvarI> {

    public render() {
        return <div className="panel-group">
            <div className="panel panel-default">
                <div className="panel-heading">
                    <Sporsmal sporsmal={this.props.sporsmalOgSvar.sporsmal} ossModus={this.props.ossModus} />
                </div>
                <div className="panel-body">
                    <Svar svar={this.props.sporsmalOgSvar.svar} ossModus={this.props.ossModus}/>
                </div>
            </div>
        </div>;
    }

}