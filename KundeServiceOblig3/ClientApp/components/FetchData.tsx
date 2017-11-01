import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    forecasts: SporsmalOgSvar[];
    loading: boolean;
}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };

        fetch('api/SporsmalOgSvar/')
            .then(response => response.json() as Promise<SporsmalOgSvar[]>)
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>;
    }

    private static renderForecastsTable(forecasts: SporsmalOgSvar[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.Sporsmal.Sporsmal}>
                        <td>{forecast.Sporsmal.Stilt}</td>
                        <td>{forecast.Svar.Svar}</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface SporsmalOgSvar {
    Sporsmal: SporsmalC;
    Svar: SvarC;
}

interface SporsmalC {
    ID: number;
    Sporsmal: string;
    Stilt: Date;
    Publisert: boolean;
}

interface SvarC {
    Svar: string;
    Besvart: Date;
}
