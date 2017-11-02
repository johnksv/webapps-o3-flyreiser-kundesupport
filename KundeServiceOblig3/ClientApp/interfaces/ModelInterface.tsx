
export interface SporsmalOgSvarI {
    id: number;
    sporsmal: SporsmalI;
    svar?: SvarI;
    publisert: boolean;
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
    //besvartAv: string;
}

export interface SkjemaSporsmalI {
    fornavn: string;
    etternavn: string;
    epost: string;
    telefon: string;
    sporsmal: SporsmalOgSvarI;
}