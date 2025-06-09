using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Api_Orcamento.Models
{

    public class Fornecedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nomeFantasia")]
        public string NomeFantasia { get; set; } = null!;

        [BsonElement("razaoSocial")]
        public string RazaoSocial { get; set; } = null!;

        [BsonElement("cnpj")]
        public string Cnpj { get; set; } = null!;

        [BsonElement("inscricaoEstadual")]
        public string InscricaoEstadual { get; set; } = null!;

        [BsonElement("incriscaoMunicipal")]
        public string InscricaoMunicipal { get; set; } = null!;

        [BsonElement("telefone")]
        public string Telefone { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("observacoes")]
        public string Observacoes { get; set; } = null!;

    }
}