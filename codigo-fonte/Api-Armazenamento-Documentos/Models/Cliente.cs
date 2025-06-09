using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_Orcamento.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("telefone")]
        public string Telefone { get; set; } = null!;

        [BsonElement("endereco")]
        public string Endereco { get; set; } = null!;

        [BsonElement("complemento")]
        public string? Complemento { get; set;} = null!;

        [BsonElement("cep")]
        public string Cep { get; set; } = null!;
    }
}