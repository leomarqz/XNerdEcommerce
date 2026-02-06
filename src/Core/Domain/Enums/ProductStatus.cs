using System.Runtime.Serialization;

namespace XNerd.Ecommerce.Domain.Enums;
public enum ProductStatus
{
    [EnumMember(Value = "Producto Inactivo")]
    Inactive = 0,
    [EnumMember(Value = "Producto Activo")]
    Active = 1
}