using System.Linq;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;

namespace FJR3IO_HFT_2023242.Repository
{
    public class ManufacturerRepository : Repository<Manufacturer>, IRepository<Manufacturer>
    {
        public ManufacturerRepository(MotorcycleDbContext ctx) : base(ctx)
        {

        }

        public override Manufacturer Read(int id)
        {
            return ctx.Manufacturers.FirstOrDefault(m => m.ManufacturerID == id);
        }

        public override void Update(Manufacturer item)
        {
            var old = Read(item.ManufacturerID);
            if (old != null)
            {
                foreach (var prop in old.GetType().GetProperties())
                {
                    if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                    {
                        prop.SetValue(old, prop.GetValue(item));
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
