import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import Kategori from "./components/Kategori";
import Skjema from "./components/Skjema";
import KontaktOss from "./components/KontaktOss";

export const routes = <Layout>
    <Route exact path="/" component={ Home } />
    <Route path="/sporsmalogsvar" component={Kategori} />
    <Route path="/kontaktoss" component={KontaktOss} />
</Layout>;
