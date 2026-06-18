namespace GuessTheNumber2
{
    class StandardGameMode
    {
        private Translator translator;
        private Settings settings;
        private HallOfFame hallOfFame;
        private HallOfFameScreen hallOfFameScreen;

        public StandardGameMode(Translator translator, Settings settings, HallOfFame hallOfFame, HallOfFameScreen hallOfFameScreen)
        {
            this.translator = translator;
            this.settings = settings;
            this.hallOfFame = hallOfFame;
            this.hallOfFameScreen = hallOfFameScreen;
        }

        public void Play()
        {
            Console.Clear();

            // Difficulty selection.
            Console.WriteLine(translator.Get("choose_difficulty"));
            Console.WriteLine("1. " + translator.Get("difficulty_easy"));
            Console.WriteLine("2. " + translator.Get("difficulty_medium"));
            Console.WriteLine("3. " + translator.Get("difficulty_hard"));
            Console.Write(translator.Get("choice"));

            int minNumber = 1;
            int maxNumber = 100;
            string difficultyName = "sredni";

            string choice = (Console.ReadLine() ?? "").Trim();
            if (choice == "1")
            {
                minNumber = 1;
                maxNumber = 50;
                difficultyName = "latwy";
            }
            else if (choice == "2")
            {
                minNumber = 1;
                maxNumber = 100;
                difficultyName = "sredni";
            }
            else if (choice == "3")
            {
                minNumber = 1;
                maxNumber = 250;
                difficultyName = "trudny";
            }
            else
            {
                Console.WriteLine(translator.Get("invalid_choice"));
                System.Threading.Thread.Sleep(1000);
                return;
            }

            // Bet mode.
            int maxAttempts = -1; // -1 means no bet.
            if (settings.AskAboutBet)
            {
                Console.Write(translator.Get("bet_question"));
                string betAnswer = (Console.ReadLine() ?? "").Trim().ToLower();
                if (betAnswer == "t" || betAnswer == "y")
                {
                    bool isValidNumber = false;
                    while (!isValidNumber)
                    {
                        Console.Write(translator.Get("bet_enter_attempt_limit"));
                        string attemptInput = Console.ReadLine() ?? "";
                        if (int.TryParse(attemptInput, out int parsedAttempts) && parsedAttempts > 0)
                        {
                            maxAttempts = parsedAttempts;
                            isValidNumber = true;
                        }
                        else
                        {
                            Console.WriteLine(translator.Get("invalid_input"));
                        }
                    }
                    Console.WriteLine(string.Format(translator.Get("bet_active"), maxAttempts));
                    System.Threading.Thread.Sleep(1500);
                }
            }

            // Hidden number generation.
            Random rand = new Random();
            int hiddenNumber = rand.Next(minNumber, maxNumber + 1);

            int attemptNumber = 1;
            bool wasGuessed = false;
            DateTime start = DateTime.Now;

            while (!wasGuessed)
            {
                Console.WriteLine($"--- {minNumber}-{maxNumber} ---");

                if (maxAttempts > 0)
                {
                    Console.WriteLine(string.Format(translator.Get("bet_active"), maxAttempts - attemptNumber + 1));
                }

                Console.Write(string.Format(translator.Get("guess_prompt"), attemptNumber));
                string numberInput = Console.ReadLine() ?? "";

                if (!int.TryParse(numberInput, out int guessedNumber))
                {
                    Console.WriteLine(translator.Get("invalid_input"));
                    continue;
                }

                if (guessedNumber < hiddenNumber)
                {
                    Console.WriteLine(translator.GetRandomMessage("too_low"));
                    attemptNumber++;
                }
                else if (guessedNumber > hiddenNumber)
                {
                    Console.WriteLine(translator.GetRandomMessage("too_high"));
                    attemptNumber++;
                }
                else
                {
                    wasGuessed = true;
                    DateTime end = DateTime.Now;
                    int time = (int)(end - start).TotalSeconds;

                    Console.WriteLine(string.Format(translator.Get("success"), attemptNumber, time));
                    Console.Write(translator.Get("name_prompt"));
                    string name = Console.ReadLine() ?? "Anonim";
                    if (string.IsNullOrWhiteSpace(name))
                        name = "Anonim";

                    HallOfFameEntry newEntry = new HallOfFameEntry
                    {
                        Name = name,
                        AttemptCount = attemptNumber,
                        TimeSeconds = time,
                        DifficultyLevel = difficultyName,
                        IsNewGamePlus = false
                    };
                    hallOfFame.AddEntry(newEntry);
                    hallOfFameScreen.SetLastEntry(newEntry);
                    return;
                }

                // Check the bet limit.
                if (maxAttempts > 0 && attemptNumber > maxAttempts)
                {
                    Console.WriteLine(string.Format(translator.Get("bet_lost"), maxAttempts, hiddenNumber));
                    Console.WriteLine(translator.Get("hof_back"));
                    Console.ReadLine();
                    return;
                }
            }
        }
    }
}
