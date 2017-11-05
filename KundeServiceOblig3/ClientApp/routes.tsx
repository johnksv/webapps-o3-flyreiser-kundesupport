import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import SOSContainer from "./components/SporsmalOgSvarContainer";
import Skjema from "./components/Skjema";

export const routes = <Layout>
    <Route exact path="/" component={ Home } />
    <Route path="/sporsmalogsvar" component={SOSContainer} />
    <Route path="/skjema" component={Skjema} />
</Layout>;
