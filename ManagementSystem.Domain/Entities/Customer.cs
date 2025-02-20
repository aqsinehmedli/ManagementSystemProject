using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entities;

public class Customer : BaseEntity
{ 
    public string Name { get; set; }
    public string Email { get; set; }
}
