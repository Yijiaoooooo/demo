using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Data.Domain.Reservation;

namespace Data.Mapping
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            this.ToTable("Reservation");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasColumnName("ReservationID");
            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.rowGuid).IsRequired();
            this.Property(c => c.Location).IsRequired();
            this.Property(c => c.CreateTime);
        }
    }
}
