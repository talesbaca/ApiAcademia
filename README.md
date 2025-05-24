# apiAcademia
Repositório para entrega de atividade avaliativa - UP Tópicos Especiais de Sistemas.

João Victor Corrêa de Lima;

Kauan de Jesus Sena Souza;

Eduardo Caron Becker;

Tales Bacarin Lopes;


API de Gerenciamento de Equipamentos de Academia


API REST desenvolvida em C# com ASP.NET Core para gerenciar equipamentos de academia.





  Linguagem: C#
  Framework: ASP.NET Core (Controladores - "dotnet classico")
  ORM: Entity Framework Core (EF Core)
  Banco de Dados: SQLite (com Migrations e Data Seeding)    
  Documentação/Teste: Swagger (OpenAPI)





 Funcionalidades Principais:
  Modelos: Equipamento (Nome, Preço, Data Compra, Data Revisão, Grupo Muscular) e ManutencaoEquipamento.    
  Endpoints CRUD para Equipamentos:
  GET, POST, PUT, DELETE em /api/equipamentos
  Endpoints de Manutenção:
  POST /api/equipamentos/{id}/manutencoes (Registrar manutenção)
  GET /api/equipamentos/necessita-manutencao (Listar equipamentos que precisam de manutenção - regra de 3 meses)
  Dados Iniciais: 10 equipamentos pré-cadastrados via HasData no DbContext.


  


  Como Executar:
  Clone o repositório.
  Tenha o.NET SDK (8.0+) instalado.
  No terminal, na raiz do projeto:
  dotnet ef database update (cria o BD e aplica dados iniciais)
  dotnet run (inicia a API)
  Acesse o Swagger: http://localhost:<porta>/swagger
