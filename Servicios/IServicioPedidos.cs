using pedidos.Modelos; 
using System.Collections.Generic; 
using System; 

namespace pedidos.Servicios
{
    public interface IServicioPedidos
    {
        Guid ObtenerIdInstancia();
        void AgregarPedido(Pedido pedido);
        List<Pedido> ObtenerPedidos(); 
        int ContarPedidos();
    }
}