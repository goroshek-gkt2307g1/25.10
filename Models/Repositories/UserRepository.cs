using _25._10.Interfaces;
using _25._10.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private List<User> _users = [
            new User(1, "vasily", "1234578", "", 100),
            new User(2, "lolkekgg", "123456789", "slaaay", 55),
            new User(3, "brff", "321456787", "best strimer", 89),
            new User(4, "t2x2", "31456311", "hehe", -9999),
            new User(5, "stint", "123123123", "stintler", 666)
            ];
        public User? Find(Predicate<User> predicate) => _users.Find(predicate);
        public User? Get(int id) => _users.FirstOrDefault(x => x.Id == id);
        public IEnumerable<User> GetAll() => _users;

    }
}
