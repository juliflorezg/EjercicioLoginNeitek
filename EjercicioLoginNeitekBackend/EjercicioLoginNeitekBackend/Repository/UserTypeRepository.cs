using EjercicioLoginNeitekBackend.Models;

namespace EjercicioLoginNeitekBackend.Repository
{
    public class UserTypeRepository(UserContext context) : IRepository<UserType, int>
    {

        private readonly UserContext _context = context;
        public async Task Add(UserType entity) => await _context.AddAsync(entity);

        public Task<IEnumerable<UserType>> Get()
        {
            throw new NotImplementedException();
        }
        public async Task<UserType?> GetById(int id) => await _context.UserTypes.FindAsync(id);

        public void Update(UserType entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(UserType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserType> Search(Func<UserType, bool> filter) => [.. _context.UserTypes.Where(filter)];
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
