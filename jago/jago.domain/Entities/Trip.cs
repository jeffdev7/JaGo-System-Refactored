using jago.domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jago.domain.Entities
{
    public class Trip : Entity, IEntityTypeConfiguration<Trip>
    {
        public Trip(Guid id) { Id = id; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public virtual Passenger Passenger { get; set; }
        public Guid PassengerId { get; set; }
        public Trip() { }

        public Trip(string origem, string destino, DateTime departure,
            DateTime arrival, Guid passengerId)
        {
            Origem = origem;
            Destino = destino;
            Departure = departure;
            Arrival = arrival;
            PassengerId = passengerId;
        }
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Origem).IsRequired();
            builder.Property(j => j.Destino).IsRequired();
            builder.Property(j => j.Departure).IsRequired();
        }
    }
}
