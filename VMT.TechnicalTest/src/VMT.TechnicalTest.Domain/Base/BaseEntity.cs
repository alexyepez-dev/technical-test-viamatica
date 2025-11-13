namespace VMT.TechnicalTest.Domain.Base
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}