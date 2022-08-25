using jago.domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace jago.domain.Entities
{
    public class Passenger : Entity, IEntityTypeConfiguration<Passenger>
    {
        public Passenger(Guid id) { Id = id; }
        public string Name { get; set; }

        [RegularExpression(@"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)",
            ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public string Celular { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\._]+)@([a-zA-Z0-9])+.([a-z]+)(.[a-z]+)?$",
            ErrorMessage = "Entre com um email válido")]
        public string Email { get; set; }
        public Passenger() { }
        public Passenger(string name, string cpf, string celular, string email)
        {
            Name = name;
            CPF = cpf;
            Celular = celular;
            Email = email;
        }
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Name).IsRequired();
            builder.Property(j => j.Celular).IsRequired();
            builder.Property(j => j.Email).IsRequired();
        }
    }
}
