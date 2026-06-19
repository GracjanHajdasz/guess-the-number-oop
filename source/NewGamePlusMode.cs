namespace GuessTheNumber2
{
    class NewGamePlusMode
    {
        private Translator translator;
        private HallOfFame hallOfFame;
        private HallOfFameScreen hallOfFameScreen;

        public NewGamePlusMode(Translator translator, HallOfFame hallOfFame, HallOfFameScreen hallOfFameScreen)
        {
            this.translator = translator;
            this.hallOfFame = hallOfFame;
            this.hallOfFameScreen = hallOfFameScreen;
        }

        public void Play()
        {
            Console.Clear();
            Console.WriteLine(translator.Get("new_game_plus_info"));
            Console.WriteLine();

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

            Random rand = new Random();
            int hiddenNumber = rand.Next(minNumber, maxNumber + 1);

            // Change the hidden number every 6 attempts.
            int changeInterval = 6;
            int attemptNumber = 1;
            bool wasGuessed = false;
            DateTime start = DateTime.Now;

            while (!wasGuessed)
            {
                Console.WriteLine($"--- {minNumber}-{maxNumber} | Nowa Gra+ ---");

                Console.Write(string.Format(translator.Get("guess_prompt"), attemptNumber));
                string numberInput = Console.ReadLine() ?? "";

                if (!int.TryParse(numberInput, out int guessedNumber))
                {
                    Console.WriteLine(translator.Get("invalid_input"));
                    continue;
                }

                if (guessedNumber == hiddenNumber)
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
                        IsNewGamePlus = true
                    };
                    hallOfFame.AddEntry(newEntry);
                    hallOfFameScreen.SetLastEntry(newEntry);
                }
                else if (guessedNumber < hiddenNumber)
                {
                    Console.WriteLine(translator.GetRandomMessage("too_low"));
                    attemptNumber++;
                }
                else
                {
                    Console.WriteLine(translator.GetRandomMessage("too_high"));
                    attemptNumber++;
                }

                // Check whether it is time to change the hidden number.
                if (!wasGuessed && attemptNumber % changeInterval == 0)
                {
                    hiddenNumber = rand.Next(minNumber, maxNumber + 1);
                    Console.WriteLine(translator.Get("number_changed"));
                }
            }
        }
    }
}
