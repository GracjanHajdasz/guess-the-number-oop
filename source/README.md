# Zgadnij Liczbę 2!

Sequel gry "Zgadnij Liczbę" napisany w C# jako projekt zaliczeniowy z podstaw programowania.

## Wymagania

- .NET 8.0 SDK lub nowszy

## Uruchomienie

```bash
cd source
dotnet run
```

albo zbuduj i uruchom exe:

```bash
dotnet build source/GuessTheNumber2.csproj
dotnet run --project source/GuessTheNumber2.csproj
```

## Jak grać

### Ekran powitalny

Po uruchomieniu pojawi się menu główne z opcjami:

- **1. Nowa gra** – rozpocznij rozgrywkę
- **2. Hall of Fame** – sprawdź najlepsze wyniki (opcja pojawia się dopiero po zagraniu przynajmniej jednej gry)
- **3. Ustawienia** – zmień język, wyczyść wyniki, włącz/wyłącz tryb zakładu
- **4. Wyjście** – zamknij program

### Tryby gry

Po wyborze "Nowa gra" wybierasz tryb:

#### Tryb standardowy (Zgadnij Liczbę 1)

Klasyczna rozgrywka. Wybierasz poziom trudności:

- **Łatwy** – liczba od 1 do 50
- **Średni** – liczba od 1 do 100
- **Trudny** – liczba od 1 do 250

Opcjonalnie możesz włączyć **tryb zakładu** – podajesz maksymalną liczbę prób. Jeśli nie odgadniesz w tym limicie, przegrywasz.

#### Nowa Gra+

Tak samo jak tryb standardowy, ale co 6, 7 lub 8 prób ukryta liczba jest losowana od nowa! Gra poinformuje cię o zmianie. Tryb zakładu nie jest tutaj dostępny.

### Podczas gry

- Na ekranie zawsze widoczny jest numer aktualnej próby
- Po każdej złej odpowiedzi dostaniesz wskazówkę czy liczba jest za mała czy za duża
- Po odgadnięciu podaj swoje imię i wynik trafi do Hall of Fame

### Hall of Fame

Wyświetla Top 5 najlepszych wyników dla każdego poziomu trudności. Możesz przełączać widok:

- **L** – Łatwy
- **S** – Średni
- **T** – Trudny
- **N** – Nowa Gra+
- **Enter** – wróć do menu

Twój ostatni wynik jest wyróżniony kolorem żółtym i oznaczony `[NOWY!]`.

Ranking sortowany jest najpierw po liczbie prób, a przy remisie – po czasie (wygrywa szybszy).

### Ustawienia

- **Zmień język** – przełącza między polskim (PL) a angielskim (EN)
- **Wyczyść Hall of Fame** – usuwa wszystkie wyniki (wymaga potwierdzenia)
- **Pytaj o zakład** – włącza lub wyłącza pytanie o tryb zakładu przed każdą grą

## Struktura projektu

```
ZgadnijLiczbe2/
├── Program.cs                  – punkt wejścia
├── Game.cs                     – główna pętla i menu
├── Settings.cs                 – ustawienia gry (JSON)
├── Translator.cs               – obsługa języków PL/EN
├── HallOfFame.cs               – zarządzanie wynikami
├── HallOfFameEntry.cs          – model wpisu w Hall of Fame
├── HallOfFameScreen.cs         – ekran wyników
├── SettingsScreen.cs           – ekran ustawień
├── StandardGameMode.cs         – logika trybu standardowego
├── NewGamePlusMode.cs          – logika trybu Nowa Gra+
├── GuessTheNumber2.csproj      – plik projektu
└── README.md                   – ten plik
```

Wyniki i ustawienia zapisywane są lokalnie w plikach `halloffame.json` w katalogu roboczym.
