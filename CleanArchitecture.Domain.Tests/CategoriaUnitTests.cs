using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Tests;

public class CategoriaUnitTests
{
    [Fact(DisplayName = "Criar Categoria com parâmetros válidos deve retornar categoria válida")]
    public void CriarCategoria_ComParametrosValidos_DeveRetornarCategoriaValida()
    {
        // Arrange
        var nome = "Categoria 1";

        // Act
        var categoria = new Categoria(nome);

        // Assert
        Assert.Equal(nome, categoria.Nome);
    }

    [Fact(DisplayName = "Criar Categoria com nome nulo ou vazio deve retornar exceção")]
    public void CriarCategoria_ComNomeNuloOuVazio_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inválido. Nome é obrigatório", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com id negativo deve retornar exceção")]
    public void CriarCategoria_ComIdNegativo_DeveRetornarExcecao()
    {
        // Arrange
        var id = -1;
        var nome = "Categoria 1";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(id, nome));

        // Assert
        Assert.Equal("Id inválido.", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com nome menor que 3 caracteres deve retornar exceção")]
    public void CriarCategoria_ComNomeMenorQue3Caracteres_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "Ca";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inválido, deve ter no mínimo 3 caracteres", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria sem informar nome deve retornar exceção")]
    public void CriarCategoria_SemInformarNome_DeveRetornarExcecao()
    {
        // Arrange
        var nome = "";

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inválido. Nome é obrigatório", exception.Message);
    }

    [Fact(DisplayName = "Criar Categoria com nome nulo deve retornar exceção")]
    public void CriarCategoria_ComNomeNulo_DeveRetornarExcecao()
    {
        // Arrange
        string nome = null!;

        // Act
        var exception = Assert.Throws<DominioValidation>(() => new Categoria(nome));

        // Assert
        Assert.Equal("Nome inválido. Nome é obrigatório", exception.Message);
    }
}