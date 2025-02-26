using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IAccountRepository _accountRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo,
        IAccountRepository accountRepository)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _accountRepo = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();
            var commentsDto = comments.Select(x => x.ToCommentWithStockDto());
            
            return Ok(commentsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment? comment = await _commentRepo.GetByIdAsync(id);

            if(comment == null)
                return NotFound();
            
            return Ok(comment.ToCommentWithStockDto());
        }

        [HttpPost("{stockId:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commnetModel)
        {
            var username = User.GetUsername();
            var user = await _accountRepo.FindUserByUsernameTokenAsync(username);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _stockRepo.StockExistAsync(stockId))
                return BadRequest("Stock does not exist");
            
            Comment? comment = commnetModel.ToCommentFromCreate(stockId, user!);
            await _commentRepo.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new {comment.Id}, comment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment? comment = await _commentRepo.UpdateAsync(id, updateDto);

            if(comment == null)
                return NotFound();
            
            return Ok(comment.ToCommentWithStockDto());
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment? comment = await _commentRepo.DeleteAsync(id);

            if(comment == null)
                return NotFound();

            return Ok();
        }

    }
}