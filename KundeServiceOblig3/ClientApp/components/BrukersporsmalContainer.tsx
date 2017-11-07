import * as React from "react";
import 'isomorphic-fetch';
import { RouteComponentProps } from 'react-router';
import Skjema from "./Skjema";

export default class BrukersporsmalContainer extends React.Component<RouteComponentProps<{}>, {} > {

    public render() {
        return <div>
            <Skjema />
        </div>;
    }

}