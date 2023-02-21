namespace ContaBancaria.Domain;

public class Saldo
{
    public Moeda Inicial { get; private set; }
    public Moeda Atual { get; private set; }

    public Saldo(Moeda inicial, Moeda atual)
    {
        Inicial = inicial;
        Atual = atual;
    }

    public void Recalcular(IEnumerable<Movimentacao> movimentacoes)
    {
        var resultado = Inicial.Valor + movimentacoes.Sum(m => m.Moeda.Valor);

        Atual.AtribuirValor(resultado);
    }
}
