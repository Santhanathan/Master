using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model.Domain;

namespace WebApplication1.Repositires
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public RegionRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
           region.ID= new Guid();
           await nzWalksDbContext.AddAsync(region);
           await nzWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nzWalksDbContext.regions.FirstOrDefaultAsync(x => x.ID == id);

            if (region == null)
            {
                return null;
            }
             nzWalksDbContext.Remove(region);
            await nzWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
          return await nzWalksDbContext.regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nzWalksDbContext.regions.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var extRegion = await nzWalksDbContext.regions.FirstOrDefaultAsync(x => x.ID == id);
            if (extRegion == null)
            {
                return null;
            }

            extRegion.code= region.code;
            extRegion.Name = region.Name;
            extRegion.Area= region.Area;
            extRegion.Lat= region.Lat;
            extRegion.Long= region.Long;
            extRegion.populatiom= region.populatiom;
            await nzWalksDbContext.SaveChangesAsync();
            return extRegion;
        }
    }
}
