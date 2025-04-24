using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"
            INSERT INTO Produtos(CategoriaId, Nome, Descricao,Preco, ImagemUrl, Estoque, DataCadastro)
            VALUES(1, 'Cocacola', 'refrigerante',5, 'coca.jpg', 50, GETDATE())
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
             mb.Sql("DELETE FROM Produtos");
        }
    }
}
