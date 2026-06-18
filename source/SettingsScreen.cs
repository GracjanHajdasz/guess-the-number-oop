namespace GuessTheNumber2
{
    class SettingsScreen
    {
        private Settings settings;
        private Translator translator;
        private HallOfFame hallOfFame;

        public SettingsScreen(Settings settings, Translator translator, HallOfFame hallOfFame)
        {
            this.settings = settings;
            this.translator = translator;
            this.hallOfFame = hallOfFame;
        }

        public void Show()
        {
            bool isExiting = false;
            while (!isExiting)
            {
                Console.Clear();
                Console.WriteLine(translator.Get("settings_header"));
                Console.WriteLine();
                Console.WriteLine(string.Format(translator.Get("settings_language"), settings.Language));
                Console.WriteLine(translator.Get("settings_clear_hof"));
                Console.WriteLine(string.Format(translator.Get("settings_bet"), translator.YesNo(settings.AskAboutBet)));
                Console.WriteLine(translator.Get("settings_back"));
                Console.WriteLine();
                Console.Write(translator.Get("choice"));
                string input = Console.ReadLine() ?? "";

                switch (input.Trim())
                {
                    case "1":
                        ChangeLanguage();
                        break;
                    case "2":
                        ClearHallOfFame();
                        break;
                    case "3":
                        settings.AskAboutBet = !settings.AskAboutBet;
                        settings.Save();
                        break;
                    case "4":
                        isExiting = true;
                        break;
                    default:
                        Console.WriteLine(translator.Get("invalid_choice"));
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void ChangeLanguage()
        {
            if (settings.Language == "PL")
            {
                settings.Language = "EN";
                translator.SetLanguage("EN");
            }
            else
            {
                settings.Language = "PL";
                translator.SetLanguage("PL");
            }
            settings.Save();
        }

        private void ClearHallOfFame()
        {
            Console.Write(translator.Get("settings_confirm_clear"));
            string answer = (Console.ReadLine() ?? "").Trim().ToLower();
            // Support t/y confirmations for both languages.
            if (answer == "t" || answer == "y")
            {
                hallOfFame.ClearAll();
                Console.WriteLine(translator.Get("settings_cleared"));
            }
            else
            {
                Console.WriteLine(translator.Get("settings_cancelled"));
            }
            System.Threading.Thread.Sleep(1500);
        }
    }
}
