using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Api_Orcamento.Models
{
    public class Produto
    {
        public readonly IAsyncEnumerable<char>? Nome;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nomeProduto")]
        public string NomeProduto { get; set; } = null!;

        [BsonElement("marca")]
        public string Marca { get; set; } = null!;

        [BsonElement("descricao")]
        public string Descricao { get; set; } = null!;

        [BsonElement("orcamentoId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OrcamentoId { get; set; }
    }
}