namespace ContaBancaria.Domain;

public class Movimentacao
{
    public decimal Valor { get; private set; }
    public TipoMovimentacao TipoMovimentacao { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Movimentacao(decimal valor, TipoMovimentacao tipoMovimentacao)
    {
        TipoMovimentacao = tipoMovimentacao;
        DataCadastro = DateTime.Now;
        AtribuirValor(valor);
    }

    private void AtribuirValor(decimal valor)
    {
        Valor = TipoMovimentacao == TipoMovimentacao.Debito || TipoMovimentacao == TipoMovimentacao.Transferencia
            ? valor * -1
            : valor;
    }
}
