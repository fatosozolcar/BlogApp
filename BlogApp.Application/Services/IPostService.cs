using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.DTOs;

namespace BlogApp.Application.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<PostDto> CreatePostAsync(PostCreateDto postDto);
        Task<PostDto> UpdatePostAsync(int id, PostUpdateDto postDto);
        Task<bool> DeletePostAsync(int id);
    }
}