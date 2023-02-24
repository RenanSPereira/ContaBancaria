namespace ContaBancaria.Domain;

public class Conta
{
    public int Numero { get; private set; }
    public TipoConta TipoConta { get; private set; }
    public Extrato Extrato { get; private set; }

    public Conta(TipoConta tipoConta, int numero, Extrato extrato)
    {
        Numero = numero;
        TipoConta = tipoConta;
        Extrato = extrato;
    }
}
