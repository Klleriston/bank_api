using Microsoft.AspNetCore.Mvc;

namespace bank_api;

[ApiController]
[Route("/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly DatabaseBank _context;
    private readonly TransactionServices transactionServices;

    public TransactionController(DatabaseBank context, TransactionServices transactionServices)
    {
        this._context = context;
        this.transactionServices = transactionServices;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] TransactionDTO transaction)
    {
        try
        {
            Transaction newTransaction = await transactionServices.CreateTransaction(transaction);
            return Ok(new { Mensagem = "Transaction Created!", Transaction = newTransaction });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensagem = "Error creating transaction.", Detalhes = ex.Message });
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var deletedTransaction = _context.Transactions.Find(id);

        if (deletedTransaction == null)
        {
            return NotFound();
        }

        _context.Transactions.Remove(deletedTransaction);
        _context.SaveChanges();
        return NoContent();

    }
}