using jago.domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace jago.domain.Entities
{
    public class Trip : Entity, IEntityTypeConfiguration<Trip>
    {
        public Guid Id { get;set; }
        
        [ForeignKey("Passenger")]
        public Guid PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public Trip() { }

        public Trip(Guid passengerId, string origem, string destino, 
            DateTime departure, DateTime arrival)
        {
            PassengerId = passengerId;
            Origem = origem;
            Destino = destino;
            Departure = departure;
            Arrival = arrival;
        }
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Origem).IsRequired();
            builder.Property(j => j.Destino).IsRequired();
            builder.Property(j => j.Departure).IsRequired();
            builder.Property(j => j.Arrival).IsRequired();
        }
    }
}
