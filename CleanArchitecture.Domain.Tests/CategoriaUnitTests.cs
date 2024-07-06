using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Tests;

public class CategoriaUnitTests
{
    [Fact(DisplayName = "Criar Categoria com par�metros v�lidos deve retornar categoria v�lida")]
    public void CriarCategoria_ComParametrosValidos_DeveRetornarCategoriaValida()
    {
        // Arrange
        var nome = "Categoria 1";

        // Act
        var categoria = new Categoria(nome);

        // Assert
        Assert.Equal(nome, categoria.Nome);
    }

    [Fact(DisplayName = "Criar Categoria com nome nulo ou vazio deve retornar exce��o")]
    public void CriarCategoria_ComNomeNuloOuVazio_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inv�lido. Nome � obrigat�rio", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com id negativo deve retornar exce��o")]
    public void CriarCategoria_ComIdNegativo_DeveRetornarExcecao()
    {
        // Arrange
        var id = -1;
        var nome = "Categoria 1";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(id, nome));

        // Assert
        Assert.Equal("Id inv�lido.", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com nome menor que 3 caracteres deve retornar exce��o")]
    public void CriarCategoria_ComNomeMenorQue3Caracteres_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "Ca";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inv�lido, deve ter no m�nimo 3 caracteres", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria sem informar nome deve retornar exce��o")]
    public void CriarCategoria_SemInformarNome_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inv�lido. Nome � obrigat�rio", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com nome nulo deve retornar exce��o")]
    public void CriarCategoria_ComNomeNulo_DeveRetornarExcecao()
    {
        // Arrange
        string nome = null!;

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inv�lido. Nome � obrigat�rio", exception.Message);
    }
}