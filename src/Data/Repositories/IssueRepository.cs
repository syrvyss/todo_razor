using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using WebApp.Data.Interfaces;

namespace WebApp.Data.Repositories;

public class IssueRepository : BaseRepository<Issue>, IIssueRepository {
    public void Delete(Guid id) {
        var collection = GetValues();

        var filter = Builders<BsonDocument>.Filter
            .Eq(x => "_id", id.ToString());

        collection?.DeleteOne(filter);
    }

    public List<Issue> Get() {
        var collection = GetValues();

        return collection
            .AsQueryable()
            .ToList()
            .ConvertAll(x => BsonSerializer.Deserialize<Issue>(x.ToBsonDocument()));
    }

    public void Update(Issue issue) {
        var collection = GetValues();

        var filter = Builders<BsonDocument>.Filter
            .Eq(x => "_id", issue.Id?.ToString());

        var update = Builders<BsonDocument>.Update
            .Set(x => x, issue.ToBsonDocument());

        collection?.UpdateOne(filter, update);
    }

    public Issue? Read(Guid id) {
        var collection = GetValues();

        var obj = collection.Find(x => x["_id"] == id);
        return BsonSerializer.Deserialize<Issue>(obj.ToBsonDocument());
    }

    public void Create(Issue issue) {
        var collection = GetValues();
        var document = new BsonDocument(issue.ToBsonDocument());

        collection?.InsertOne(document);
        Console.WriteLine(collection);
    }

    private IMongoCollection<BsonDocument>? GetValues() {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

        if (connectionString == null) {
            Console.WriteLine(
                "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
            Environment.Exit(0);
        }

        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("todo_razor").GetCollection<BsonDocument>("issue");

        return collection;
    }
}