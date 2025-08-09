using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoEF
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }

        //documentados relacionados
        public Category Category { get; set; }

    }

    public class Category
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

}
