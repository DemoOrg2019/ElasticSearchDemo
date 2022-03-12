using Microsoft.EntityFrameworkCore;
using Nest;
using NOV.ES.TAT.MDM.Domain;

namespace NOV.ES.MDMSearch.API.Infrastructure
{
    public class MdmDBContext : DbContext
    {
        public virtual DbSet<BrandInfo> BrandInfo { get; set; }
        public virtual DbSet<SalesZone> SalesZones { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Freight> Freights { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<TAT.MDM.Domain.Job> Jobs { get; set; }
        public virtual DbSet<Rig> Rigs { get; set; }

        public MdmDBContext(DbContextOptions<MdmDBContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }

    
}
