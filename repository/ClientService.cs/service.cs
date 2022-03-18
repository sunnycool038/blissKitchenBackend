using blissBackend.Models;
using blissBackend.Models.Login;
using blissBackend.repository.interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace blissBackend.repository.ClientService
{
    public class BooksService : IClientService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BooksService(
        IOptions<BlissbackendSetting> BlissbackendSetting)
        {
            var mongoClient = new MongoClient(
            BlissbackendSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
            BlissbackendSetting.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
            BlissbackendSetting.Value.BooksCollectionName);
        }
        public async Task<List<Book>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();
        public async Task<Book?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task Create(Book newBook) =>
        await _booksCollection.InsertOneAsync(newBook);
        public async Task UpdateAsync(string id, Book updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }

}