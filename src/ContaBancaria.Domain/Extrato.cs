namespace ContaBancaria.Domain;

public class Extrato : Entity
{
    public Conta Conta { get; set; }
    
    private List<Dia> _Dias;
    public IReadOnlyCollection<Dia> Dias => _Dias;

    private Extrato()
    {
        _Dias = new List<Dia>();
    }

    public Extrato(Conta conta) : this()
    {
        Conta = conta;
    }

    public void IniciarNovoDia()
    {
        _Dias.Add(new Dia(Conta.Saldo));
    }

    public void RecalcularSaldoDaConta(Saldo saldo)
    {
        Conta.AtuatizarSaldo(saldo);
    }
}

public class Dia : Entity
{
    public Saldo SaldoInicial { get; set; }
    
    public Saldo SaldoFinal { get; set; }

    public Extrato Extrato { get; set; }

    private List<Movimentacao> _Movimentacoes;
    public IReadOnlyCollection<Movimentacao> Movimentacoes => _Movimentacoes;

    public Dia(Saldo saldoInicial)
    {
        SaldoInicial = saldoInicial;
    }

    public void RegistrarMovimentacao(Movimentacao movimentacao)
    {
        _Movimentacoes.Add(movimentacao);
        RecalcularSaldoDia();
    }

    private void RecalcularSaldoDia()
    {
        var moeda = new Moeda(SaldoInicial.Moeda.Valor + _Movimentacoes.Sum(m => m.Moeda.Valor));
        
        SaldoFinal = new Saldo(moeda);
        
        Extrato.RecalcularSaldoDaConta(SaldoFinal);
    }
}
