using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindVan.Domain.Entities;
using FindVan.Domain.Infra.Contexts;
using FindVan.Domain.Queries;
using FindVan.Domain.Repositores;

namespace FindVan.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context
                .Users
                .AsNoTracking()
                .OrderBy(x => x.LastLogin);
        }

     

        public User GetById(string idFirebase)
        {
            return _context
                .Users
                .AsNoTracking()
                .FirstOrDefault(x => x.IdFirebase == idFirebase);
        }

        

        public void Update(User todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
