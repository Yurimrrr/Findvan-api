using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindVan.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string idFirebase)
        {
            Name = name;
            IdFirebase = idFirebase;
            Img = "";
            LastLogin = DateTime.Now;
        }

        public string Name { get; private set; }

        public string IdFirebase { get; private set; }

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
