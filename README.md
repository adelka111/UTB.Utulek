# Útulek zvířat s virtuální adopcí

Webová aplikace ASP.NET Core MVC (.NET 10) pro útulek. Návštěvníci si prohlížejí zvířata k adopci, zákazníci si je mohou virtuálně adoptovat, zaměstnanci a administrátor spravují data v oblasti Admin.

## Architektura

| Projekt | Vrstva | Obsah |
|---|---|---|
| `UTB.Utulek.Domain` | Domain | entity, výčty, vlastní validační atribut, rozhraní repozitářů |
| `UTB.Utulek.Application` | Application | služby (`IAnimalAppService`, `ISpeciesAppService`, `IImageStorage`) |
| `UTB.Utulek.Infrastructure` | Infrastructure | EF Core (`UtulekDbContext`), migrace, seed, generický `Repository<T, TKey>`, Identity |
| `UTB.Utulek.Web` | Presentation | MVC kontrolery, pohledy, Area Admin |

Kontrolery používají jen služby z Application, nikdy přímo DbContext nebo repozitáře.

## Požadavky

- .NET 10 SDK
- MySQL 8
- Visual Studio 2022+ nebo VS Code

## Spuštění

1. Naklonuj repozitář a otevři `UTB.Utulek.slnx`.
2. V projektu `UTB.Utulek.Web` vytvoř soubor `appsettings.Development.json` (je v `.gitignore`):

   ```json
   {
     "ConnectionStrings": {
       "MySQL": "server=localhost;port=3306;database=utulek;user=root;password=TVOJE_HESLO"
     }
   }
   ```

3. Vytvoř databázi: v Package Manager Console nastav jako výchozí projekt `UTB.Utulek.Infrastructure` a spusť `Update-Database`. Migrace vytvoří i role a výchozího administrátora.
4. Spusť projekt `UTB.Utulek.Web`. Aplikace běží na `https://localhost:7218`.

## Role a přihlášení

| Role | Oprávnění |
|---|---|
| Admin | správa všeho v Area Admin |
| Manager | správa zvířat a druhů |
| Customer | prohlížení zvířat (každý nově registrovaný uživatel) |

Přihlašovací údaje výchozího administrátora předá autor vyučujícímu zvlášť.

## Co je hotové

- vícevrstvá architektura, entity, EF Core Code-First, migrace, generický Repository pattern
- Identity: registrace, přihlášení, role Admin / Manager / Customer
- Area Admin: správa zvířat (včetně editace a nahrání fotky) a druhů zvířat
- veřejná úvodní stránka se zvířaty, vlastní validační atribut `NotInFuture`

## Plánováno

- novinky o zvířatech (`AnimalUpdate`), virtuální adopce, správa uživatelů v Adminu
