using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeothermalAPI.Models
{
    [Table("installer")]
    public class Installer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? GoogleRating { get; set; }
        public string ImageURL { get; set; }
    }

    public class InstallerList
    {
        public List<Installer> installers;
    }
}
