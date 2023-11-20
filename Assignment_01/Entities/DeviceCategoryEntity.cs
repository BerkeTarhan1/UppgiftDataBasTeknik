using System.ComponentModel.DataAnnotations;

namespace Assignment_01.Entities;

public class DeviceCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
