//Legger til props som et eget interface for type safety

import { SporsmalOgSvarI, SporsmalI, SkjemaSporsmalI, SvarI } from "./ModelInterface";

export interface SporsmalOgSvarIProps {
    sporsmalOgSvar: SporsmalOgSvarI;
}

export interface SporsmalIProps {
    sporsmal: SporsmalI;
}

export interface SvarIProps {
    svar?: SvarI;
}

export interface SkjemaSporsmalIProps {
    skjemaSporsmal: SkjemaSporsmalI;
}
