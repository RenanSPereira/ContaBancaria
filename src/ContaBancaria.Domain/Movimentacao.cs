namespace ContaBancaria.Domain;

public class Movimentacao
{
    public Moeda Moeda { get; private set; }
    public TipoMovimentacao TipoMovimentacao { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Movimentacao(Moeda moeda, TipoMovimentacao tipoMovimentacao)
    {
        TipoMovimentacao = tipoMovimentacao;
        Moeda = moeda;
        ConverterValor(moeda);
        DataCadastro = DateTime.Now;
    }

    private void ConverterValor(Moeda moeda)
    {
        var resultado = TipoMovimentacao == TipoMovimentacao.Debito || TipoMovimentacao == TipoMovimentacao.Transferencia
        ? moeda.Valor * -1
        : moeda.Valor;

        Moeda.AtribuirValor(resultado);
    }
}
