using Newtonsoft.Json.Linq;


public static class HttpRequest
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<(string data, int validCount)> GetAsyncdata(int count)
    {


        HttpResponseMessage response = await client.GetAsync($"https://randomuser.me/api/?results={count}");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return (responseBody, count);

    }




    public static Vcard[] WriteUserData(string jsondata)
    {
        var json = JObject.Parse(jsondata);  //newtonsoft json dan istifade edilerek json obyekti yaradildi 
        var users = json["results"];

        if (users == null || !users.HasValues)
        {
            return Array.Empty<Vcard>();
        }
        var vcards = new Vcard[users.Count()];
        int index = 0;

        foreach (var user in users)
        {
            vcards[index++] = new Vcard
            {
                Id = user["name"]["title"]?.Value<string>(),
                Name = user["name"]["first"]?.Value<string>(),
                Surname = user["name"]["last"]?.Value<string>(),
                Email = user["email"]?.Value<string>(),
                Phone = user["phone"]?.Value<string>(),
                Country = user["location"]["country"]?.Value<string>(),
                City = user["location"]["city"]?.Value<string>(),
            };

        }
        return vcards;
    }
    public static async Task<(string data, int validCount)> GetManualAsyncdata(int count, string country)
    {
        string countriesParam = string.Join(",", country);
        HttpResponseMessage response = await client.GetAsync($"https://randomuser.me/api/?results={count}&nat={country}");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return (responseBody, count);
    }
}