import * as React from "react";
import 'isomorphic-fetch';
import { RouteComponentProps } from 'react-router';
import { SporsmalOgSvarIProps } from "../interfaces/PropsInterface";

export default class SporsmalOgSvarContainer extends React.Component<RouteComponentProps<{}>, {}> {

    componentDidMount() {
        this.hentAlleSporsmalOgSvar();
    }

    public render() {

        return <div>
            
        </div>;
    }

    private hentAlleSporsmalOgSvar(): SporsmalOgSvarIProps[] | undefined {
        let result : SporsmalOgSvarIProps[];

        fetch("api/sporsmalogsvar/")
            .then(response => console.log(response.json()))
            .catch(error => console.log(error));

        return undefined;
    }

}