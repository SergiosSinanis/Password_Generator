using System.Text;

namespace PasswordGenerator
{
    public class Program
    {
        private static readonly Dictionary<string, string> CharacterSets = new()
        {
            { "upper", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            { "lower", "abcdefghijklmnopqrstuvwxyz" },
            { "numbers", "0123456789" },
            { "symbols", "!@#$%^&*()_+-=[]{}|;:',.<>?/" }
        };

        public static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            string continueGenerating = "Y";
            while (continueGenerating == "Y")
            {
                try
                {
                    GeneratePassword();
                    continueGenerating = PromptToContinue();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("╔══════════════════════╗");
            Console.WriteLine("║  Password Generator  ║");
            Console.WriteLine("╚══════════════════════╝");
        }

        private static void GeneratePassword()
        {
            bool validInput = false;
            while (!validInput)
            {
                DisplayInputInstructions();
                string userInput = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Error: Input cannot be empty.");
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

                var (isValid, length, selectedOptions) = ParseUserInput(userInput);
                if (!isValid) continue;

                string password = CreatePassword(length, selectedOptions);
                DisplayGeneratedPassword(password);
                validInput = true;
            }
        }

        private static void DisplayInputInstructions()
        {
            Console.WriteLine("\nSpecify password requirements:");
            Console.WriteLine("Format: [length], [options]");
            Console.WriteLine("Available options: upper, lower, numbers, symbols");
            Console.WriteLine("Example: '12, upper, numbers' for 12 characters with uppercase letters and numbers");
            Console.Write("\nYour choice: ");
        }

        private static (bool isValid, int length, List<string> options) ParseUserInput(string input)
        {
            string[] parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (!int.TryParse(parts[0], out int length))
            {
                Console.WriteLine("Error: Invalid length specified.");
                return (false, 0, null);
            }

            if (length <= 0 || length > 100)
            {
                Console.WriteLine("Error: Length must be between 1 and 100 characters.");
                return (false, 0, null);
            }

            var validOptions = new List<string>();
            var invalidOptions = new List<string>();

            for (int i = 1; i < parts.Length; i++)
            {
                string option = parts[i].ToLower().Trim();
                if (CharacterSets.ContainsKey(option))
                {
                    validOptions.Add(option);
                }
                else
                {
                    invalidOptions.Add(option);
                }
            }

            if (invalidOptions.Count > 0)
            {
                Console.WriteLine($"Warning: Ignored invalid options: {string.Join(", ", invalidOptions)}");
            }

            if (validOptions.Count == 0)
            {
                Console.WriteLine("Error: No valid character types selected.");
                return (false, 0, null);
            }

            return (true, length, validOptions);
        }

        private static string CreatePassword(int length, List<string> options)
        {
            StringBuilder charPool = new();
            foreach (string option in options)
            {
                charPool.Append(CharacterSets[option]);
            }

            var random = new Random();
            StringBuilder password = new();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(charPool.Length);
                password.Append(charPool[index]);
            }

            return password.ToString();
        }

        private static void DisplayGeneratedPassword(string password)
        {
            Console.WriteLine("\n╔══ Generated Password ══╗");
            Console.WriteLine($"║ {password.PadRight(19)}║");
            Console.WriteLine("╚═════════════════════════╝");
        }

        private static string PromptToContinue()
        {
            Console.Write("\nGenerate another password? (Y/N): ");
            return Console.ReadLine()?.Trim().ToUpper() ?? "N";
        }
    }
}