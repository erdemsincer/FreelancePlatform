using FreelancePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IAdvertisementDal : IGenericDal<Advertisement>
    {
        Task<List<Advertisement>> GetAllWithIncludesAsync();
    }

}
