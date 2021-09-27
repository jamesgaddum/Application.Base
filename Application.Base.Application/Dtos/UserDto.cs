using System;
using Application.Base.Domain;

namespace Application.Base.Application
{
    public class UserDto
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public static UserDto MapFrom(User user)
        {
            return new UserDto
            {
                Id = user.Id.Value,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
