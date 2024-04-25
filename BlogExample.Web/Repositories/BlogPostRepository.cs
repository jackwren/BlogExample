using BlogExample.Web.Data;
using BlogExample.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogExample.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogExampleDbContext blogExampleDbContext;

        public BlogPostRepository(BlogExampleDbContext blogExampleDbContext)
        {
            this.blogExampleDbContext = blogExampleDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogExampleDbContext.AddAsync(blogPost);
            await blogExampleDbContext.SaveChangesAsync();
            return blogPost;

        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var blogPost = await blogExampleDbContext.BlogPost.FindAsync(id);

            if (blogPost != null)
            {
                blogExampleDbContext.BlogPost.Remove(blogPost);
                await blogExampleDbContext.SaveChangesAsync();
                return blogPost;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogExampleDbContext.BlogPost.Include(x => x.Tag).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogExampleDbContext.BlogPost.Include(x => x.Tag).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetUrlHandleAsync(string urlHandle)
        {
            return await blogExampleDbContext.BlogPost.Include(x => x.Tag).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            //Use database call to find if blogpost exists with passed in ID.
            //create new object with this data, to be updated later
            var existingBlog = await blogExampleDbContext.BlogPost.Include(x => x.Tag).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            //if it does exist, update the values in new existingBlog object. 
            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Author = blogPost.Author;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.Tag = blogPost.Tag;

                await blogExampleDbContext.SaveChangesAsync();
                return existingBlog;
            };

            return null;
        }
    }
}
