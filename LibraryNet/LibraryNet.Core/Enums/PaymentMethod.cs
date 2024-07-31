using System.ComponentModel;

namespace LibraryNet.Core.Enums
{
    public enum PaymentMethod
    {
        [Description("Cartão de Crédito")]
        CreditCard,
        [Description("Cartão de Débito")]
        DebitCard,
        [Description("Pay Pal")]
        PayPal,
        [Description("Pix")]
        Pix
    }
}
