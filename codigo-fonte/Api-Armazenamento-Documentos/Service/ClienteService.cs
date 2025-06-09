using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_Orcamento.Service
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clientCollection;

        public ClienteService(
            IOptions<BudgetManagerDataBaseSettings> budgetManagerDataBaseSettings)
        {
            var mongoClient = new MongoClient(budgetManagerDataBaseSettings.Value.ConnectionStrings);
            var mongoDataBase = mongoClient.GetDatabase(budgetManagerDataBaseSettings.Value.DataBaseName);
            _clientCollection = mongoDataBase.GetCollection<Cliente>(budgetManagerDataBaseSettings.Value.BudgetCollectionCustomer);
        }

        public Task<List<Cliente>> GetAllAsync() => GetAsync();

        public async Task<List<Cliente>> GetAsync() =>
            await _clientCollection.Find(_ => true).ToListAsync();

        public async Task<Cliente?> GetAsync(string id) =>
            await _clientCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente newBudget) =>
            await _clientCollection.InsertOneAsync(newBudget);

        public async Task UpdateAsync(string id, Cliente updateBudget) =>
            await _clientCollection.ReplaceOneAsync(x => x.Id == id, updateBudget);

        public async Task DeleteAsync(string id) =>
            await _clientCollection.DeleteOneAsync(x => x.Id == id);

        //Adição da funcionalidade pequisar
        public async Task<List<Cliente>> SearchAsync(string searchTerm)
        {
            // Se o termo de pesquisa for nulo ou vazio, retorne todos os fornecedores
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAsync();
            }

            // Converte o termo de pesquisa para minúsculas uma única vez para comparações
            var lowerSearchTerm = searchTerm.ToLower();

            // Constrói o filtro para a pesquisa no MongoDB

            var filter = Builders<Cliente>.Filter.Where(f =>

                f.Nome.ToLower().Contains(lowerSearchTerm) ||

                f.Email.ToLower().Contains(lowerSearchTerm) ||

                f.Telefone.ToLower().Contains(lowerSearchTerm) ||

                f.Endereco.ToLower().Contains(lowerSearchTerm) ||

                f.Complemento.ToLower().Contains(lowerSearchTerm) ||

                f.Cep.Contains(searchTerm)
            );

            // Executa a busca no MongoDB com o filtro e retorna a lista
            return await _clientCollection.Find(filter).ToListAsync();


        }
    }
}
