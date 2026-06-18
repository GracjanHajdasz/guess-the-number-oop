namespace GuessTheNumber2
{
    class HallOfFameScreen
    {
        private HallOfFame hallOfFame;
        private Translator translator;
        private HallOfFameEntry? lastEntry;

        public HallOfFameScreen(HallOfFame hallOfFame, Translator translator)
        {
            this.hallOfFame = hallOfFame;
            this.translator = translator;
        }

        public void SetLastEntry(HallOfFameEntry entry)
        {
            lastEntry = entry;
        }

        public void Show()
        {
            // Start with the easy difficulty by default.
            string currentDifficulty = "latwy";
            bool isNewGamePlusView = false;

            bool isExiting = false;
            while (!isExiting)
            {
                Console.Clear();
                Console.WriteLine(translator.Get("hof_header"));
                Console.WriteLine();

                if (isNewGamePlusView)
                {
                    Console.WriteLine(translator.Get("hof_new_game_plus"));
                    DisplayList(hallOfFame.GetTop5NewGamePlus());
                }
                else
                {
                    string difficultyLabel = "";
                    if (currentDifficulty == "latwy")
                        difficultyLabel = translator.Get("difficulty_easy");
                    else if (currentDifficulty == "sredni")
                        difficultyLabel = translator.Get("difficulty_medium");
                    else
                        difficultyLabel = translator.Get("difficulty_hard");

                    Console.WriteLine(string.Format(translator.Get("hof_difficulty"), difficultyLabel));
                    DisplayList(hallOfFame.GetTop5(currentDifficulty));
                }

                Console.WriteLine();
                Console.WriteLine(translator.Get("hof_switch"));
                string input = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (input == "")
                {
                    isExiting = true;
                }
                else if (input == "L" || input == "E")
                {
                    currentDifficulty = "latwy";
                    isNewGamePlusView = false;
                }
                else if (input == "S" || input == "M")
                {
                    currentDifficulty = "sredni";
                    isNewGamePlusView = false;
                }
                else if (input == "T" || input == "H")
                {
                    currentDifficulty = "trudny";
                    isNewGamePlusView = false;
                }
                else if (input == "N")
                {
                    isNewGamePlusView = true;
                }
            }

            // Clear the highlight after leaving the screen.
            lastEntry = null;
        }

        private void DisplayList(List<HallOfFameEntry> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine(translator.Get("hof_empty"));
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                HallOfFameEntry entry = list[i];
                bool isNew = IsLastEntry(entry);

                string line;
                if (isNew)
                {
                    line = string.Format(translator.Get("hof_entry_new"), i + 1, entry.Name, entry.AttemptCount, entry.TimeSeconds);
                    Console.WriteLine(line);
                }
                else
                {
                    line = string.Format(translator.Get("hof_entry"), i + 1, entry.Name, entry.AttemptCount, entry.TimeSeconds);
                    Console.WriteLine(line);
                }
            }
        }

        private bool IsLastEntry(HallOfFameEntry entry)
        {
            if (lastEntry == null)
                return false;
            return entry.Name == lastEntry.Name
                && entry.AttemptCount == lastEntry.AttemptCount
                && entry.TimeSeconds == lastEntry.TimeSeconds
                && entry.DifficultyLevel == lastEntry.DifficultyLevel
                && entry.IsNewGamePlus == lastEntry.IsNewGamePlus;
        }
    }
}
