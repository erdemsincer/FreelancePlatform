using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Core.DTOs.AdvertisementDtos
{
    public class CreateAdvertisementDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FreelancerId { get; set; }
        public int CategoryId { get; set; }
    }
}
