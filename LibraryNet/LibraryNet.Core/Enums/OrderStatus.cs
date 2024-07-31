using System.ComponentModel;

namespace LibraryNet.Core.Enums
{
    public enum OrderStatus
    {
        [Description("Aguardando Pagamento")]
        AwaitingPayment,
        [Description("Aprovado")]
        Approved,
        [Description("Aguardando Envio")]
        WaitingSend,
        [Description("Enviado")]
        Dispatched,
        [Description("Entregue")]
        Delivered,
        [Description("Cancelado")]
        Canceled
    }
}
