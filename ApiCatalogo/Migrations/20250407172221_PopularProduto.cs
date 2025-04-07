using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"
            INSERT INTO Produtos( Nome,Descricao,Preco,ImagemUrl,Estoque,Datacadastro,CategoriaId) 
            VALUES('Coca-cola DIet', 'Refrigerente de coca 350 ml', 5.45, 'coca.jpg', 50, GETDATE(), 1)
            ");
        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
