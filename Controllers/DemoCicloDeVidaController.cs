
using Microsoft.AspNetCore.Mvc;
using pedidos.Modelos;
using pedidos.Servicios;
using System; 

namespace pedidos.Controladores
{
    [ApiController]
    [Route("api")]
    public class DemoCicloDeVidaController : ControllerBase
    {
        private readonly IServicioPedidosTransitorio _servicioTransitorio;
        private readonly IServicioPedidosSingleton _servicioSingleton;
        private readonly IServicioPedidosDelimitado _servicioDelimitado; 

        public DemoCicloDeVidaController(
            IServicioPedidosTransitorio servicioTransitorio,
            IServicioPedidosDelimitado servicioDelimitado,
            IServicioPedidosSingleton servicioSingleton)
        {
            _servicioTransitorio = servicioTransitorio;
            _servicioDelimitado = servicioDelimitado; 
            _servicioSingleton = servicioSingleton;
        }

        [HttpGet("transitorio/pedidos")]
        public IActionResult ObtenerPedidosTransitorios()
        {
            return Ok(_servicioTransitorio.ObtenerPedidos());
        }

        [HttpPost("transitorio/pedidos")]
        public IActionResult AgregarPedidoTransitorio([FromBody] Pedido pedido)
        {
            return Ok(new { 
                IdInstancia = _servicioTransitorio.ObtenerIdInstancia(), 
                Conteo = _servicioTransitorio.ContarPedidos() 
            });
        }
        [HttpGet("delimitado/pedidos")]
        public IActionResult ObtenerPedidosDelimitados()
        {

            return Ok(_servicioDelimitado.ObtenerPedidos());
        }

        [HttpPost("delimitado/pedidos")]
        public IActionResult AgregarPedidoDelimitado([FromBody] Pedido pedido)
        {
            _servicioDelimitado.AgregarPedido(pedido); 
            return Ok(new { 
                IdInstancia = _servicioDelimitado.ObtenerIdInstancia(), 
                Conteo = _servicioDelimitado.ContarPedidos() 
            });
        }
        [HttpGet("singleton/pedidos")]
        public IActionResult ObtenerPedidosSingleton()
        {
            return Ok(_servicioSingleton.ObtenerPedidos());
        }

        [HttpPost("singleton/pedidos")]
        public IActionResult AgregarPedidoSingleton([FromBody] Pedido pedido)
        {
            _servicioSingleton.AgregarPedido(pedido);
            return Ok(new { 
                IdInstancia = _servicioSingleton.ObtenerIdInstancia(), 
                Conteo = _servicioSingleton.ContarPedidos()
            });
        }
    }
}