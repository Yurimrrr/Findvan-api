using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositores
{
    public interface IUserRepository
    {
        void Create(User user);

        void Update(User todo);

        User GetById(string idFirebase);

        IEnumerable<User> GetAll(string user);
        IEnumerable<User> GetAllDone(string user);
        IEnumerable<User> GetAllUndone(string user);
        IEnumerable<User> GetByPeriod(string user, DateTime date, bool done);
    }
}
