export interface KategoriI {
    navn: string;
    sporsmalOgSvar: SporsmalOgSvarI[];
    laster: boolean;
}


export interface SporsmalOgSvarI {
    id: number;
    sporsmal: SporsmalI;
    svar: SvarI | undefined;
    publisert: boolean;
    kategori: string;
    kunde: KundeI | undefined;
    //Udefinert om ikke oppdatert
    requestTilbakemelding: string | undefined;
}

interface KundeI {
    id: number;
    fornavn: string;
    etternavn: string;
    epost: string;
    telefon: string;
}

export interface SporsmalI {
    id: number;
    sporsmal: string;
    stilt: string;
}

export interface SvarI {
    id: number;
    svar: string;
    besvart: string;
    besvartAv: string;
}

export interface SkjemaSporsmalI {
    fornavn: string;
    etternavn: string;
    epost: string;
    telefon: string;
    sporsmal: SporsmalOgSvarI;
}

export interface SkjemaStateI {
    validForm: boolean;
    [valid: string]: boolean | string;
}