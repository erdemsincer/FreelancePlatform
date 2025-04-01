using FreelancePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Services.Abstract
{
    public interface IAdvertisementService : IGenericService<Advertisement>
    {
        Task<List<Advertisement>> TGetAllWithIncludesAsync();
    }

}
