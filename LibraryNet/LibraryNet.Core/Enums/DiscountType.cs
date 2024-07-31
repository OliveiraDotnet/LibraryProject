using System.ComponentModel;

namespace LibraryNet.Core.Enums
{
    public enum DiscountType
    {
        [Description("Porcentagem")]
        Percentage,
        [Description("Valor moeda corrente")]
        CurrencyValue
    }
}
