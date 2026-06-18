using System.Text.Json;

namespace GuessTheNumber2
{
    class HallOfFame
    {
        private List<HallOfFameEntry> entries = new List<HallOfFameEntry>();
        private static string filePath = "halloffame.json";

        public HallOfFame()
        {
            Load();
        }

        public void AddEntry(HallOfFameEntry entry)
        {
            entries.Add(entry);
            Save();
        }

        public List<HallOfFameEntry> GetTop5(string difficultyLevel)
        {
            return entries
                .Where(entry => entry.DifficultyLevel == difficultyLevel && !entry.IsNewGamePlus)
                .OrderBy(entry => entry.AttemptCount)
                .ThenBy(entry => entry.TimeSeconds)
                .Take(5)
                .ToList();
        }

        public List<HallOfFameEntry> GetTop5NewGamePlus()
        {
            return entries
                .Where(entry => entry.IsNewGamePlus)
                .OrderBy(entry => entry.AttemptCount)
                .ThenBy(entry => entry.TimeSeconds)
                .Take(5)
                .ToList();
        }

        public bool HasAnyEntry()
        {
            return entries.Count > 0;
        }

        public void ClearAll()
        {
            entries.Clear();
            Save();
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filePath, json);
        }

        private void Load()
        {
            if (!File.Exists(filePath))
                return;

            try
            {
                string json = File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<HallOfFameEntry>>(json) ?? new List<HallOfFameEntry>();
            }
            catch
            {
                entries = new List<HallOfFameEntry>();
            }
        }
    }
}
