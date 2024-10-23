using System.ComponentModel.DataAnnotations;

public class PostContactAndPersonalDataDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "DDD is required.")]
    [Range(11, 99, ErrorMessage = "DDD must be a valid Brazilian DDD between 11 and 99.")]
    public string DDD { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    [RegularExpression(@"^\d{8,9}$", ErrorMessage = "Phone must be 8 or 9 digits long.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }
}
