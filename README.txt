Obligatorisk oppgave 3 - Kundeservice
John Kasper Svergja - s305089

For å kunne kjøre løsningen lokalt må du ha internett-tilgang slik at NuGet- og npm-pakker blir lastet ned.
URL: http://kundeserviceoblig3webapps.azurewebsites.net/

Styling er gjort minimalistik etter hensikt.
Jeg var veldig usikker på plassering av teksten i forhold til når man taster inn feil i skjemaet, og når man lister opp spørsmål på administeringssiden. 

Følgende teknologi og rammeverk er brukt:
- .NET Core 2.0 (https://www.microsoft.com/net)
- Reactjs v15.6.1 (http://reactjs.org/)
- Typescript v2.4.1 (https://www.typescriptlang.org/)
- Bootstrap v3.3.7 (https://getbootstrap.com/)
- Isomorphic-fetch v2.2.1 (https://github.com/matthew-andrews/isomorphic-fetch)
- react-router-dom v4.1.1 (https://github.com/ReactTraining/react-router)
Diverse andre pakker (se package.json for ytterlige detaljer).

Mangler:
Ved søk av spørsmål vil kategoriene automatisk bli kollapset. Dette fordi staten oppdateres, og komponenten rendreres på nytt.
Validering kunne vært mer presis/avanasert med tanke på de regulære utrykkene.  


Mulig løsning:
For å løse problemet med søk kunne jeg ha implementert løsningen med Redux. I nåværende tilfelle må jeg sende states frem og tilbake mellom komponenter, noe som medfører endringer i mange filer når jeg skal utvide funksjonaliteten som skal gjelde i flere komponenter. Med redux ville jeg kun trengt å oppdatere staten/storen en gang. Jeg vurderte imidlertid oppgavene dit hen av bruk av redux ikke ville være nødvendig, dette også på grunn av den ekstra kompleksisteten som blir introdusert i en liten applikasjon.


Mine opplevelser med .NET Core og React
Det var veldig mye arbeid i starten for å sette opp databasen korrekt mtp sette opp service, seeding og relasjoner. Når dette var ferdig satt opp har imidlert utviklingen gått veldig fint. Siden jeg ikke er kjent med API-programmering fra .NET MVC er det vanskelig å sammenligne, men jeg kan si at det har vært veldig greit å lage API i Core, da det tilbyr dekoratører som tar av seg all intern mapping som må gjøres.
React er også veldig behagelig når man først kommer i gang med det. "Heldigvis" tok visual studio av seg å sette opp konfigurasjonsfiler for at dette skulle kjøre sømløst med visual studio.


Nyttige ressurser jeg har brukt for å komme i gang med .net core og EF Core
Komme i gang med web-api
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

Sette opp database
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro

Sette opp migrasjon av database
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations

HTTP-koder i .NET core
https://stackoverflow.com/questions/37690114/asp-net-core-how-to-return-a-specific-status-code-and-no-contents-from-control