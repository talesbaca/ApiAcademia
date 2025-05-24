public enum EstadoManutencao
{
    Boa,
    Moderado,
    Pessimo
}

public class ManutencaoEquipamento
{
    public int Id { get; set; }

    public DateTime DataFeita { get; set; }

    public required string Descritivo { get; set; }

    public EstadoManutencao EstadoEquipamento { get; set; }

    public bool FoiUtilizadaRecentemente { get; set; }

    public int? VezesUtilizadaSemanaAnterior { get; set; }

    public int EquipamentoId { get; set; }

    public required Equipamento Equipamento { get; set; }
}