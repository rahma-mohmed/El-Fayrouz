using Fayroz.Models;


namespace Fayroz.Services
{
    public class UserRepository
    {
        private readonly FayrozDbContext _dbContext;

        public UserRepository(FayrozDbContext dbContext)
        {
            
        }
        public List<User> getAll()
        {
            return _dbContext.Users.ToList();
        }
        public User getById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Create(User user)
        {
            _dbContext.Users.Add(user);
            int raw = _dbContext.SaveChanges();
            return raw;
        }

        public int Update(int id, User user)
        {
            User oldUser = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            oldUser.Name = user.Name;
            oldUser.Password = user.Password;
            oldUser.Email = user.Email;
            oldUser.Id = user.Id;
            int raw = _dbContext.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            User oldUser = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            _dbContext.Users.Remove(oldUser);
            int raw = _dbContext.SaveChanges();
            return raw;
        }

        public User getByName(string name)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}