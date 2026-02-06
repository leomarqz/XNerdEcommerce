
using System.Runtime.Serialization;

namespace XNerd.Ecommerce.Domain.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pendiente")]
        Pending,
        
        [EnumMember(Value = "El Pago fue recibido")]
        Paid,
        
        [EnumMember(Value = "El producto ha sido enviado")]
        Shipped,
        
        [EnumMember(Value = "El producto ha sido entregado")]
        Delivered,

        [EnumMember(Value = "El pedido ha sido cancelado")]
        Cancelled,

        [EnumMember(Value = "Error en el procesamiento del pedido")]
        Error
    }
}