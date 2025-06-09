using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_Orcamento.Service
{
    public class AutenticacaoService
    {
        private readonly IMongoCollection<Usuarios> _userCollection;

        public AutenticacaoService(IOptions<BudgetManagerDataBaseSettings> budgetManagerDataBaseSettings)
        {
            var mongoClient = new MongoClient(budgetManagerDataBaseSettings.Value.ConnectionStrings);
            var mongoDatabase = mongoClient.GetDatabase(budgetManagerDataBaseSettings.Value.DataBaseName);
            _userCollection = mongoDatabase.GetCollection<Usuarios>(budgetManagerDataBaseSettings.Value.BudgetCollectionUsers);
        }

        public Task<List<Usuarios>> GetAllAsync() => GetAsync();

        public async Task<List<Usuarios>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<Usuarios?> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuarios newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, Usuarios updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task DeleteAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
