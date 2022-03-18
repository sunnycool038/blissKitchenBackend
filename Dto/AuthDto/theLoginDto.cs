using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace blissBackend.Models.Login{
    public class theLoginDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public DateTime updated_at { get; set; } 
        public DateTime created_at { get; set; } 

    }
}