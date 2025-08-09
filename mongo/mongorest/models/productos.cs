using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace mongorest.models
{

    public class productos
    {

        [BsonId] //indica que esta propiedad es el _id de MongoDB
        [BsonRepresentation(BsonType.ObjectId)] //Especifica que es un object ID
        public string? Id { get; set; }


        [BsonElement("CodProd")] // mapea la propiedad de mongodb
        [JsonPropertyName("CodProd")]
        public string? CodProd { get; set; }
        
        [BsonElement("Producto")] // mapea la propiedad de mongodb
        [JsonPropertyName("Producto")]
        public string? Producto { get; set; }
        
        [BsonElement("Precio")] // mapea la propiedad de mongodb
        [JsonPropertyName("Precio")]
        public string? Precio { get; set; }

    }
}
