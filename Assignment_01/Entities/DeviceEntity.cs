using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_01.Entities;

internal class DeviceEntity
{
    [Key]
    public int Id { get; set; }
    public string DeviceName { get; set; } = null!;
    public string DeviceDescription { get; set; } = null!;

    [Column(TypeName ="money")]
    public decimal DevicePrice { get; set; }
    public int CurrencyUnitId { get; set; }
    public CurrencyUnitEntity CurrencyUnit { get; set; } = null!;

    public int DeviceCategoryId { get; set; }
    public DeviceCategoryEntity DeviceCategory { get; set; } = null!;
}
