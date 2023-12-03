using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = GetTotalScoredGoalsAsync(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = GetTotalScoredGoalsAsync(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    private static async Task<int> GetTotalScoredGoalsAsync(string team, int year)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://jsonmock.hackerrank.com/api/"),
        };

        int scoreGoals = 0;
        scoreGoals += await GetTotalScoredGoalsFromJsonMockAsync(httpClient, team, year, true);
        scoreGoals += await GetTotalScoredGoalsFromJsonMockAsync(httpClient, team, year, false);
        return scoreGoals;
    }

    private static async Task<int> GetTotalScoredGoalsFromJsonMockAsync(HttpClient httpClient, string teamName, int year, bool playedInHome)
    {
        string teamParameter = playedInHome ? "team1" : "team2";

        var response = await httpClient.GetAsync("football_matches?year=" + year + "&" + teamParameter + "=" + teamName);

        var contentString = await response.Content.ReadAsStringAsync();

        var matches = JsonConvert.DeserializeObject<FootballMatches>(contentString);

        var scoreGoals = 0;

        if (matches != null)
        {
            if (matches.total_pages > 1)
            {
                for (int i = 1; i <= matches.total_pages; i++)
                {
                    var responsePage = await httpClient.GetAsync("football_matches?year=" + year + "&" + teamParameter + "=" + teamName + "&page=" + i);

                    var contentStringPage = await responsePage.Content.ReadAsStringAsync();

                    var matchesInPage = JsonConvert.DeserializeObject<FootballMatches>(contentStringPage);

                    if (matchesInPage != null)
                    {
                        scoreGoals += playedInHome ? matchesInPage.Data.Sum(p => Convert.ToInt32(p.Team1goals)) : matchesInPage.Data.Sum(p => Convert.ToInt32(p.Team2goals));
                    }
                }
            }
        }

        return scoreGoals;
    }

}