using FJR3IO_HFT_2023242.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FJR3IO_HFT_2023242.Models
{
    public class Garage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GarageID { get; set; }

        [Required]
        [StringLength(240)]
        public string GarageName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Motorcycle> Motorcycles { get; set; }

        public Garage()
        {
            
        }

        public Garage(string line)
        {
            string[] split = line.Split('#');
            GarageID = int.Parse(split[0]);
            GarageName = split[1];
        }
    }
}
