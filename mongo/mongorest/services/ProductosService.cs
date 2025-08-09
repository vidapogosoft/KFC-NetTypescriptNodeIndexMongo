using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mongorest.models;

namespace mongorest.services
{
    public class ProductosService
    {

        private readonly IMongoCollection<productos> _productsCollection;

        public ProductosService( IOptions<ProductsStoreDbSettings> productsStoreDbSettings)
        {

            var mongoClient = new MongoClient(productsStoreDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productsStoreDbSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<productos>
                (productsStoreDbSettings.Value.CollectionName);

        }

        public async Task<List<productos>> GetProductos() => await _productsCollection.Find( a => true).ToListAsync();

        public async Task<productos> GetProductosObejct(string id) => 
            await _productsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateProduct (productos newItem) =>
           await _productsCollection.InsertOneAsync(newItem);

        public async Task UpdateProduct(string id,productos updItem) =>
           await _productsCollection.ReplaceOneAsync(x=> x.Id == id, updItem);

        public async Task RemoveProduct(string id) =>
           await _productsCollection.DeleteOneAsync(x => x.Id == id);


    }
}
