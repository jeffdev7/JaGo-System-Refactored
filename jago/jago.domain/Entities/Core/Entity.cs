using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jago.domain.Entities.Core
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
        }
    }
}
