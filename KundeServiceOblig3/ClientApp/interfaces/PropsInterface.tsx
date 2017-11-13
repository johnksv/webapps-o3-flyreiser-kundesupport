//Legger til props som et eget interface for type safety

import { SporsmalOgSvarI, SporsmalI, SkjemaSporsmalI, SvarI, KategoriI } from "./ModelInterface";

export interface SporsmalOgSvarIProps {
    sporsmalOgSvar: SporsmalOgSvarI;
    //Ofte stilte spørsmål-modus = Finere formatering
    ossModus: boolean;
    //Callback når slette spørsmål
    onDelete?: any;
    redigeringsModus?: boolean;
}

export interface SporsmalIProps {
    sporsmal: SporsmalI;
    ossModus: boolean;
}

export interface SvarIProps {
    svar?: SvarI;
    ossModus: boolean;
    sporsmalID?: number;
    svarEndres?: any;
    redigeringsModus?: boolean;
}

export interface SkjemaSporsmalIProps {
    skjemaSporsmal: SkjemaSporsmalI;
}

export interface InputI {
    navn: string;
    id?: string;
    regex?: string;
    regexFlags?: string;
    feilmelding?: string;
    disableAutocomplete?: boolean;
    settValid: any; //Calback funksjon
    tittel?: string;
}

export interface KategoriIProps {
    kategori: KategoriI;
    index: number;
    ossModus: boolean;
    redigeringsModus?: boolean;
}

export interface SkjemaIProps {
    onSubmit: any; //Calback funksjon
}