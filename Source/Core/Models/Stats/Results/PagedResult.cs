﻿#region Copyright 2014 Exceptionless

// This program is free software: you can redistribute it and/or modify it 
// under the terms of the GNU Affero General Public License as published 
// by the Free Software Foundation, either version 3 of the License, or 
// (at your option) any later version.
// 
//     http://www.gnu.org/licenses/agpl-3.0.html

#endregion

using System;
using System.Collections.Generic;

namespace Exceptionless.Core.Models.Stats {
    public class PagedResult<T> where T : class {
        public PagedResult(List<T> results = null, long? totalCount = null) {
            Results = results ?? new List<T>();
            TotalCount = totalCount;
        }

        public List<T> Results { get; set; }
        public long? TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}