namespace GuessTheNumber2
{
    class Game
    {
        private Settings settings;
        private Translator translator;
        private HallOfFame hallOfFame;
        private HallOfFameScreen hallOfFameScreen;
        private SettingsScreen settingsScreen;

        public Game()
        {
            settings = new Settings();
            translator = new Translator(settings.Language);
            hallOfFame = new HallOfFame();
            hallOfFameScreen = new HallOfFameScreen(hallOfFame, translator);
            settingsScreen = new SettingsScreen(settings, translator, hallOfFame);
        }

        public void Run()
        {
            bool isExiting = false;

            while (!isExiting)
            {
                Console.Clear();
                Console.WriteLine(translator.Get("welcome"));
                Console.WriteLine();
                Console.WriteLine(translator.Get("menu_new_game"));

                // Hall of Fame is visible only after at least one score exists.
                if (hallOfFame.HasAnyEntry())
                {
                    Console.WriteLine(translator.Get("menu_hall_of_fame"));
                }

                Console.WriteLine(translator.Get("menu_settings"));
                Console.WriteLine(translator.Get("menu_exit"));
                Console.WriteLine();
                Console.Write(translator.Get("choice"));

                string input = (Console.ReadLine() ?? "").Trim();

                switch (input)
                {
                    case "1":
                        ChooseGameMode();
                        break;
                    case "2":
                        if (hallOfFame.HasAnyEntry())
                        {
                            hallOfFameScreen.Show();
                        }
                        else
                        {
                            Console.WriteLine(translator.Get("invalid_choice"));
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;
                    case "3":
                        settingsScreen.Show();
                        break;
                    case "4":
                        Console.WriteLine(translator.Get("goodbye"));
                        isExiting = true;
                        break;
                    default:
                        Console.WriteLine(translator.Get("invalid_choice"));
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void ChooseGameMode()
        {
            Console.Clear();
            Console.WriteLine(translator.Get("choose_game_mode"));
            Console.WriteLine(translator.Get("standard_mode"));
            Console.WriteLine(translator.Get("new_game_plus_mode"));
            Console.Write(translator.Get("choice"));

            string input = (Console.ReadLine() ?? "").Trim();

            GameMode? gameMode = null;

            if (input == "1")
            {
                gameMode = new StandardGameMode(translator, settings, hallOfFame, hallOfFameScreen);
            }
            else if (input == "2")
            {
                gameMode = new NewGamePlusMode(translator, hallOfFame, hallOfFameScreen);
            }
            else
            {
                Console.WriteLine(translator.Get("invalid_choice"));
                System.Threading.Thread.Sleep(1000);
                return;
            }
            gameMode.Play();
        }
    }
}
