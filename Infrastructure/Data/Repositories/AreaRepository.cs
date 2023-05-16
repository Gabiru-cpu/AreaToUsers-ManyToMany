using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AreaApi.Domain.Models;
using AreaApi.Infrastructure.Data.Context;

namespace AreaApi.Infrastructure.Data.Repositories
{
    public class AreaRepository
    {
        private readonly MySqlContext _context;

        public AreaRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<Area>> ListAreas()
        {
            List<Area> list = await _context.Area
                .OrderBy(a => a.Data)
                .Include(a => a.OwnerUser)
                .Include(a => a.Users) 
                .ToListAsync();

            return list;
        }

        public async Task<List<Area>> ListAreasByApplicationUserId(string applicationUserId)
        {
            List<Area> list = await _context.Area.Where(p => p.OwnerUserId.Equals(applicationUserId)).OrderBy(p => p.Data).Include(p => p.OwnerUser).ToListAsync();

            return list;
        }

        public async Task<Area> GetAreaById(int areaId)
        {
            Area area = await _context.Area.Include(p => p.OwnerUser).FirstOrDefaultAsync((p => p.Id == areaId));

            return area;
        }

        public async Task<Area> CreateArea(Area area)
        {
            var ret = await _context.Area.AddAsync(area);

            await _context.SaveChangesAsync();

            ret.State = EntityState.Detached;

            return ret.Entity;
        }


        public async Task<Area> UpdateArea(Area area)
        {
            _context.Area.Update(area);
            await _context.SaveChangesAsync();
            return area;
        }


        // adicionar usuario na area por ID
        public async Task<Area> AddUserToArea(int areaId, string applicationUserId)
        {
            var area = await _context.Area
                .Include(a => a.Users)
                .FirstOrDefaultAsync(p => p.Id == areaId);

            //area.Users.Add(new ApplicationUser { Id = applicationUserId, AreaId = areaId });

            await _context.SaveChangesAsync();

            return area;
        }
    }
}
