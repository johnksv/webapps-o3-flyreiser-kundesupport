
export interface SporsmalOgSvarI {
    id: number;
    Sporsmal: SporsmalI;
    Svar?: SvarI;
    publisert: boolean;
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