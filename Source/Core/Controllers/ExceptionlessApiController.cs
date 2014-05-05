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
using System.Linq;
using System.Web.Http;
using Exceptionless.Core.Authorization;
using Exceptionless.Core.Extensions;
using Exceptionless.Core.Web;
using Exceptionless.Core.Web.Results;
using Exceptionless.Models;

namespace Exceptionless.Core.Controllers {
    [RequireHttpsExceptLocal]
    public class ExceptionlessApiController : ApiController {
        protected const int API_CURRENT_VERSION = 2;
        protected const string API_PREFIX = "api/v2/";

        protected Tuple<DateTime, DateTime> GetDateRange(DateTime? starTime, DateTime? endTime) {
            if (starTime == null)
                starTime = DateTime.MinValue;

            if (endTime == null)
                endTime = DateTime.MaxValue;

            return starTime < endTime ? new Tuple<DateTime, DateTime>(starTime.Value, endTime.Value) : new Tuple<DateTime, DateTime>(endTime.Value, starTime.Value);
        }

        public User ExceptionlessUser {
            get { return Request.GetUser(); }
        }

        public Project Project {
            get { return Request.GetProject(); }
        }

        public AuthType AuthType {
            get { return User.GetAuthType(); }
        }

        public bool CanAccessOrganization(string organizationId) {
            return Request.CanAccessOrganization(organizationId);
        }

        public bool IsInOrganization(string organizationId) {
            return Request.IsInOrganization(organizationId);
        }

        public IEnumerable<string> GetAssociatedOrganizationIds() {
            return Request.GetAssociatedOrganizationIds();
        }

        public string GetDefaultOrganizationId() {
            return Request.GetDefaultOrganizationId();
        }

        protected int GetPageSize(int pageSize) {
            if (pageSize < 1)
                pageSize = 10;
            else if (pageSize > 100)
                pageSize = 100;

            return pageSize;
        }

        protected int GetSkip(int currentPage, int pageSize) {
            int skip = (currentPage - 1) * pageSize;
            if (skip < 0)
                skip = 0;

            return skip;
        }

        public PlanLimitReachedActionResult PlanLimitReached(string message) {
            return new PlanLimitReachedActionResult(message, Request);
        }

        public NotImplementedActionResult NotImplemented(string message) {
            return new NotImplementedActionResult(message, Request);
        }
    }
}