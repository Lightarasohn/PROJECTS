using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;
using Azure.Identity;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
                CreatedBy = commentModel.AppUser!.UserName
            };
        }
        public static CommentWithStockDto ToCommentWithStockDto(this Comment commentModel)
        {
            return new CommentWithStockDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
                Stock = commentModel.stock!.ToStockDto(),
                CreatedBy = commentModel.AppUser!.UserName ?? ""
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId, AppUser user)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
                AppUser = user,
                AppUserId = user.Id
            };
        }
    }
}