
export interface SporsmalOgSvarI {
    Sporsmal: SporsmalI;
    Svar?: SvarI;
}

export interface SporsmalI {
    Sporsmal: string;
    Stilt: Date;
}

export interface SvarI {
    Svar: string;
    Besvart: Date;
    BesvartAv: string;
}

export interface SkjemaSporsmalI {
    Fornavn: string;
    Etternavn: string;
    Epost: string;
    Telefon: string;
    Sporsmal: SporsmalOgSvarI;
}