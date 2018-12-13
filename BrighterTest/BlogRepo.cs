using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrighterTestDb;
using Microsoft.EntityFrameworkCore;

namespace BrighterTest
{
    public class BlogRepo
    {
        private readonly BloggingContext _context;

        public BlogRepo(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToArrayAsync();
        }

        public async Task Add(string url)
        {
            _context.Add(new Blog {Url = url});
            await _context.SaveChangesAsync();
        }
    }
}