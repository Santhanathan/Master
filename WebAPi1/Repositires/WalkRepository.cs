using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model.Domain;
using WebApplication1.Model.DTO;

namespace WebApplication1.Repositires
{
    public class WalkRepository : IwalkRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public WalkRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.ID = new Guid();
            await nzWalksDbContext.AddAsync(walk);
            await nzWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await nzWalksDbContext.walks.FirstOrDefaultAsync(x => x.ID == id);

            if (walk == null)
            {
                return null;
            }
            nzWalksDbContext.Remove(walk);
            await nzWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nzWalksDbContext.walks
                .Include(x=>x.Region).
                Include(x=>x.Walkdifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await nzWalksDbContext.walks.Include(x => x.Region).
                Include(x => x.Walkdifficulty)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var extWalk = await nzWalksDbContext.walks.FirstOrDefaultAsync(x => x.ID == id);
            if (extWalk == null)
            {
                return null;
            }
            extWalk.Name = walk.Name;
            extWalk.length = walk.length;
            extWalk.RegionID = walk.RegionID;
            extWalk.WalkDifficultyID = walk.WalkDifficultyID;         
            await nzWalksDbContext.SaveChangesAsync();
            return extWalk;
        }
    }
}
