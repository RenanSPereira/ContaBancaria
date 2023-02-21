namespace ContaBancaria.Domain;

public class Conta
{
    public int Numero { get; private set; }
    public TipoConta TipoConta { get; private set; }
    public Saldo Saldo { get; private set; }
    private List<Movimentacao> _movimentacoes;
    public IReadOnlyCollection<Movimentacao> Movimentacoes { get; private set; }

    private Conta()
    {
        _movimentacoes = new List<Movimentacao>();
    }

    public Conta(TipoConta tipoConta, int numero, Saldo saldo) : this()
    {
        Numero = numero;
        TipoConta = tipoConta;
        Saldo = saldo;
    }

    public void AdicionarMovimentacao(Movimentacao movimentacao)
    {
        _movimentacoes.Add(movimentacao);
    }

    public void RecalcularSaldo()
    {
        var movimentacoesDiaAtual = _movimentacoes
            .Where(m => m.DataCadastro.Date == DateTime.Now.Date)
            .ToList();

        Saldo.Recalcular(movimentacoesDiaAtual);
    }
}
