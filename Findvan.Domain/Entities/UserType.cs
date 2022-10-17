using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class UserType : Entity
    {
        public User(string name, Guid id)
        {
            Name = name;
            Id = Id;
            Img = "";
            LastLogin = DateTime.Now;
        }

        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public string Img { get; private set; }
        public DateTime LastLogin { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateImg(string img)
        {
            Img = img;
        }
    }
}
