namespace ContaBancaria.Domain;

public class Extrato
{
    public Saldo SaldoInicial { get; private set; }
    public Saldo SaldoAtual { get; private set; }
    private List<Movimentacao> _movimentacoes;
    public IReadOnlyCollection<Movimentacao> Movimentacoes => _movimentacoes;

    private Extrato()
    {
        _movimentacoes = new List<Movimentacao>();
    }

    public Extrato(Saldo saldo, Saldo saldoAtual) : this()
    {
        SaldoInicial = saldo;
        SaldoAtual = saldoAtual;
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

        if (movimentacoesDiaAtual.Count() == 0) return;

        var saldoAtualRecalculado = SaldoInicial.Valor + movimentacoesDiaAtual.Sum(m => m.Valor);

        SaldoAtual = new Saldo(saldoAtualRecalculado);
    }
}
