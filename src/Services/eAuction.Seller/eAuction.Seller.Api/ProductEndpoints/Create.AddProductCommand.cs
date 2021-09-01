using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eAuction.Seller.Api.ProductEndpoints
{
    public class AddProductCommand
    {
        public const string ROUTE = "/e-auction/api/v1/seller/add-product";

        [Required]
        public ProductModel Product { get; set; }
        [Required]
        public SellerModel Seller { get; set; }
    }

    public class ProductModel : IValidatableObject
    {
        private List<string> _categories = new List<string> { "Painting", "Sculptor", "Ornament" };
        [Required, StringLength(maximumLength: 30, ErrorMessage = "Product Name is not null", MinimumLength = 5)]
        public string ProductName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string DetailedDescription { get; set; }
        [Required]
        public string Category { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Starting price should be a number.")]
        public string StartingPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (!_categories.Contains(Category))
                results.Add(new ValidationResult("Invalid Category.", new[] { nameof(Category) }));

            if (BidEndDate > DateTime.Now)
                results.Add(new ValidationResult("Bid end date should be a future date.", new[] { nameof(BidEndDate) }));

            return results;
        }
    }

    public class SellerModel
    {
        [Required, StringLength(maximumLength: 30, ErrorMessage = "First Name is not null", MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required, StringLength(maximumLength: 25, ErrorMessage = "Last Name is not null", MinimumLength = 5)]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Pin { get; set; }
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }


}
