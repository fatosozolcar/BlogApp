// Application/Services/BlogService.cs
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Application.Services
{
    public class BlogService
    {
        private readonly IRepository<BlogPost> _repository;

        public BlogService(IRepository<BlogPost> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddBlogPostAsync(BlogPost blogPost)
        {
            return _repository.AddAsync(blogPost);
        }

        public Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            return _repository.UpdateAsync(blogPost);
        }

        public Task DeleteBlogPostAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
