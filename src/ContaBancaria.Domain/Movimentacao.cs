namespace ContaBancaria.Domain;

public class Movimentacao
{
    public Moeda Moeda { get; private set; }
    public TipoMovimentacao TipoMovimentacao { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Movimentacao(Moeda moeda, TipoMovimentacao tipoMovimentacao)
    {
        TipoMovimentacao = tipoMovimentacao;
        DataCadastro = DateTime.Now;
        Moeda = tipoMovimentacao == TipoMovimentacao.Debito || tipoMovimentacao == TipoMovimentacao.Transferencia ? moeda.Negativar() : moeda;
    }
}
