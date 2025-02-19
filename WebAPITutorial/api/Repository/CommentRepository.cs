using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(i => i.Id == id);

            if(comment == null)
                return null;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(x => x.stock).ToListAsync();
        }
        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(x => x.stock).FirstOrDefaultAsync(i => i.Id == id);
            
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateDto)
        {
            var comment = await _context.Comments.Include(x => x.stock).FirstOrDefaultAsync(i => i.Id == id);
            if(comment == null)
                return null;
            
            comment.Title = updateDto.Title;
            comment.Content = updateDto.Content;

            await _context.SaveChangesAsync();
            return comment;
        }
    }
}