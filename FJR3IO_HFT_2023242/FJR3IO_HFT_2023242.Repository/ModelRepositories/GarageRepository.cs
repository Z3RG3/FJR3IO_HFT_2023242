using System.Linq;
using FJR3IO_HFT_2023242.Models;

namespace FJR3IO_HFT_2023242.Repository
{
    public class GarageRepository : Repository<Garage>, IRepository<Garage>
    {
        public GarageRepository(MotorcycleDbContext ctx) : base(ctx)
        {

        }

        public override Garage Read(int id)
        {
            return ctx.Garages.FirstOrDefault(g => g.GarageID == id);
        }

        public override void Update(Garage item)
        {
            var old = Read(item.GarageID);
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
