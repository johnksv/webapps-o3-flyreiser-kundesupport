import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import SporsmalOgSvarContainer from "./components/SporsmalOgSvarContainer";

export const routes = <Layout>
    <Route exact path="/" component={ Home } />
    <Route path="/sporsmalogsvar" component={SporsmalOgSvarContainer} />
</Layout>;
