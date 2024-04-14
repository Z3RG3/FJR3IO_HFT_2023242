using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FJR3IO_HFT_2023242.Models
{
    public class Motorcycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MotorcycleID { get; set; }

        [Required]
        [StringLength(240)]
        public string Model { get; set; }

        public int ManufacturingYear { get; set; }

        public int ManufacturerID { get; set; }

        public int GarageID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Garage Garage { get; set; }

        public Motorcycle()
        {

        }

        public Motorcycle(string line)
        {
            string[] split = line.Split('#');
            MotorcycleID = int.Parse(split[0]);
            Model = split[1];
            ManufacturingYear = int.Parse(split[2]);
            ManufacturerID = int.Parse(split[3]);
            GarageID = int.Parse(split[4]);
        }
    }
}
