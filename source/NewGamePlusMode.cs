namespace GuessTheNumber2
{
    class NewGamePlusMode : GameMode
    {
        public NewGamePlusMode(Translator translator, HallOfFame hallOfFame, HallOfFameScreen hallOfFameScreen)
            : base(translator, hallOfFame, hallOfFameScreen)
        {
        }

        public override void Play()
        {
            Console.Clear();
            Console.WriteLine(translator.Get("new_game_plus_info"));
            Console.WriteLine();

            if (!ChooseDifficulty())
                return;

            Random rand = new Random();
            int hiddenNumber = rand.Next(minNumber, maxNumber + 1);

            int changeInterval = rand.Next(6, 9);
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
                    SaveResult(attemptNumber, time, isNewGamePlus: true);
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

                if (!wasGuessed && attemptNumber % changeInterval == 0)
                {
                    hiddenNumber = rand.Next(minNumber, maxNumber + 1);
                    changeInterval = rand.Next(6, 9);
                    Console.WriteLine(translator.Get("number_changed"));
                }
            }
        }
    }
}
