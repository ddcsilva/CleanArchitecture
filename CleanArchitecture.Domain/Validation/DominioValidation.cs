namespace CleanArchitecture.Domain.Validation;

public class DominioValidation : Exception
{
    public DominioValidation(string mensagemErro) : base(mensagemErro) { }

    public static void Quando(bool existeErro, string mensagemErro)
    {
        if (existeErro)
        {
            throw new DominioValidation(mensagemErro);
        }
    }
}
