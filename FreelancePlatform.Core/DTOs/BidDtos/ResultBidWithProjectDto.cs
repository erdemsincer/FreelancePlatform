using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Core.DTOs.BidDtos
{
    public class ResultBidWithProjectDto
    {
        public int BidId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public int FreelancerId { get; set; }
        public int EmployerId { get; set; }
        public string FreelancerName { get; set; }
        public decimal OfferAmount { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsAccepted { get; set; } // Teklif durumu
        public string ProjectStatus { get; set; } // Proje durumu (Açık, Alındı, Tamamlandı)
    }
}
