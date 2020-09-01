using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClient
{
    class Joke
    {
        [JsonPropertyName("setup")]
        public string Setup { get; set; }

        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Welcome to Joke API");


            var keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine($"What would you like to do?");
                Console.WriteLine($"(J) Get a random Joke");
                Console.WriteLine($"(Q) Quit");
                var choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "q":
                        keepGoing = false;
                        break;
                    case "j":
                        var client = new HttpClient();
                        var url = $"https://official-joke-api.appspot.com/random_joke";
                        var responseAsStream = await client.GetStreamAsync(url);
                        var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);

                        Console.WriteLine($"{joke.Setup}");
                        Console.WriteLine($"{joke.Punchline}");
                        Console.WriteLine($"Press Enter to continue");
                        Console.ReadLine();

                        break;
                    default:
                        break;
                }

            }

        }
    }
}