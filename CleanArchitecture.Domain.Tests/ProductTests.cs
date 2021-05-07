using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductTests
    {
        [Fact(DisplayName = "Instantiate Product With Valid State")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithValidParameters_ReturnsValidProductObject()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Instantiate Product With Invalid Id")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithInvalidId_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Instantiate Product With Short Name")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name too short. Minimum 3 characters.");
        }

        [Fact(DisplayName = "Instantiate Product With Long Image Name")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithLongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Image too long. Maximum 250 characters.");
        }

        [Fact(DisplayName = "Instantiate Product With Null Image Name (No DomainException)")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Instantiate Product With Null Image Name (No NullReferenceException)")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action
                .Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Instantiate Product With Empty Image Name")]
                [Trait("Product", "Instantiate")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Instantiate Product With Invalid Price")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Instantiate Product With Invalid Stock")]
        [Trait("Product", "Instantiate")]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, -5, "product image");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }
    }
}
