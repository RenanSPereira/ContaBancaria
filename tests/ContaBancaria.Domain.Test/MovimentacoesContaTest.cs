namespace ContaBancaria.Domain.Test;

public class MovimentacoesContaTest
{
    [Fact]
    public void Deve_Depositar_Um_Valor_Na_Conta_Corrente_E_Atualizar_Seu_Saldo()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Saldo(new Moeda(0.0m), new Moeda(0.0m))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));

        conta?.RecalcularSaldo();

        Assert.Equal("R$ 5,00", conta?.Saldo.Atual.ObterValorFormatado());
    }

    [Fact]
    public void Deve_Depositar_E_Debitar_Um_Valor_Na_Conta_Corrente_E_Atualizar_Seu_Saldo()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Saldo(new Moeda(0.0m), new Moeda(0.0m))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));
        
        conta?.AdicionarMovimentacao(new Movimentacao(new Moeda(1.5m), TipoMovimentacao.Debito));

        conta?.RecalcularSaldo();

        Assert.Equal("R$ 3,50", conta?.Saldo.Atual.ObterValorFormatado());
    }

    [Fact]
    public void Deve_Recalcular_Saldo_Utilizando_Saldo_Inicial()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Saldo(new Moeda(2000m), new Moeda(0.0m))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));

        conta?.AdicionarMovimentacao(new Movimentacao(new Moeda(1.5m), TipoMovimentacao.Debito));

        conta?.RecalcularSaldo();

        Assert.Equal("R$ 2.003,50", conta?.Saldo.Atual.ObterValorFormatado());
    }
}