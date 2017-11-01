import * as React from "react";
import { RouteComponentProps } from 'react-router';

export default class Innsending extends React.Component<RouteComponentProps<{}>, {}> {

    constructor() {
        super();
    }

    public render() {
        return <div>
            <p>Hallo Verden!</p>    
        </div>;
    }


}