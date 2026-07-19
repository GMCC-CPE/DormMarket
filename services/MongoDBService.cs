using MongoDB.Driver; 
public class MongoDBService 
    { 
        private readonly IMongoDatabase _database; 
        public MongoDBService(IConfiguration configuration) 
        { 
            var client = new MongoClient( configuration["MongoDB:ConnectionURI"]); 
            _database = client.GetDatabase( configuration["MongoDB:DatabaseName"]); 
        } 
    public IMongoCollection<studentUser> Students => _database.GetCollection<studentUser>("Students"); 
    public IMongoCollection<ownerUser> Owners => _database.GetCollection<ownerUser>("Owner"); 
    public IMongoCollection<dormListing> Listings => _database.GetCollection<dormListing>("Listings"); 

}