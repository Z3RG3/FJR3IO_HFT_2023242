using FJR3IO_HFT_2023242.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FJR3IO_HFT_2023242.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerID { get; set; }

        [Required]
        [StringLength(240)]
        public string ManufacturerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Motorcycle> Motorcycles { get; set; }

        public Manufacturer()
        {
            Motorcycles = new HashSet<Motorcycle>();
        }

        public Manufacturer(string line)
        {
            string[] split = line.Split('#');
            ManufacturerID = int.Parse(split[0]);
            ManufacturerName = split[1];
        }
    }
}
