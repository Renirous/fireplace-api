﻿using FireplaceApi.Api.Extensions;
using FireplaceApi.Api.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FireplaceApi.Api.Controllers
{
    public class VotePostInputRouteParameters
    {
        [Required]
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }

    [SwaggerSchemaFilter(typeof(TypeExampleProvider))]
    public class VotePostInputBodyParameters
    {
        [Required]
        public bool? IsUpvote { get; set; }

        public static IOpenApiAny Example { get; } = new OpenApiObject
        {
            [nameof(IsUpvote).ToSnakeCase()] = new OpenApiBoolean(true),
        };
    }

    public class ToggleVoteForPostInputRouteParameters
    {
        [Required]
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }

    public class DeleteVoteForPostInputRouteParameters
    {
        [Required]
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }
}