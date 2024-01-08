using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Models;

using Microsoft.AspNetCore.Cors;

namespace MiWebAPI.Controllers
{
    [ApiController]
    [EnableCors("ReglasCors")]
    [Route("ClienteAPI")]
    public class APIClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public dynamic listarAPICliente()
        {
            //todo el codigo

            // return new

            //{
            //  nombre = "jesus",
            // edad = "19",
            //};

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "cliente1@gmail.com",
                    edad = "19",
                    nombre = "Dasilva"
                },
                new Cliente
                {
                    id = "2",
                    correo = "cliente2@gmail.com",
                    edad = "20",
                    nombre = "Paulinho"
                },

            };

            return clientes;
        }

        [HttpGet]
        [Route("Listarid")]
        public dynamic listarAPIClienteId(int _id)
        {

            //obtienes el cliente
            return new Cliente
            {
                id = _id.ToString(),
                correo = "cliente1@gmail.com",
                edad = "19",
                nombre = "Dasilva"
            };
        }     
         
        [HttpPost]
        [Route("Guardar")]
        public dynamic guardarAPICliente(Cliente cliente)
        {
            //Guardar y le asignas un cliente
            cliente.id = "3";

            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };
        }
    }
}
