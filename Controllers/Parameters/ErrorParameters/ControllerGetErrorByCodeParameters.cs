﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Any;
using GamingCommunityApi.Enums;
using GamingCommunityApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GamingCommunityApi.Controllers.Parameters.ErrorParameters
{
    public class ControllerGetErrorByCodeInputRouteParameters
    {
        [Required]
        [FromRoute(Name = "code")]
        public int? Code { get; set; }
    }

    [BindNever]
    public class ControllerGetErrorByCodeInputQueryParameters
    {

    }
}
