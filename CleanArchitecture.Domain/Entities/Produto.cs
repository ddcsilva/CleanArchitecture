using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities;

public sealed class Produto : Entity
{
    public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DominioValidation.Quando(id < 0, "Id inválido. Id é obrigatório");
        ValidarDominio(nome, descricao, preco, estoque, imagem);
        Id = id;
    }

    public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        ValidarDominio(nome, descricao, preco, estoque, imagem);
    }

    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; } 
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public string? Imagem { get; private set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = default!;

    public void Atualizar(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        ValidarDominio(nome, descricao, preco, estoque, imagem);
    }

    private void ValidarDominio(string nome, string descricao, decimal preco, int estoque, string imagem)
    {
        DominioValidation.Quando(string.IsNullOrWhiteSpace(nome), "Nome inválido. Nome é obrigatório");
        DominioValidation.Quando(nome.Length < 3, "Nome inválido, deve ter no mínimo 3 caracteres");

        DominioValidation.Quando(string.IsNullOrWhiteSpace(descricao), "Descrição inválida. Descrição é obrigatória");
        DominioValidation.Quando(descricao.Length < 5, "Descrição inválida, deve ter no mínimo 5 caracteres");

        DominioValidation.Quando(preco < 0, "Preço inválido.");

        DominioValidation.Quando(estoque < 0, "Estoque inválido.");

        DominioValidation.Quando((!string.IsNullOrEmpty(imagem) && imagem.Length > 250), "Imagem inválida. Imagem deve ter no máximo 250 caracteres");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Imagem = imagem;
    }
}
