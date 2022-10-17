using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        [Key()]
        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}
