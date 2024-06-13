/* ------- Code by hdeleon.net ------- */
/* ------- Modified by Mr Blue ------- */
/* ------- Github: 4D7220426C7565, Name: Mr Blue ------- */
//LINK - https://www.youtube.com/watch?v=nwPCmrkSKqE

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace CS_all
{
    class Program
    {
        public static async Task Main() // Cambiado a Task y marcado como static
        {
            string url = "https://www.poloniex.com/";
            string Chrome = @"./../../../../../bin/chromium";

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = Chrome,
            });

            var hashsetRequested = new HashSet<string>();
            var links = await Get(url);
            hashsetRequested.Add(url);

            int i = 0; // Contar Subdominios.

            foreach (var link in links)
            {
                Console.WriteLine(link);

                if (!hashsetRequested.Contains(link) && i++ < 10)
                {
                    hashsetRequested.Add(link);
                    if (IsNavigableUrl(link))
                    {
                        var subdomains = await Get(link);
                        foreach (var sb in subdomains)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"{sb}"); // Muestra los subdominios
                            Console.ResetColor();
                        }
                    }
                }
            }

            async Task<List<string>> Get(string url)
            {
                List<string> links = new();

                // Color del texto a azul para la frase "Solicitud a:"
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\nSolicitud a: ");
                // Restauramos el color original de la consola
                Console.ResetColor();
                
                // Color a las Peticiones
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{url}\n");
                Console.ResetColor();

                await using var page = await browser.NewPageAsync();
                var response = await page.GoToAsync(url);

                if (response.Status == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        var result = await page.EvaluateFunctionAsync<string[]>(
                            "() => {" +
                            "const a = document.querySelectorAll('a');" +
                            "const res = [];" +
                            "for(let i = 0; i < a.length; i++)" +
                            " res.push(a[i].href);" +
                            "return res;" +
                            "}"
                        );

                        if (result != null)
                        {
                            links.AddRange(result);
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron enlaces.");
                        }
                    }
                    catch (PuppeteerException ex)
                    {
                        Console.WriteLine($"Error al evaluar el script: {ex.Message}");
                    }
                }

                return links;
            }

            bool IsNavigableUrl(string url)
            {
                return url.StartsWith("http://") || url.StartsWith("https://");
            }
        }
    }
}
