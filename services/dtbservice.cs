using MongoDB.Driver;

public class Dtbservice
{
    private readonly IMongoDatabase _database;
    public Dtbservice(IConfiguration configuration)
    {
        var client = new MongoClient(
            configuration["MongoDB:ConnectionURI"]);

        _database = client.GetDatabase(
            configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<(Student)> Students =>
        _database.GetCollection<Student>("Students");
}