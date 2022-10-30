using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnnotationsDemo.Models;

[Table("PublicSchoolStudent")]
[Index(nameof(School))]
public class Student {
    [Key]
    [Column(Order = 1)]
    public int StudentNumber { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(30, ErrorMessage = "{0} must be between {2} & {1} characters."), MinLength(2)]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(30, ErrorMessage = "{0} cannot exceed {1} characters.")]
    // Allow up to 40 uppercase and lowercase 
    // characters. Use custom error.
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = "Only letters allowed.")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [NotMapped]
    public string FullName {
        get {
            return $"{FirstName} {LastName}";
        }
    }

    [Key]
    [Column(Order = 2)]
    [MaxLength(60)]
    [MinLength(5)]
    public string? School { get; set; }

    [Column("Note", TypeName = "NTEXT")]
    public String? Comment { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Display(Name = "Created")]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateCreated { get; set; }

    [Range(10, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [Display(Name = "Weight in Lbs.")]
    public int Weight;

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Compare("Email")]
    [Display(Name = "Confirm Email Address.")]
    [DataType(DataType.EmailAddress)]
    public string? EmailConfirm { get; set; }

    [ScaffoldColumn(false)]
    public string? StudentPhotoFileName;
}
