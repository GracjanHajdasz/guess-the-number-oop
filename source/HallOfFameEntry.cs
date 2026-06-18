using System.Text.Json.Serialization;

namespace GuessTheNumber2
{
    class HallOfFameEntry
    {
        [JsonPropertyName("Imie")]
        public string Name { get; set; } = "";

        [JsonPropertyName("IloscProb")]
        public int AttemptCount { get; set; }

        [JsonPropertyName("CzasSekundy")]
        public int TimeSeconds { get; set; }

        [JsonPropertyName("PoziomTrudnosci")]
        public string DifficultyLevel { get; set; } = "";

        [JsonPropertyName("NowaGraPlus")]
        public bool IsNewGamePlus { get; set; } = false;
    }
}
