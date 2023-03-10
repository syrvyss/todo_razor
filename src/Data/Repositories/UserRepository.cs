using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using WebApp.Data.Interfaces;

namespace WebApp.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository {
    public void Delete(Guid id) {
        var collection = GetValues();

        var filter = Builders<BsonDocument>.Filter
            .Eq(x => "_id", id.ToString());

        collection?.DeleteOne(filter);
    }

    public void Update(User user) {
        var collection = GetValues();

        var filter = Builders<BsonDocument>.Filter
            .Eq(x => "_id", user.Id?.ToString());

        var update = Builders<BsonDocument>.Update
            .Set(x => x, user.ToBsonDocument());

        collection?.UpdateOne(filter, update);
    }

    public void Create(User user, string id) {
        var collection = GetValues();
        var document = new BsonDocument(user.ToBsonDocument());
        document["_id"] = id;

        collection?.InsertOne(document);
        Console.WriteLine(collection);
    }

    public User? Read(Guid id) {
        var collection = GetValues();

        var obj = collection.Find(x => x["_id"] == id);
        return BsonSerializer.Deserialize<User>(obj.ToBsonDocument());
    }

    public List<User> Get() {
        var collection = GetValues();

        return collection
            .AsQueryable()
            .ToList()
            .ConvertAll(x => BsonSerializer.Deserialize<User>(x.ToBsonDocument()));
    }

    private IMongoCollection<BsonDocument>? GetValues() {
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

        if (connectionString == null) {
            Console.WriteLine(
                "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
            Environment.Exit(0);
        }

        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("todo_razor").GetCollection<BsonDocument>("user");

        return collection;
    }
}