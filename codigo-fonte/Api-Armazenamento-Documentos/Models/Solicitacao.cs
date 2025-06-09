using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api_Orcamento.Models
{
    public class Solicitacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("descricao")]
        public string Descricao{ get; set; } = null!;

        [BsonElement("preco")]
        public string Preco { get; set; } = null!;

        [BsonElement("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [BsonElement("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [BsonElement("orcamentoId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OrcamentoId { get; set; }

    }
}