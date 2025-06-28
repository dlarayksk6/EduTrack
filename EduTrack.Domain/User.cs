using EduTrack.Domain;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; } 

    [Required, StringLength(11, MinimumLength = 11)]
    public string TcNo { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = string.Empty; 

    public string? SchoolNumber { get; set; }  
    public string? PhoneNumber { get; set; }   
    public int? SchoolId { get; set; }
    public School? School { get; set; }

    public ICollection<ClassUser> ClassUsers { get; set; } = new List<ClassUser>();
}
