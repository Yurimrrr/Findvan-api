using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindVan.Domain.Entities;

namespace FindVan.Domain.Repositores
{
    public interface IUserRepository
    {
        void Create(User user);

        void Update(User todo);

        User GetById(string idFirebase);

        IEnumerable<User> GetAll();
    }
}
