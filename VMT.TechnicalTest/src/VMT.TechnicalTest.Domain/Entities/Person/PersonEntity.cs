using VMT.TechnicalTest.Domain.Base;
using VMT.TechnicalTest.Domain.ValueObjects.Dni;

namespace VMT.TechnicalTest.Domain.Entities.Person
{
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [DniValidatorAttributeValueObject]
        public string Dni { get; set; }
        public string Birthdate { get; set; }
    }
}