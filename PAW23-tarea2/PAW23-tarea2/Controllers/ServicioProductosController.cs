using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAW23_tarea2.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ProductosController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        return await _dbContext.Productos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _dbContext.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {
        _dbContext.Productos.Add(producto);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        if (id != producto.ProductoId)
        {
            return BadRequest();
        }

        _dbContext.Entry(producto).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _dbContext.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _dbContext.Productos.Remove(producto);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductoExists(int id)
    {
        return _dbContext.Productos.Any(e => e.ProductoId == id);
    }
}
