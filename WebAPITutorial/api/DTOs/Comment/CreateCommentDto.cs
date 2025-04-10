using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "Title must be minimum 5 characters")]
        [MaxLength(280, ErrorMessage = "Title must be maximum 280 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage = "Content must be minimum 5 characters")]
        [MaxLength(280, ErrorMessage = "Content must be maximum 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}