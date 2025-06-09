using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Orcamento.Service
{
    public class FornecedorService
    {
        private readonly IMongoCollection<Fornecedor> _supplierCollection;

        public FornecedorService(IOptions<BudgetManagerDataBaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionStrings);
            var database = client.GetDatabase(settings.Value.DataBaseName);
        _supplierCollection = database.GetCollection<Fornecedor>(settings.Value.BudgetCollectionSupplier);
        }

        public Task<List<Fornecedor>> GetAllAsync() => GetAsync();

        public async Task<List<Fornecedor>> GetAsync() =>
           await _supplierCollection.Find(_ => true).ToListAsync();

        public async Task<Fornecedor?> GetAsync(string id) =>
            await _supplierCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Fornecedor newBudget) =>
            await _supplierCollection.InsertOneAsync(newBudget);

        public async Task UpdateAsync(string id, Fornecedor updateBudget) =>
            await _supplierCollection.ReplaceOneAsync(x => x.Id == id, updateBudget);

        public async Task DeleteAsync(string id) =>
            await _supplierCollection.DeleteOneAsync(x => x.Id == id);

        //Adição da funcionalidade pequisar
        public async Task<List<Fornecedor>> SearchAsync(string searchTerm)
        {
            // Se o termo de pesquisa for nulo ou vazio, retorne todos os fornecedores
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAsync();
            }

            // Converte o termo de pesquisa para minúsculas uma única vez para comparações
            var lowerSearchTerm = searchTerm.ToLower();

            // Constrói o filtro para a pesquisa no MongoDB

            var filter = Builders<Fornecedor>.Filter.Where(f =>

                f.NomeFantasia.ToLower().Contains(lowerSearchTerm) ||

                f.RazaoSocial.ToLower().Contains(lowerSearchTerm) ||

                f.Cnpj.ToLower().Contains(lowerSearchTerm) ||

                f.InscricaoEstadual.ToLower().Contains(lowerSearchTerm) ||

                f.InscricaoMunicipal.ToLower().Contains(lowerSearchTerm) ||

                f.Email.ToLower().Contains(lowerSearchTerm) ||

                f.Telefone.ToLower().Contains(lowerSearchTerm) ||

                f.Observacoes.Contains(searchTerm)
            );

            // Executa a busca no MongoDB com o filtro e retorna a lista
            return await _supplierCollection.Find(filter).ToListAsync();



        }
    }
}