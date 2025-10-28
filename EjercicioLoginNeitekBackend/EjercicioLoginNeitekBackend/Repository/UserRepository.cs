using EjercicioLoginNeitekBackend.Models;

namespace EjercicioLoginNeitekBackend.Repository
{
    public class UserRepository(UserContext context) : IRepository<User, Guid>
    {

        private readonly UserContext _context = context;
        public async Task Add(User entity) => await _context.AddAsync(entity);

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }
        public Task<User?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<User> Search(Func<User, bool> filter) => _context.Users.Where(filter).ToList();
        public IEnumerable<User> Search(Func<User, bool> filter) => [.. _context.Users.Where(filter)];
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
