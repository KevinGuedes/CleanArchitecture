using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            ValidateId(categoryId, true, "Category");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            ValidateId(id);
            ValidateId(categoryId, true, "Category");

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            ValidateId(categoryId, true, "Category");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private static void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Name too short. Minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Description too short. Minimum 4 characters.");


            DomainExceptionValidation.When(price < 0, "Invalid price value.");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            DomainExceptionValidation.When(image?.Length > 250, "Image too long. Maximum 250 characters.");
        }

        private void ValidateId(int id, bool isExternalId = false, string externalEntityName = null)
        {
            if(isExternalId)
                DomainExceptionValidation.When(id < 0, $"Invalid {externalEntityName} id value.");

            DomainExceptionValidation.When(id < 0, "Invalid id value.");
        }
    }
}
