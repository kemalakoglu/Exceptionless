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
using System.Collections.ObjectModel;

namespace Exceptionless.Core.Models {
    public class User : IIdentity {
        public User() {
            IsActive = true;
            OAuthAccounts = new Collection<OAuthAccount>();
            Roles = new Collection<string>();
            OrganizationIds = new Collection<string>();
            EmailNotificationsEnabled = true;
        }

        /// <summary>
        /// Unique id that identifies an user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The organizations that the user has access to.
        /// </summary>
        public ICollection<string> OrganizationIds { get; set; }

        public string Password { get; set; }
        public string Salt { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime PasswordResetTokenExpiration { get; set; }
        public ICollection<OAuthAccount> OAuthAccounts { get; set; }

        /// <summary>
        /// Gets or sets the users Full Name.
        /// </summary>
        public string FullName { get; set; }

        public string EmailAddress { get; set; }
        public bool EmailNotificationsEnabled { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public string VerifyEmailAddressToken { get; set; }
        public DateTime VerifyEmailAddressTokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets the users active state.
        /// </summary>
        public bool IsActive { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}