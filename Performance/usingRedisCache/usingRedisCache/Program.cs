using StackExchange.Redis;

string connectionString = "bademo.redis.cache.windows.net:6380,password=SNmNbZA11Dfr5G3mPOKuw1zG1xqteDaF8AzCaD8aq5g=,ssl=True,abortConnect=False";

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);

//await SetCacheDataAsync();
//Console.WriteLine("Veri kaydedildi");
await GetCacheDataAsync();

async Task SetCacheDataAsync()
{
    IDatabase database = redis.GetDatabase();
    await database.StringSetAsync("top:students", "Anıl Etirli, Şeymanur Yıldırım");

}

async Task GetCacheDataAsync()
{
    IDatabase database = redis.GetDatabase();
    if (database.KeyExists("top:students"))
    {
        var value = await database.StringGetAsync("top:students");
        Console.WriteLine(value);
    }
}
