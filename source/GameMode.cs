namespace GuessTheNumber2
{
    // Klasa abstrakcyjna - nie da się stworzyć obiektu "new GameMode()" wprost,
    // można tylko dziedziczyć po niej i nadpisywać metodę Play().
    // To jest abstrakcja: definiujemy WSPÓLNY interfejs dla trybów gry,
    // a szczegóły implementacji zostawiamy klasom potomnym.
    abstract class GameMode
    {
        // protected = dziedziczące klasy mają dostęp, ale reszta programu już nie.
        // To dalej jest enkapsulacja, tylko na poziomie hierarchii klas.
        protected Translator translator;
        protected HallOfFame hallOfFame;
        protected HallOfFameScreen hallOfFameScreen;

        protected int minNumber;
        protected int maxNumber;
        protected string difficultyName = "sredni";

        protected GameMode(Translator translator, HallOfFame hallOfFame, HallOfFameScreen hallOfFameScreen)
        {
            this.translator = translator;
            this.hallOfFame = hallOfFame;
            this.hallOfFameScreen = hallOfFameScreen;
        }

        // Metoda abstrakcyjna - nie ma ciała, każda klasa potomna MUSI
        // ją zaimplementować po swojemu. To właśnie umożliwia polimorfizm:
        // w Game.cs możemy trzymać zmienną typu GameMode i wywołać Play(),
        // a program sam wybierze odpowiednią wersję w zależności od typu obiektu.
        public abstract void Play();

        // Metoda wspólna dla obu trybów - wybór poziomu trudności wyglądał
        // identycznie w StandardGameMode i NewGamePlusMode, więc przenosimy
        // ją tutaj raz, żeby nie powtarzać kodu (DRY).
        // Zwraca false jeśli użytkownik wybrał coś złego.
        protected bool ChooseDifficulty()
        {
            Console.WriteLine(translator.Get("choose_difficulty"));
            Console.WriteLine("1. " + translator.Get("difficulty_easy"));
            Console.WriteLine("2. " + translator.Get("difficulty_medium"));
            Console.WriteLine("3. " + translator.Get("difficulty_hard"));
            Console.Write(translator.Get("choice"));

            string choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "1")
            {
                minNumber = 1;
                maxNumber = 50;
                difficultyName = "latwy";
                return true;
            }
            else if (choice == "2")
            {
                minNumber = 1;
                maxNumber = 100;
                difficultyName = "sredni";
                return true;
            }
            else if (choice == "3")
            {
                minNumber = 1;
                maxNumber = 250;
                difficultyName = "trudny";
                return true;
            }
            else
            {
                Console.WriteLine(translator.Get("invalid_choice"));
                System.Threading.Thread.Sleep(1000);
                return false;
            }
        }

        // Wspólna logika zapisu wyniku do Hall of Fame - też się powtarzała
        // w obu klasach, więc trafia do rodzica.
        protected void SaveResult(int attemptNumber, int time, bool isNewGamePlus)
        {
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
                IsNewGamePlus = isNewGamePlus
            };
            hallOfFame.AddEntry(newEntry);
            hallOfFameScreen.SetLastEntry(newEntry);
        }
    }
}
