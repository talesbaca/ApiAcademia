public class Equipamento
{
    public int Id { get; set; } 

    public required string Nome { get; set; }

    public long Preco { get; set; }

    public DateTime DataCompra { get; set; }
   
    public DateTime DataRevisao { get; set; }

    public required string GrupoMuscularPrincipal { get; set; }

    public string? Descricao { get; set; }

    public ICollection<ManutencaoEquipamento> Manutencoes { get; set; } = new List<ManutencaoEquipamento>();
}