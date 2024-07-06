using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Tests;

public class ProdutoUnitTests
{
    [Fact(DisplayName = "Criar Produto com parâmetros válidos deve retornar produto válido")]
    public void CriarProduto_ComParametrosValidos_DeveRetornarProdutoValido()
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        var imagem = "imagem.jpg";

        // Act
        var produto = new Produto(id, nome, descricao, preco, estoque, imagem);

        // Assert
        Assert.Equal(id, produto.Id);
        Assert.Equal(nome, produto.Nome);
        Assert.Equal(descricao, produto.Descricao);
        Assert.Equal(preco, produto.Preco);
        Assert.Equal(estoque, produto.Estoque);
        Assert.Equal(imagem, produto.Imagem);
    }

    [Fact(DisplayName = "Criar Produto com id negativo deve retornar exceção")]
    public void CriarProduto_ComIdNegativo_DeveRetornarExcecao()
    {
        // Arrange
        var id = -1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        var imagem = "imagem.jpg";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Produto(id, nome, descricao, preco, estoque, imagem));

        // Assert
        Assert.Equal("Id inválido. Id é obrigatório", exception.Message);
    }

    [Fact(DisplayName = "Criar Produto com nome menor que 3 caracteres deve retornar exceção")]
    public void CriarProduto_ComNomeMenorQue3Caracteres_DeveRetornarExcecao()
    {
        // Arrange
        var id = 1;
        var nome = "Pr";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        var imagem = "imagem.jpg";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Produto(id, nome, descricao, preco, estoque, imagem));

        // Assert
        Assert.Equal("Nome inválido, deve ter no mínimo 3 caracteres", exception.Message);
    }

    [Fact(DisplayName = "Criar Produto com nome da imagem maior que 250 caracteres deve retornar exceção")]
    public void CriarProduto_ComNomeDaImagemMaiorQue250Caracteres_DeveRetornarExcecao()
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        var imagem = new string('a', 251);

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Produto(id, nome, descricao, preco, estoque, imagem));

        // Assert
        Assert.Equal("Imagem inválida. Imagem deve ter no máximo 250 caracteres", exception.Message);
    }

    [Fact(DisplayName = "Criar Produto com nome da imagem nulo não deve retornar exceção")]
    public void CriarProduto_ComNomeDaImagemNulo_NaoDeveRetornarExcecao()
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        string imagem = null!;

        // Act
        var produto = new Produto(id, nome, descricao, preco, estoque, imagem);

        // Assert
        Assert.Equal(id, produto.Id);
        Assert.Equal(nome, produto.Nome);
        Assert.Equal(descricao, produto.Descricao);
        Assert.Equal(preco, produto.Preco);
        Assert.Equal(estoque, produto.Estoque);
        Assert.Equal(imagem, produto.Imagem);
    }

    [Fact(DisplayName = "Criar Produto com nome da imagem vazio não deve retornar exceção")]
    public void CriarProduto_ComNomeDaImagemVazio_NaoDeveRetornarExcecao()
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var estoque = 10;
        var imagem = "";

        // Act
        var produto = new Produto(id, nome, descricao, preco, estoque, imagem);

        // Assert
        Assert.Equal(id, produto.Id);
        Assert.Equal(nome, produto.Nome);
        Assert.Equal(descricao, produto.Descricao);
        Assert.Equal(preco, produto.Preco);
        Assert.Equal(estoque, produto.Estoque);
        Assert.Equal(imagem, produto.Imagem);
    }

    [Fact(DisplayName = "Criar Produto com preço inválido deve retornar exceção")]
    public void CriarProduto_ComPrecoInvalido_DeveRetornarExcecao()
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = -10.5m;
        var estoque = 10;
        var imagem = "imagem.jpg";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Produto(id, nome, descricao, preco, estoque, imagem));

        // Assert
        Assert.Equal("Preço inválido.", exception.Message);
    }

    [Theory(DisplayName = "Criar Produto com estoque negativo deve retornar exceção")]
    [InlineData(-1)]
    [InlineData(-10)]
    public void CriarProduto_ComEstoqueNegativo_DeveRetornarExcecao(int estoque)
    {
        // Arrange
        var id = 1;
        var nome = "Produto 1";
        var descricao = "Descrição do Produto 1";
        var preco = 10.5m;
        var imagem = "imagem.jpg";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Produto(id, nome, descricao, preco, estoque, imagem));

        // Assert
        Assert.Equal("Estoque inválido.", exception.Message);
    }
}
