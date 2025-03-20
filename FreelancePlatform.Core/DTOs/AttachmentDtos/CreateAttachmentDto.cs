using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Core.DTOs.AttachmentDtos
{
    public class CreateAttachmentDto
    {
        public int ProjectId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
