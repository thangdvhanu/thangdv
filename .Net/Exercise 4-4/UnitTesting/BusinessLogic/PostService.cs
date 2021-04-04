using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class PostService
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        public void Add(string title, string url)
        {
            var post = new Post { Title = title, Blog = new Blog { Url = url } };
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> Find(string term)
        {
            return _context.Posts
                .Where(b => b.Title.Contains(term))
                .OrderBy(b => b.Title)
                .ToList();
        }
        public void Update(int i, string title)
        {
            var post = _context.Posts.Find(i);
            post.Title = title;
            _context.SaveChanges();
        }
        public void Delete(int i)
        {
            var post = _context.Posts.Find(i);
            _context.Remove(post);
            _context.SaveChanges();

        }
    }
}
