

namespace Domain;

public class Adress{
    public int Id {get; set;}
    public string City {get; set;}
    public string Street {get; set;}
    public string? ZipCode {get; set;}
    public int StudentId {get; set;}
    public Student Student {get; set;}
}
