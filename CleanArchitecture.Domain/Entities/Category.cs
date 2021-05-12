using CleanArchitecture.Domain.Exceptions;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            ValidateDomain(name);
            ValidateId(id);

            Name = name;
            Id = id;
        }

        public Category(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name must not be null or empty");
            DomainExceptionValidation.When(name.Length < 3, "Name too short. Minimum 3 characters");
        }
    }
}
