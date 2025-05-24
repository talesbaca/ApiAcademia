// Data/AcademiaDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AcademiaDbContext : DbContext
{
    public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options) : base(options) { }

    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<ManutencaoEquipamento> ManutencoesEquipamento { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipamento>().HasData(
            new Equipamento { Id = 1, Nome = "Leg Press", Preco = 8500, DataCompra = new DateTime(2025, 2, 15), DataRevisao = new DateTime(2025, 5, 15), GrupoMuscularPrincipal = "Pernas (quadríceps, glúteos)", Descricao = null },
            new Equipamento { Id = 2, Nome = "Supino Reto", Preco = 5200, DataCompra = new DateTime(2025, 3, 1), DataRevisao = new DateTime(2025, 6, 1), GrupoMuscularPrincipal = "Peitoral", Descricao = null },
            new Equipamento { Id = 3, Nome = "Puxada Frente (Pulldown)", Preco = 4700, DataCompra = new DateTime(2025, 2, 20), DataRevisao = new DateTime(2025, 5, 20), GrupoMuscularPrincipal = "Costas (latíssimo do dorso)", Descricao = null },
            new Equipamento { Id = 4, Nome = "Cadeira Extensora", Preco = 4000, DataCompra = new DateTime(2025, 3, 10), DataRevisao = new DateTime(2025, 6, 10), GrupoMuscularPrincipal = "Quadríceps", Descricao = null },
            new Equipamento { Id = 5, Nome = "Cadeira Abdutora", Preco = 3800, DataCompra = new DateTime(2025, 2, 25), DataRevisao = new DateTime(2025, 5, 25), GrupoMuscularPrincipal = "Glúteos e abdutores", Descricao = null },
            new Equipamento { Id = 6, Nome = "Smith Machine (Máquina Smith)", Preco = 9000, DataCompra = new DateTime(2025, 3, 5), DataRevisao = new DateTime(2025, 6, 5), GrupoMuscularPrincipal = "Peitoral, ombros e pernas", Descricao = null },
            new Equipamento { Id = 7, Nome = "Rosca Scott", Preco = 3600, DataCompra = new DateTime(2025, 3, 15), DataRevisao = new DateTime(2025, 6, 15), GrupoMuscularPrincipal = "Bíceps", Descricao = null },
            new Equipamento { Id = 8, Nome = "Tríceps Testa (com polia)", Preco = 3200, DataCompra = new DateTime(2025, 3, 20), DataRevisao = new DateTime(2025, 6, 20), GrupoMuscularPrincipal = "Tríceps", Descricao = null },
            new Equipamento { Id = 9, Nome = "Peck Deck (voador)", Preco = 5500, DataCompra = new DateTime(2025, 2, 28), DataRevisao = new DateTime(2025, 5, 28), GrupoMuscularPrincipal = "Peitoral", Descricao = null },
            new Equipamento { Id = 10, Nome = "Remada Baixa", Preco = 4900, DataCompra = new DateTime(2025, 3, 12), DataRevisao = new DateTime(2025, 6, 12), GrupoMuscularPrincipal = "Costas (dorsais, romboides)", Descricao = null }
        );
    }
}