using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/equipamento")]
[ApiController]
public class AcademiaController : ControllerBase
{
    private readonly AcademiaDbContext _context;

    public AcademiaController(AcademiaDbContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
    {
        return await _context.Equipamentos.Include(e => e.Manutencoes).ToListAsync();
    }

    [HttpGet("findOne/{id}")]
    public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
    {
        var equipamento = await _context.Equipamentos
            .Include(e => e.Manutencoes)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (equipamento == null)
        {
            return NotFound();
        }

        return equipamento;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Equipamentos.Add(equipamento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEquipamento), new { id = equipamento.Id }, equipamento);
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
    {
        if (id != equipamento.Id)
        {
            return BadRequest("O ID do equipamento na URL não corresponde ao ID no corpo da requisição."); // HTTP 400
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(equipamento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipamentoExists(id))
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

    // adiciona manutencoes em um equipamento
    [HttpPost("{id}/manutencoes")]
    public async Task<ActionResult<ManutencaoEquipamento>> PostManutencaoEquipamento(int id, ManutencaoEquipamento manutencao)
    {
        var equipamento = await _context.Equipamentos.FindAsync(id);
        if (equipamento == null)
        {
            return NotFound($"Equipamento com ID {id} não encontrado.");
        }

        manutencao.EquipamentoId = id;

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.ManutencoesEquipamento.Add(manutencao);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetEquipamento", new { id }, manutencao);
    }

    // esse checa se algum equipamento precisa de manutencao
    [HttpGet("necessita-manutencao")]
    public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentosNecessitandoManutencao()
    {
        var hoje = DateTime.UtcNow.Date;

        var equipamentosParaVerificar = await _context.Equipamentos
        .Include(e => e.Manutencoes)
        .ToListAsync();

        var necessitandoManutencao = equipamentosParaVerificar.Where(e =>
        {
            DateTime dataReferencia;
            var ultimaManutencao = e.Manutencoes.OrderByDescending(m => m.DataFeita).FirstOrDefault();

            if (ultimaManutencao == null)
            {
                dataReferencia = e.DataCompra;
            }
            else
            {
                dataReferencia = ultimaManutencao.DataFeita;
            }

            return dataReferencia.AddMonths(3).Date <= hoje;
        }).ToList();

        return Ok(necessitandoManutencao);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteEquipamento(int id)
    {
        var equipamento = await _context.Equipamentos.FindAsync(id);
        if (equipamento == null)
        {
            return NotFound();
        }

        _context.Equipamentos.Remove(equipamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipamentoExists(int id)
    {
        return _context.Equipamentos.Any(e => e.Id == id);
    }
}