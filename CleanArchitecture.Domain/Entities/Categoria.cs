using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities;

public sealed class Categoria : Entity
{
    public Categoria(int id, string nome)
    {
        DominioValidation.Quando(id < 0, "Id inválido. Id é obrigatório");
        ValidarDominio(nome);
    }

    public Categoria(string nome)
    {
        ValidarDominio(nome);
    }

    public string Nome { get; private set; } = string.Empty;

    public ICollection<Produto> Produtos { get; private set; } = [];

    public void Atualizar(string nome)
    {
        ValidarDominio(nome);
    }

    private void ValidarDominio(string nome)
    {
        DominioValidation.Quando(string.IsNullOrWhiteSpace(nome), "Nome inválido. Nome é obrigatório");
        DominioValidation.Quando(nome.Length < 3, "Nome inválido, deve ter no mínimo 3 caracteres");

        Nome = nome;
    }
}
