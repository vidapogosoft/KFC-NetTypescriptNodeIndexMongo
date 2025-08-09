using BackendTaller1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entidades.Database;

namespace BackendTaller1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrders _orders;

        public OrdersController(IOrders orders)
        {
            _orders = orders;
        }

        // GET: api/<OrdersController>
        [HttpGet("ordenes")]
        public IActionResult ConsultarOrdenes()
        {
            return Ok(_orders.ConsultarOrdenes());
        }

        // GET api/<OrdersController>/5
        [HttpGet("orden/{idorder}")]
        public IActionResult ConsultarOrden(int idorder)
        {
            return Ok(_orders.ConsultarOrden(idorder));
        }

        [HttpGet("ordenobject/{idorder}")]
        public IActionResult ConsultarOrdenById(int idorder)
        {
            return Ok(_orders.ConsultarOrdenById(idorder));
        }

        [AllowAnonymous]
        [HttpGet("ordendetalle/{idorder}")]
        public IActionResult ConsultarOrdenDetalle(int idorder)
        {
            return Ok(_orders.ConsultarOrdenDetalle(idorder));
        }

        // POST api/<OrdersController>
        [HttpPost("guaradarorder")]
        public IActionResult GuardarOrden([FromBody] OrderPedido item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error en las propiedades del modelo de datos");
                }

                _orders.GuardarOrden(item);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(item.IdOrderCab);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
