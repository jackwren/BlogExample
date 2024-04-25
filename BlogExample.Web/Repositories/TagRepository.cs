using BlogExample.Web.Data;
using BlogExample.Web.Models.Domain;
using BlogExample.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogExample.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogExampleDbContext blogExampleDbContext;

        public TagRepository(BlogExampleDbContext blogExampleDbContext)
        {
            this.blogExampleDbContext = blogExampleDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogExampleDbContext.Tag.AddAsync(tag);
            await blogExampleDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var data = await blogExampleDbContext.Tag.FindAsync(id);

            if (data != null)
            {
                blogExampleDbContext.Tag.Remove(data);
                await blogExampleDbContext.SaveChangesAsync();
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogExampleDbContext.Tag.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await blogExampleDbContext.Tag.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var currentTag = await blogExampleDbContext.Tag.FindAsync(tag.Id);
            if(currentTag != null) 
            { 
                currentTag.Name = tag.Name;
                currentTag.DisplayName = tag.DisplayName;

                await blogExampleDbContext.SaveChangesAsync();
                return currentTag;
            }
            else
            {
                return null;
            }
        }
    }
}
