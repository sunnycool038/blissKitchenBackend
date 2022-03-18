using blissBackend.Models.Login;

namespace blissBackend.repository.interfaces{
    public interface IClientService{
        Task<List<Book>> GetAsync();
        Task<Book?> GetAsync(string id);
        Task Create(Book newBook);
        Task UpdateAsync(string id, Book updatedBook);
        Task RemoveAsync(string id);
    }
}