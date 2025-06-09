using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Api_Orcamento.Models
{
    public class Orcamento
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

        [BsonElement("detalhes")]
        public string? Detalhes { get; set; } = null;

        [BsonElement("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [BsonElement("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [BsonElement("solicitacao")]
        public List<Solicitacao> Solicitacao { get; set; } = new List<Solicitacao>();

        [BsonElement("produto")]
        public List<Produto> Produto { get; set; } = new List<Produto>();
    }
}
