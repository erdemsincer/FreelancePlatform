﻿using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFPaymentDal : GenericRepository<Payment>, IPaymentDal
    {
        public EFPaymentDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
