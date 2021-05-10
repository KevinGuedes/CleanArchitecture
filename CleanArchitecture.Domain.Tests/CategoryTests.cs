using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryTests
    {
        [Fact(DisplayName = "Instantiate Category With Valid State")]
        [Trait("Category", "Instantiate")]
        public void CreateCateory_WithValidParameters_ReturnsValidCategoryObject()
        {
            Action action = () => new Category(1, "Category Name");
            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Instantiate Category With Invalid Id")]
        [Trait("Category", "Instantiate")]
        public void CreateCateory_WithInvalidId_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id value.");
        }

        [Fact(DisplayName = "Instantiate Category With Short Name")]
        [Trait("Category", "Instantiate")]
        public void CreateCateory_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name too short. Minimum 3 characters.");
        }

        [Fact(DisplayName = "Instantiate Category With Null Name")]
        [Trait("Category", "Instantiate")]
        public void CreateCateory_WithNullName_DomainExceptionNullName()
        {
            Action action = () => new Category(1, null);
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name must not be null or empty.");
        }

        [Fact(DisplayName = "Instantiate Category With Empty Name")]
        [Trait("Category", "Instantiate")]
        public void CreateCateory_WithEmptyName_DomainExceptionEmptyName()
        {
            Action action = () => new Category(1, "");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name must not be null or empty.");
        }
    }
}
