[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ToDoItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/ToDoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
    {
        return await _context.ToDoItems.Where(i => !i.Deleted).ToListAsync();
    }

    // GET: api/ToDoItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
    {
        var toDoItem = await _context.ToDoItems.FindAsync(id);

        if (toDoItem == null || toDoItem.Deleted)
        {
            return NotFound();
        }

        return toDoItem;
    }

    // POST: api/ToDoItems
    [HttpPost]
    public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
    {
        _context.ToDoItems.Add(toDoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetToDoItem), new { id = toDoItem.Id }, toDoItem);
    }

    // PUT: api/ToDoItems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutToDoItem(int id, ToDoItem toDoItem)
    {
        if (id != toDoItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(toDoItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ToDoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToDoItem(int id)
    {
        var toDoItem = await _context.ToDoItems.FindAsync(id);
        if (toDoItem == null)
        {
            return NotFound();
        }

        toDoItem.Deleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
