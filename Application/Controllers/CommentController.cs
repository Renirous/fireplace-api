﻿using FireplaceApi.Application.Converters;
using FireplaceApi.Application.Dtos;
using FireplaceApi.Domain.Extensions;
using FireplaceApi.Domain.Models;
using FireplaceApi.Domain.Services;
using FireplaceApi.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace FireplaceApi.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/comments")]
[Produces("application/json")]
public class CommentController : ApiController
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    /// List post comments.
    /// </summary>
    /// <returns>List of post comments</returns>
    /// <response code="200">Post comments was successfully retrieved.</response>
    [HttpGet("/v{version:apiVersion}/posts/{id}/comments")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(QueryResultDto<CommentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<QueryResultDto<CommentDto>>> ListPostCommentsAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] ListPostCommentsInputRouteDto inputRouteDto,
        [FromQuery] ListPostCommentsInputQueryDto inputQueryDto)
    {
        var queryResult = await _commentService.ListPostCommentsAsync(
            inputRouteDto.PostId, inputQueryDto.Sort, requestingUser);
        var queryResultDto = queryResult.ToDto();
        return queryResultDto;
    }

    /// <summary>
    /// Search for comments.
    /// </summary>
    /// <returns>List of comments</returns>
    /// <response code="200">The comments was successfully retrieved.</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(QueryResultDto<CommentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<QueryResultDto<CommentDto>>> ListCommentsAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromQuery] ListCommentsInputQueryDto inputQueryDto)
    {
        var queryResult = new QueryResult<Comment>(null, null);
        if (!inputQueryDto.EncodedIds.IsNullOrEmpty())
        {
            queryResult.Items = await _commentService.ListCommentsByIdsAsync(
                inputQueryDto.Ids, inputQueryDto.Sort, requestingUser);
        }

        var queryResultDto = queryResult.ToDto();
        return queryResultDto;
    }

    /// <summary>
    /// List self comments.
    /// </summary>
    /// <returns>List of self comments</returns>
    /// <response code="200">The comments was successfully retrieved.</response>
    [HttpGet("me")]
    [ProducesResponseType(typeof(QueryResultDto<CommentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<QueryResultDto<CommentDto>>> ListSelfCommentsAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromQuery] ListSelfCommentsInputQueryDto inputQueryDto)
    {
        var queryResult = await _commentService.ListSelfCommentsAsync(requestingUser,
            inputQueryDto.Sort);
        var queryResultDto = queryResult.ToDto();
        return queryResultDto;
    }

    /// <summary>
    /// List child comments.
    /// </summary>
    /// <returns>List of child comments</returns>
    /// <response code="200">Child comments was successfully retrieved.</response>
    [AllowAnonymous]
    [HttpGet("{id}/comments")]
    [ProducesResponseType(typeof(QueryResultDto<CommentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<QueryResultDto<CommentDto>>> ListChildCommentsAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] ListChildCommentsInputRouteDto inputRouteDto,
        [FromQuery] ListChildCommentsInputQueryDto inputQueryDto)
    {
        var queryResult = await _commentService.ListChildCommentsAsync(
            inputRouteDto.ParentId, inputQueryDto.Sort, requestingUser);
        var queryResultDto = queryResult.ToDto();
        return queryResultDto;
    }

    /// <summary>
    /// Get a single comment by id.
    /// </summary>
    /// <returns>Requested comment</returns>
    /// <response code="200">The comment was successfully retrieved.</response>
    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> GetCommentByIdAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] GetCommentByIdInputRouteDto inputRouteDto,
        [FromQuery] GetCommentInputQueryDto inputQueryDto)
    {
        var comment = await _commentService.GetCommentByIdAsync(inputRouteDto.Id,
                inputQueryDto.IncludeAuthor, inputQueryDto.IncludePost,
                requestingUser);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Create a comment which reply to a post.
    /// </summary>
    /// <returns>Created comment</returns>
    /// <response code="200">Returns the newly created item</response>
    [HttpPost("/v{version:apiVersion}/posts/{id}/comments")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> ReplyToPostAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] ReplyToPostInputRouteDto inputRouteDto,
        [FromBody] ReplyToPostInputBodyDto inputBodyDto)
    {
        var comment = await _commentService.ReplyToPostAsync(
            requestingUser, inputRouteDto.PostId,
            inputBodyDto.Content);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Create a comment which reply to a comment.
    /// </summary>
    /// <returns>Created comment</returns>
    /// <response code="200">Returns the newly created item</response>
    [HttpPost("{id}/comments")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> ReplyToCommentAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] ReplyToCommentInputRouteDto inputRouteDto,
        [FromBody] ReplyToCommentInputBodyDto inputBodyDto)
    {
        var comment = await _commentService.ReplyToCommentAsync(
            requestingUser, inputRouteDto.ParentCommentId,
            inputBodyDto.Content);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Create a vote for the comment.
    /// </summary>
    /// <returns>Voted comment</returns>
    /// <response code="200">Returns the Voted comment</response>
    [HttpPost("{id}/votes")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> VoteCommentAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] VoteCommentInputRouteDto inputRouteDto,
        [FromBody] VoteCommentInputBodyDto inputBodyDto)
    {
        var comment = await _commentService.VoteCommentAsync(
            requestingUser, inputRouteDto.Id, inputBodyDto.IsUpvote);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Toggle your vote for the comment.
    /// </summary>
    /// <returns>The comment</returns>
    /// <response code="200">Returns the comment</response>
    [HttpPatch("{id}/votes/me")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> ToggleVoteForCommentAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] ToggleVoteForCommentInputRouteDto inputRouteDto)
    {
        var comment = await _commentService.ToggleVoteForCommentAsync(
            requestingUser, inputRouteDto.Id);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Delete your vote for the comment.
    /// </summary>
    /// <returns>The comment</returns>
    /// <response code="200">Returns the comment</response>
    [HttpDelete("{id}/votes/me")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> DeleteVoteForCommentAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] DeleteVoteForCommentInputRouteDto inputRouteDto)
    {
        var comment = await _commentService.DeleteVoteForCommentAsync(
            requestingUser, inputRouteDto.Id);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Update a single comment by id.
    /// </summary>
    /// <returns>Updated comment</returns>
    /// <response code="200">The comment was successfully updated.</response>
    [HttpPatch("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<CommentDto>> PatchCommentByIdAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] PatchCommentByIdInputRouteDto inputRouteDto,
        [FromBody] PatchCommentInputBodyDto inputBodyDto)
    {
        var comment = await _commentService.PatchCommentByIdAsync(requestingUser,
            inputRouteDto.Id, inputBodyDto.Content);
        var commentDto = comment.ToDto();
        return commentDto;
    }

    /// <summary>
    /// Delete a single comment by id.
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="200">The comment was successfully deleted.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCommentByIdAsync(
        [BindNever][FromHeader] User requestingUser,
        [FromRoute] DeleteCommentByIdInputRouteDto inputRouteDto)
    {
        await _commentService.DeleteCommentByIdAsync(requestingUser,
            inputRouteDto.Id);
        return Ok();
    }
}
