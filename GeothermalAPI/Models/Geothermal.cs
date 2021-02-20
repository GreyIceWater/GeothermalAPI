using System;
using System.Collections.Generic;

namespace GeothermalAPI.Models
{
    public class Geothermal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double GoogleRating { get; set; }        
    }

    public class GeothermalList
    {
        public List<Geothermal> geothermals;
    }
}
