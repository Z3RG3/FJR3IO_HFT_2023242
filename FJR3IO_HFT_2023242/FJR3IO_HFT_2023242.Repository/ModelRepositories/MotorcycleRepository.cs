using System.Linq;
using FJR3IO_HFT_2023242.Models;

namespace FJR3IO_HFT_2023242.Repository
{
    public class MotorcycleRepository : Repository<Motorcycle>, IRepository<Motorcycle>
    {
        public MotorcycleRepository(MotorcycleDbContext ctx) : base(ctx)
        {

        }

        public override Motorcycle Read(int id)
        {
            return ctx.Motorcycles.FirstOrDefault(m => m.MotorcycleID == id);
        }

        public override void Update(Motorcycle item)
        {
            var old = Read(item.MotorcycleID);
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
