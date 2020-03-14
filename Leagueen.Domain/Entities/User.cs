﻿using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public Guid UserGuid { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public string ImageUrl { get; private set; }

        private User() { }

        public User(Guid userGuid, string email, string displayName, string imageUrl)
        {
            UserGuid = userGuid;
            Email = email;
            DisplayName = displayName;
            ImageUrl = imageUrl;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (UserGuid.Equals(Guid.Empty))
                throw new DomainException(Enums.ExceptionCode.UserGuidRequired);
            if (string.IsNullOrEmpty(Email))
                throw new DomainException(Enums.ExceptionCode.UserEmailRequired);
            if (string.IsNullOrEmpty(DisplayName))
                throw new DomainException(Enums.ExceptionCode.UserDisplayNameRequired);
        }
    }
}
