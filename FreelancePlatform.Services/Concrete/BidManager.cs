﻿using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class BidManager : IBidService
    {
        private readonly IBidDal _bidDal;

        public BidManager(IBidDal bidDal)
        {
            _bidDal = bidDal;
        }

        public async Task TAddAsync(Bid entity)
        {
            await _bidDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Bid entity)
        {
            await _bidDal.DeleteAsync(entity);
        }

        public async Task<Bid> TGetByIdAsync(int id)
        {
            return await _bidDal.GetByIdAsync(id);
        }

        public async Task<List<Bid>> TGetListAllAsync()
        {
            return await _bidDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Bid entity)
        {
            await _bidDal.UpdateAsync(entity);
        }
        public async Task<List<Bid>> GetBidsByProjectIdAsync(int projectId)
        {
            return await _bidDal.GetBidsByProjectIdAsync(projectId);
        }

        public async Task<List<ResultBidWithProjectDto>> GetBidsByFreelancerIdAsync(int freelancerId)
        {
            return await _bidDal.GetBidsByFreelancerIdAsync(freelancerId);
        }
     

        public async Task AcceptBidAsync(int bidId)
        {
            await _bidDal.AcceptBidAsync(bidId);
        }
        public async Task<List<ResultBidWithProjectDto>> GetBidsByEmployerIdAsync(int employerId)
        {
            return await _bidDal.GetBidsByEmployerIdAsync(employerId);
        }
        public async Task AddBidAsync(Bid bid)
        {
            bid.CreatedAt = DateTime.UtcNow;
            await _bidDal.AddAsync(bid);
        }

    }
}
