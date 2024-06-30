using Microsoft.AspNetCore.Mvc;
using static APIrestaurante.Models.Pedidosmodel;

namespace APIrestaurante.Controllers
{

    [ApiController]
    [Route("Cliente")]
    public class Pedidos : ControllerBase
    {
        [HttpGet]
        [Route("BuscarCliente")]
        public dynamic DatosCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id ="1",
                    Nombre = "jose",
                    Npedido = "12",
                    Detallespedidos = "Pollo frito",
                    Costopedido = "1000",
                    Fechapedido = "8-9-2024"
                },

                new Cliente
                {
                    Id ="2",
                    Nombre = "maria",
                    Npedido = "8",
                    Detallespedidos = "Pollo frito",
                    Costopedido = "1000",
                    Fechapedido = "8-9-2024"
                }
            };

            return clientes;
        }

        // cuando el metodo cambia obtiene parametros el return cambia ya que le in dicamos que hay unas nuevas instancias.
        [HttpGet]
        [Route("BuscarClienteID")]
        public dynamic ClientID(string _id, string _Nombre, string _Npedido, string _Detallespedido, string _Costopedido, string _Fechapedido)
        {
            return new Cliente
            {
                Id = _id,
                Nombre = _Nombre,
                Npedido = _Npedido,
                Detallespedidos = _Detallespedido,
                Costopedido = _Costopedido,
                Fechapedido = _Fechapedido
            };
        }


        [HttpPost]
        [Route("GuardarCliente")]

        public dynamic GuardarCliente(Cliente cliente)
        {
            cliente.Id = "3";

            return new
            {
                success = true,
                message = "cliente Guardado",
                resuly = cliente
            };
        }

        [HttpPost]
        [Route("EliminarCliente")]

        public dynamic EliminarPedidos(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "authorization")
                .FirstOrDefault().Value;

            return new
            {
                success = true,
                message = "cliente eliminado",
                resuly = cliente
            };

        }

    }


}
