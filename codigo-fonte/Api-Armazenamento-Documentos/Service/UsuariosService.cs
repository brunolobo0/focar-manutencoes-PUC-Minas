using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_Orcamento.Service
{
    public class UsuariosService
    {
        private readonly IMongoCollection<Usuarios> _userscollection;
        public UsuariosService(
            IOptions<BudgetManagerDataBaseSettings> budgetManagerDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                budgetManagerDataBaseSettings.Value.ConnectionStrings);
            var mongoDatabase = mongoClient.GetDatabase(
                budgetManagerDataBaseSettings.Value.DataBaseName);
            _userscollection = mongoDatabase.GetCollection<Usuarios>(
                budgetManagerDataBaseSettings.Value.BudgetCollectionUsers);
        }
        public async Task<List<Usuarios>> GetAsync() =>
            await _userscollection.Find(_ => true).ToListAsync();
        public async Task<Usuarios?> GetAsync(string id) =>
            await _userscollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Usuarios newUsers) =>
            await _userscollection.InsertOneAsync(newUsers);
        public async Task UpdateAsync(string id, Usuarios updateUsers) =>
            await _userscollection.ReplaceOneAsync(x => x.Id == id, updateUsers);
        public async Task RemoveAsync(string id) =>
            await _userscollection.DeleteOneAsync(x => x.Id == id);
    }
}
