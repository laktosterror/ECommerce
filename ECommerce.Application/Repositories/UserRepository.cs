using ECommerce.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<bool> UpdateByIdAsync(Guid id, User user)
        {
            var currentUser = await _context.Users.FindAsync(id);
            currentUser = user;
            //TODO: kolla så det funkar
            _context.Users.Update(currentUser);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}