using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public void ValidateId(int id, bool isExternalId = false, string externalEntityName = null)
        {
            if (isExternalId)
                DomainExceptionValidation.When(id < 0, $"Invalid {externalEntityName} id value");

            DomainExceptionValidation.When(id < 0, "Invalid id value");
        }
    }
}
