namespace GuessTheNumber2
{
    class Translator
    {
        private string language;

        private Dictionary<string, Dictionary<string, string>> texts = new Dictionary<string, Dictionary<string, string>>
        {
            ["PL"] = new Dictionary<string, string>
            {
                ["welcome"] = "=== Zgadnij Liczbę 2! ===",
                ["menu_new_game"] = "1. Nowa gra",
                ["menu_hall_of_fame"] = "2. Hall of Fame",
                ["menu_settings"] = "3. Ustawienia",
                ["menu_exit"] = "4. Wyjście",
                ["choice"] = "Twój wybór: ",
                ["invalid_choice"] = "Zły wybór, spróbuj jeszcze raz.",
                ["difficulty_easy"] = "Łatwy (1-50)",
                ["difficulty_medium"] = "Średni (1-100)",
                ["difficulty_hard"] = "Trudny (1-250)",
                ["choose_difficulty"] = "Wybierz poziom trudności:",
                ["standard_mode"] = "1. Tryb standardowy (Zgadnij Liczbę 1)",
                ["new_game_plus_mode"] = "2. Nowa gra+ (liczba losuje się co 6/7/8 prób)",
                ["choose_game_mode"] = "Wybierz tryb gry:",
                ["bet_question"] = "Czy chcesz spróbować trybu zakładu? (t/n): ",
                ["bet_enter_attempt_limit"] = "Podaj maksymalną liczbę prób: ",
                ["bet_active"] = "Tryb zakładu aktywny! Masz {0} prób.",
                ["guess_prompt"] = "Zgadnij liczbę (próba {0}): ",
                ["too_low"] = new string[]{
                    "Za mało! Liczba jest większa.",
                    "Nieee, szukaj wyżej!",
                    "Zbyt mała liczba, idź w górę!",
                    "Pomyśl o czymś większym...",
                    "Nie, liczba jest powyżej twojej odpowiedzi!"
                }[new Random().Next(5)],
                ["too_high"] = new string[]{
                    "Za dużo! Liczba jest mniejsza.",
                    "Nieee, szukaj niżej!",
                    "Zbyt duża liczba, idź w dół!",
                    "Pomyśl o czymś mniejszym...",
                    "Nie, liczba jest poniżej twojej odpowiedzi!"
                }[new Random().Next(5)],
                ["success"] = "Brawo! Zgadłeś w {0} próbach! Czas: {1} sekund.",
                ["name_prompt"] = "Podaj swoje imię: ",
                ["bet_lost"] = "Niestety, nie zgadłeś w {0} próbach. Liczba to była {1}.",
                ["number_changed"] = "Uwaga! Ukryta liczba właśnie się zmieniła!",
                ["hof_empty"] = "Brak wyników. Zagraj najpierw!",
                ["hof_header"] = "=== HALL OF FAME ===",
                ["hof_difficulty"] = "Poziom: {0}",
                ["hof_new_game_plus"] = "=== Nowa Gra+ ===",
                ["hof_entry"] = "{0}. {1} - {2} prób, {3} sek",
                ["hof_entry_new"] = "{0}. {1} - {2} prób, {3} sek  [NOWY!]",
                ["hof_back"] = "Naciśnij Enter, żeby wrócić...",
                ["settings_header"] = "=== USTAWIENIA ===",
                ["settings_language"] = "1. Zmień język (aktualnie: {0})",
                ["settings_clear_hof"] = "2. Wyczyść Hall of Fame",
                ["settings_bet"] = "3. Pytaj o zakład: {0}",
                ["settings_back"] = "4. Powrót",
                ["settings_confirm_clear"] = "Czy na pewno chcesz wyczyścić Hall of Fame? (t/n): ",
                ["settings_cleared"] = "Hall of Fame wyczyszczony!",
                ["settings_cancelled"] = "Anulowano.",
                ["goodbye"] = "Do zobaczenia!",
                ["yes"] = "TAK",
                ["no"] = "NIE",
                ["invalid_input"] = "Podaj prawidłową liczbę!",
                ["hof_switch"] = "Przełącz poziom: L - Łatwy, S - Średni, T - Trudny, N - Nowa Gra+, Enter - wróć",
                ["new_game_plus_info"] = "Uwaga! W trybie Nowa Gra+ zakład jest niedostępny.",
            },
            ["EN"] = new Dictionary<string, string>
            {
                ["welcome"] = "=== Guess The Number 2! ===",
                ["menu_new_game"] = "1. New game",
                ["menu_hall_of_fame"] = "2. Hall of Fame",
                ["menu_settings"] = "3. Settings",
                ["menu_exit"] = "4. Exit",
                ["choice"] = "Your choice: ",
                ["invalid_choice"] = "Wrong choice, try again.",
                ["difficulty_easy"] = "Easy (1-50)",
                ["difficulty_medium"] = "Medium (1-100)",
                ["difficulty_hard"] = "Hard (1-250)",
                ["choose_difficulty"] = "Choose difficulty level:",
                ["standard_mode"] = "1. Standard mode (Guess The Number 1)",
                ["new_game_plus_mode"] = "2. New Game+ (number changes every 6/7/8 guesses)",
                ["choose_game_mode"] = "Choose game mode:",
                ["bet_question"] = "Do you want to try bet mode? (y/n): ",
                ["bet_enter_attempt_limit"] = "Enter max number of tries: ",
                ["bet_active"] = "Bet mode active! You have {0} tries.",
                ["guess_prompt"] = "Guess the number (try {0}): ",
                ["too_low"] = new string[]{
                    "Too low! The number is higher.",
                    "Nope, go higher!",
                    "Too small, think bigger!",
                    "Think of something bigger...",
                    "No, the number is above your answer!"
                }[new Random().Next(5)],
                ["too_high"] = new string[]{
                    "Too high! The number is lower.",
                    "Nope, go lower!",
                    "Too big, think smaller!",
                    "Think of something smaller...",
                    "No, the number is below your answer!"
                }[new Random().Next(5)],
                ["success"] = "Congrats! You guessed in {0} tries! Time: {1} seconds.",
                ["name_prompt"] = "Enter your name: ",
                ["bet_lost"] = "You didn't guess in {0} tries. The number was {1}.",
                ["number_changed"] = "Watch out! The hidden number just changed!",
                ["hof_empty"] = "No results yet. Play first!",
                ["hof_header"] = "=== HALL OF FAME ===",
                ["hof_difficulty"] = "Level: {0}",
                ["hof_new_game_plus"] = "=== New Game+ ===",
                ["hof_entry"] = "{0}. {1} - {2} tries, {3} sec",
                ["hof_entry_new"] = "{0}. {1} - {2} tries, {3} sec  [NEW!]",
                ["hof_back"] = "Press Enter to go back...",
                ["settings_header"] = "=== SETTINGS ===",
                ["settings_language"] = "1. Change language (current: {0})",
                ["settings_clear_hof"] = "2. Clear Hall of Fame",
                ["settings_bet"] = "3. Ask about bet: {0}",
                ["settings_back"] = "4. Back",
                ["settings_confirm_clear"] = "Are you sure you want to clear Hall of Fame? (y/n): ",
                ["settings_cleared"] = "Hall of Fame cleared!",
                ["settings_cancelled"] = "Cancelled.",
                ["goodbye"] = "See you!",
                ["yes"] = "YES",
                ["no"] = "NO",
                ["invalid_input"] = "Please enter a valid number!",
                ["hof_switch"] = "Switch level: E - Easy, M - Medium, H - Hard, N - New Game+, Enter - back",
                ["new_game_plus_info"] = "Note! Bet mode is not available in New Game+.",
            }
        };

        public Translator(string language)
        {
            this.language = language;
        }

        public void SetLanguage(string newLanguage)
        {
            language = newLanguage;
        }

        public string Get(string key)
        {
            if (texts.ContainsKey(language) && texts[language].ContainsKey(key))
                return texts[language][key];
            return key; // fallback
        }

        // Random hint messages
        public string GetRandomMessage(string type)
        {
            Random rand = new Random();
            if (language == "PL")
            {
                if (type == "too_low")
                {
                    string[] messages = {
                        "Za mało! Liczba jest większa.",
                        "Nieee, szukaj wyżej!",
                        "Zbyt mała liczba, idź w górę!",
                        "Pomyśl o czymś większym...",
                        "Nie, liczba jest powyżej twojej odpowiedzi!"
                    };
                    return messages[rand.Next(messages.Length)];
                }
                else
                {
                    string[] messages = {
                        "Za dużo! Liczba jest mniejsza.",
                        "Nieee, szukaj niżej!",
                        "Zbyt duża liczba, idź w dół!",
                        "Pomyśl o czymś mniejszym...",
                        "Nie, liczba jest poniżej twojej odpowiedzi!"
                    };
                    return messages[rand.Next(messages.Length)];
                }
            }
            else
            {
                if (type == "too_low")
                {
                    string[] messages = {
                        "Too low! The number is higher.",
                        "Nope, go higher!",
                        "Too small, think bigger!",
                        "Think of something bigger...",
                        "No, the number is above your answer!"
                    };
                    return messages[rand.Next(messages.Length)];
                }
                else
                {
                    string[] messages = {
                        "Too high! The number is lower.",
                        "Nope, go lower!",
                        "Too big, think smaller!",
                        "Think of something smaller...",
                        "No, the number is below your answer!"
                    };
                    return messages[rand.Next(messages.Length)];
                }
            }
        }

        public string YesNo(bool value)
        {
            if (value)
                return Get("yes");
            return Get("no");
        }
    }
}
