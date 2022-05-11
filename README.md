# Azure Redis Cache
This is an example of implementing an Azure Redis Cache in C#. It is written following the Clean Architecture, from my template from [vanarkel/Clean-Architecture-Example](https://github.com/vanarkel/Clean-Architecture-Example) and it is using the `Microsoft.Extensions.Caching.Redis` NuGet package.

Before writing the code, you have to create an Azure Redis Cache in the Azure Portal. It is handy that you save the connectionstring right now, as you'll use it later.

## Implementation
In `Program.cs` or `Startup.cs`, where you register your services for the Presentation/UI layer. Here we use my code from [joerivanarkel/.ConnectionString.md](https://gist.github.com/joerivanarkel/d5e11169d9a638678646f945d76a3989) to hide the connection string in dotnet secrets.

```dotnet
builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = DatabaseConnection<Program>.GetSecret("RedisConnection");
    option.InstanceName = "master";
});
```

In the Data Access class i try to get the list from the Redis Cache. Then i check if the result is null or empty by checking for the `"[]"` value. If not i deserialize the Json and return the list, using the `Newtonsoft.Json` NuGet package, but their are other possibilities. 

If it is empty, i get the data from the Database. Then i cache the data by serializing the Data in Json format.

```dotnet
var cachedList = _cache.GetString("Model");
if ((cachedPersonList != "[]"))
{
	return JsonConvert.DeserializeObject<IEnumerable<Model>>(cachedList);
}
else
{
	"Get from Database"

 	_cache.SetString("Model", JsonConvert.SerializeObject(List));
	return personList;
}
```
