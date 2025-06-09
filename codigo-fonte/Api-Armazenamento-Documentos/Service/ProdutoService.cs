using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_Orcamento.Service
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _productCollection;

        public ProdutoService(
            IOptions<BudgetManagerDataBaseSettings> budgetManagerDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                budgetManagerDataBaseSettings.Value.ConnectionStrings);
            var mongoDataBase = mongoClient.GetDatabase(
                budgetManagerDataBaseSettings.Value.DataBaseName);
            _productCollection = mongoDataBase.GetCollection<Produto>(
                budgetManagerDataBaseSettings.Value.BudgetCollectionProduct);
        }

        public Task<List<Produto>> GetAllAsync() => GetAsync();

        public async Task<List<Produto>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();
        public async Task<Produto?> GetAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Produto newProduct) =>
            await _productCollection.InsertOneAsync(newProduct);
        public async Task UpdateAsync(string id, Produto updateProduct) =>
           await _productCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);

        public async Task DeleteAsync(string id) =>
            await _productCollection.DeleteOneAsync(x => x.Id == id);

        //Adição da funcionalidade pequisar
        public async Task<List<Produto>> SearchAsync(string searchTerm)
        {
            // Se o termo de pesquisa for nulo ou vazio, retorne todos os fornecedores
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAsync();
            }

            // Converte o termo de pesquisa para minúsculas uma única vez para comparações
            var lowerSearchTerm = searchTerm.ToLower();

            // Constrói o filtro para a pesquisa no MongoDB

            var filter = Builders<Produto>.Filter.Where(f =>

                f.NomeProduto.ToLower().Contains(lowerSearchTerm) ||

                f.Marca.ToLower().Contains(lowerSearchTerm) ||

                f.Descricao.Contains(searchTerm)
            );

            // Executa a busca no MongoDB com o filtro e retorna a lista
            return await _productCollection.Find(filter).ToListAsync();


        }
    }
}
