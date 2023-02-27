namespace ContaBancaria.Domain;

public class Cliente
{
    public string Nome { get; private set; }
    private List<Conta> _contas;
    public IReadOnlyCollection<Conta> Contas => _contas;

    private Cliente()
    {
        _contas = new List<Conta>();
    }

    public Cliente(string nome) : this()
    {
        Nome = nome;
    }

    public void AdicionarConta(Conta conta)
    {
        _contas.Add(conta);
    }

    public Conta? ObterConta(TipoConta tipoConta)
    {
        return _contas.FirstOrDefault(c => c.TipoConta == tipoConta);
    }

    // public void Transferencia(Moeda moeda, TipoConta tipoContaOrigem, TipoConta tipoContaDestino)
    // {
    //     var contaOrigem = ObterConta(tipoContaOrigem);
    //     var contaDestino = ObterConta(tipoContaDestino);
    //
    //     contaOrigem?.Extrato.AdicionarMovimentacao(new Movimentacao(moeda, TipoMovimentacao.Transferencia));
    //     contaDestino?.Extrato.AdicionarMovimentacao(new Movimentacao(moeda, TipoMovimentacao.Credito));
    //
    //     contaOrigem?.Extrato.RecalcularSaldo();
    //     contaDestino?.Extrato.RecalcularSaldo();
    // }
}
