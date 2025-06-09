using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_Orcamento.Models
{
    public class Usuarios
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string? Nome { get; set; } = null!;

        [BsonElement("email")]
        public string? Email { get; set; } = null!;

        [BsonElement("senha")]
        public string? Senha { get; set; } = null!;

        [BsonElement("perfil")]
        public string? Perfil { get; set; } = null!;
    }
}
