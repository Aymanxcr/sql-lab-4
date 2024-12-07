using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Lab4;

class Program
{
    // Creating a single instance of HttpClient for reuse
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        // Setting the User-Agent header to meet API requirements for GitHub
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Lab4", "1.0"));

        // Fetch and display repositories from the GitHub API
        await GetDotNetRepositories();

        // Fetch and display information about a specific ZIP code from the Zippopotam API
        await GetZipCodeInfo();
    }

    private static async Task GetDotNetRepositories()
    {
        // URL for fetching repositories under the .NET Foundation from GitHub
        var url = "https://api.github.com/orgs/dotnet/repos";
        var response = await client.GetStringAsync(url);

        // Deserialize JSON response into a list of GitHubProjektRepo objects
        var repositories = JsonSerializer.Deserialize<List<GitHubProjektRepo>>(response);

        // Change console text color to cyan for better visibility
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Repositories under .Net Foundation:");
        Console.ResetColor();

        // Loop through each repository and display its details
        foreach (var repo in repositories)
        {
            Console.WriteLine($"\nName: {repo.Name}"
                + $"\nHomepage: {repo.Homepage}"
                + $"\nGitHub: {repo.HtmlUrl}"
                + $"\nDescription: {repo.Description}"
                + $"\nWatchers: {repo.Watchers}"
                + $"\nLast push: {repo.PushedAt}\n");
        }
    }

    private static async Task GetZipCodeInfo()
    {
        // URL for fetching ZIP code information from the Zippopotam API
        var url = "https://api.zippopotam.us/us/07645";
        var response = await client.GetStringAsync(url);

        // Deserialize JSON response into a ZipCodeInfo object
        var zipCodeInfo = JsonSerializer.Deserialize<ZipCodeInfo>(response);

        // Check if the response contains valid data and display details
        if (zipCodeInfo != null && zipCodeInfo.Places.Count > 0)
        {
            var place = zipCodeInfo.Places[0];

            // Change console text color to green for extra details
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Here is the extra detail:");
            Console.ResetColor();

            // Display ZIP code details
            Console.WriteLine($"ZIP Code: {zipCodeInfo.PostCode}"
                + $"\nPlace: {place.Places}"
                + $"\nState: {place.State}"
                + $"\nLatitude: {place.Latitude}"
                + $"\nLongitude: {place.Longitude}");
        }
        else
        {
            // Display message if no data is found for the ZIP code
            Console.WriteLine("No data found for the ZIP code.");
        }
    }
}
