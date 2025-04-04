using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string? LastName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    
    //navigations
    public Adress Address { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }
}
