﻿using GamingCommunityApi.Enums;
using GamingCommunityApi.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingCommunityApi.Models
{
    public class Global
    {
        public GlobalId Id { get; set; }
        public GlobalValues Values { get; set; }

        public Global(GlobalId id, GlobalValues values)
        {
            Id = id;
            Values = values ?? throw new ArgumentNullException(nameof(values));
        }

        public Global PureCopy() => new Global(Id, Values);

        public void RemoveLoopReferencing()
        {

        }
    }
}
