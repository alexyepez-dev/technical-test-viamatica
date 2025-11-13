using VMT.TechnicalTest.Domain.Base;
using VMT.TechnicalTest.Domain.ValueObjects.Username;

namespace VMT.TechnicalTest.Domain.Entities.User
{
    public class UserEntity : BaseEntity
    {
        [UsernameValidatorAttributeValueObject]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}