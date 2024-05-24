using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.DTOs;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace BlogApp.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                UserId = p.UserId,
                CategoryId = p.CategoryId
            });
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return null;

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                CategoryId = post.CategoryId
            };
        }

        public async Task<PostDto> CreatePostAsync(PostCreateDto postDto)
        {
            var newPost = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = postDto.UserId,
                CategoryId = postDto.CategoryId
            };

            await _postRepository.AddAsync(newPost);

            return new PostDto
            {
                Id = newPost.Id,
                Title = newPost.Title,
                Content = newPost.Content,
                CreatedAt = newPost.CreatedAt,
                UserId = newPost.UserId,
                CategoryId = newPost.CategoryId
            };
        }

        public async Task<PostDto> UpdatePostAsync(int id, PostUpdateDto postDto)
        {
            var existingPost = await _postRepository.GetByIdAsync(id);
            if (existingPost == null)
                return null;

            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            await _postRepository.UpdateAsync(existingPost);

            return new PostDto
            {
                Id = existingPost.Id,
                Title = existingPost.Title,
                Content = existingPost.Content,
                CreatedAt = existingPost.CreatedAt,
                UpdatedAt = existingPost.UpdatedAt,
                UserId = existingPost.UserId,
                CategoryId = existingPost.CategoryId
            };
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return false;

            await _postRepository.DeleteAsync(post);

            return true;
        }
    }
}