using pedidos.Modelos;
using System.Collections.Generic;
using System;

namespace pedidos.Servicios
{
    public class ServicioPedidos : IServicioPedidosTransitorio, IServicioPedidosDelimitado, IServicioPedidosSingleton 
    {
        private readonly Guid _idInstancia;
        private readonly List<Pedido> _pedidos; 

        public ServicioPedidos()
        {
            _idInstancia = Guid.NewGuid();
            _pedidos = new List<Pedido>(); 
            Console.WriteLine($"nueva instancia creada: {_idInstancia}");
        }

        public void AgregarPedido(Pedido pedido)
        {
            _pedidos.Add(pedido); 
        }

        public List<Pedido> ObtenerPedidos()
        {
            return _pedidos; 
        }

        public int ContarPedidos()
        {
            return _pedidos.Count;
        }

        public Guid ObtenerIdInstancia()
        {
            return _idInstancia;
        }
    }
}