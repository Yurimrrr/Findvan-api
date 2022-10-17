using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindVan.Domain.Entities
{
    public class User : Entity
    {
        public User(string name)
        {
            Name = name;
            Img = "";
            LastLogin = DateTime.Now;
        }

        public string Name { get; private set; }

        public string Img { get; private set; }
        public DateTime LastLogin { get; private set; }
        [ForeignKey()]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

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
