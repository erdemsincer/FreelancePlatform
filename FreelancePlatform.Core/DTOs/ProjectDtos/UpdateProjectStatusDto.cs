using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Core.DTOs.ProjectDtos
{
    public class UpdateProjectStatusDto
    {
        public int ProjectId { get; set; }
        public string NewStatus { get; set; }
    }
}
