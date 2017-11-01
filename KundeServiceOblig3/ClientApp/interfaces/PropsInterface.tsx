//Legger til props som et eget interface for type safety

import { SporsmalOgSvarI, SporsmalI, SkjemaSporsmalI, SvarI } from "./ModelInterface";

export interface SporsmalOgSvarIProps {
    SporsmalOgSvar: SporsmalOgSvarI;
}

export interface SporsmalIProps {
    Sporsmal: SporsmalI;
}

export interface SvarIProps {
    Svar?: SvarI;
}

export interface SkjemaSporsmalIProps {
    SkjemaSporsmal: SkjemaSporsmalI;
}
