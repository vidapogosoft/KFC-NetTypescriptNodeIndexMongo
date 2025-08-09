using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using mongorest.models;
using mongorest.services;

namespace mongorest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _prodServices;

        public ProductosController (ProductosService prodSVC)
        {
            _prodServices = prodSVC;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<List<productos>>Get()
        {
            return await _prodServices.GetProductos();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<productos>> GetObject(string id)
        {
            var prod = await _prodServices.GetProductosObejct(id);

            if(prod is null)
            {
                return NotFound();
            }

            return Ok(prod);
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post(productos newprod)
        {
            await _prodServices.CreateProduct(newprod);
            
            return CreatedAtAction(nameof(Get), new {id = newprod.Id}, newprod);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, productos updprod)
        {
            var prod = await _prodServices.GetProductosObejct(id);

            if (prod is null)
            {
                return NotFound();
            }

            updprod.Id = prod.Id;

            await _prodServices.UpdateProduct(id, updprod);

            return Ok(prod);

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var prod = await _prodServices.GetProductosObejct(id);

            if (prod is null)
            {
                return NotFound();
            }

            await _prodServices.RemoveProduct(id);

            return NoContent();

        }
    }
}
