﻿using FireplaceApi.Core.Enums;
using FireplaceApi.Core.Models;
using FireplaceApi.Core.Operators;
using FireplaceApi.Core.Validators;
using FireplaceApi.Core.ValueObjects;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireplaceApi.Core.Services
{
    public class CommentService
    {
        private readonly ILogger<CommentService> _logger;
        private readonly CommentValidator _commentValidator;
        private readonly CommentOperator _commentOperator;

        public CommentService(ILogger<CommentService> logger,
            CommentValidator commentValidator, CommentOperator commentOperator)
        {
            _logger = logger;
            _commentValidator = commentValidator;
            _commentOperator = commentOperator;
        }

        public async Task<Page<Comment>> ListSelfCommentsAsync(User requesterUser,
            PaginationInputParameters paginationInputParameters, SortType? sort)
        {
            await _commentValidator.ValidateListSelfCommentsInputParametersAsync(requesterUser,
                paginationInputParameters, sort);
            var page = await _commentOperator.ListSelfCommentsAsync(requesterUser,
                paginationInputParameters, sort);
            return page;
        }

        public async Task<Page<Comment>> ListPostCommentsAsync(User requesterUser,
            PaginationInputParameters paginationInputParameters, long postId,
            SortType? sort)
        {
            await _commentValidator.ValidateListPostCommentsInputParametersAsync(requesterUser,
                paginationInputParameters, postId, sort);
            var page = await _commentOperator.ListPostCommentsAsync(requesterUser,
                paginationInputParameters, postId, sort);
            return page;
        }

        public async Task<List<Comment>> ListChildCommentsAsync(User requesterUser,
            long parentCommentId)
        {
            await _commentValidator.ValidateListChildCommentsAsyncInputParametersAsync(
                requesterUser, parentCommentId);
            var page = await _commentOperator.ListChildCommentsAsync(requesterUser,
                parentCommentId);
            return page;
        }

        public async Task<Comment> GetCommentByIdAsync(User requesterUser, long? id,
            bool? includeAuthor, bool? includePost)
        {
            await _commentValidator.ValidateGetCommentByIdInputParametersAsync(
                requesterUser, id, includeAuthor, includePost);
            var comment = await _commentOperator.GetCommentByIdAsync(id.Value,
                includeAuthor.Value, includePost.Value);
            return comment;
        }

        public async Task<Comment> ReplyToPostAsync(User requesterUser, long postId,
            string content)
        {
            await _commentValidator.ValidateReplyToPostInputParametersAsync(
                requesterUser, postId, content);
            return await _commentOperator.ReplyToPostAsync(requesterUser,
                postId, content);
        }

        public async Task<Comment> ReplyToCommentAsync(User requesterUser,
            long commentId, string content)
        {
            await _commentValidator.ValidateReplyToCommentInputParametersAsync(
                requesterUser, commentId, content);
            return await _commentOperator.ReplyToCommentAsync(requesterUser,
                commentId, content);
        }

        public async Task<Comment> PatchCommentByIdAsync(User requesterUser,
            long? id, string content)
        {
            await _commentValidator
                .ValidatePatchCommentByIdInputParametersAsync(requesterUser,
                    id, content);
            var comment = await _commentOperator.PatchCommentByIdAsync(
                id.Value, content);
            return comment;
        }

        public async Task DeleteCommentByIdAsync(User requesterUser, long? id)
        {
            await _commentValidator
                .ValidateDeleteCommentByIdInputParametersAsync(requesterUser, id);
            await _commentOperator
                .DeleteCommentByIdAsync(id.Value);
        }
    }
}