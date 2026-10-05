using System.Text.Json;

namespace ConsoleClicker
{
    class Program
    {
        private const string fileName = "ClickerSave.json";
        public static void Main()
        {
            Clicker[] clickers;
            if (File.Exists(fileName))
            {
                clickers = Load();
            }
            else
            { 
                clickers = new Clicker[]
                {
                new Clicker(0,ConsoleKey.J),
                new Clicker(0,ConsoleKey.K),
                new Clicker(0,ConsoleKey.L)
                };
            }
            
            while (true)
            {
                Console.Clear();
                foreach (var clicker in clickers)
                {
                    clicker.Write();
                }
                
                Console.WriteLine("Press M to modify the interaction key for clickers");

                ConsoleKeyInfo KeyPress = Console.ReadKey();
                foreach (var clicker in clickers)
                {
                    clicker.KeyPressHandler(KeyPress.Key);
                }
                Save(clickers);
            }
        }

        private static Clicker[] Load()
        {
            var json = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { IncludeFields = true };
            return JsonSerializer.Deserialize<Clicker[]>(json, options);
        }
        
        private static void Save(Clicker[] clickers)
        {
            var options = new JsonSerializerOptions{ IncludeFields = true};
            var json = JsonSerializer.Serialize(clickers,options);
            File.WriteAllText(fileName, json);
        }
    }
}