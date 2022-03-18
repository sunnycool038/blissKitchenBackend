using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace blissBackend.Models.Login
{
    public class myLogin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string firstname { get; set; } = null!;
        public string lastname { get; set; } = null!;
        public string email { get; set; } = null!;
        public decimal password { get; set; }

    }

}