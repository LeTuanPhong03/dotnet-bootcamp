namespace Day07.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public Department() { }

    public Department(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
        Name = name;
    }
}
