﻿#region Copyright 2015 Exceptionless

// This program is free software: you can redistribute it and/or modify it 
// under the terms of the GNU Affero General Public License as published 
// by the Free Software Foundation, either version 3 of the License, or 
// (at your option) any later version.
// 
//     http://www.gnu.org/licenses/agpl-3.0.html

#endregion

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Exceptionless.Api.Utility {
    internal class LowercaseHttpRoute : HttpRoute {
        public LowercaseHttpRoute() {}

        public LowercaseHttpRoute(string routeTemplate)
            : base(routeTemplate) {}

        public LowercaseHttpRoute(string routeTemplate, HttpRouteValueDictionary defaults)
            : base(routeTemplate, defaults) {}

        public LowercaseHttpRoute(string routeTemplate, HttpRouteValueDictionary defaults, HttpRouteValueDictionary constraints)
            : base(routeTemplate, defaults, constraints) {}

        public LowercaseHttpRoute(string routeTemplate, HttpRouteValueDictionary defaults, HttpRouteValueDictionary constraints, HttpRouteValueDictionary dataTokens)
            : base(routeTemplate, defaults, constraints, dataTokens) {}

        public override IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values) {
            IHttpVirtualPathData virtualPath1 = base.GetVirtualPath(request, values);
            if (virtualPath1 != null) {
                string virtualPath2 = virtualPath1.VirtualPath;
                int num = virtualPath2.LastIndexOf("?", StringComparison.Ordinal);
                if (num != 0) {
                    if (num > 0)
                        return new HttpVirtualPathData(this, virtualPath2.Substring(0, num).ToLowerInvariant() + virtualPath2.Substring(num));

                    return new HttpVirtualPathData(this, virtualPath1.VirtualPath.ToLowerInvariant());
                }
            }

            return virtualPath1;
        }
    }
}