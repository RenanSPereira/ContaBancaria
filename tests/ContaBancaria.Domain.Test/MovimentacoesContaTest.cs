using Xunit;

namespace ContaBancaria.Domain.Test;

public class MovimentacoesContaTest
{
    [Fact]
    public void Deve_Depositar_Um_Valor_Na_Conta_Corrente_E_Atualizar_Seu_Saldo()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Extrato(new Saldo(new Moeda(0.0m)), new Saldo(new Moeda(0.0m)))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.Extrato.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));

        conta?.Extrato.RecalcularSaldo();

        Assert.Equal("R$ 5,00", conta?.Extrato.SaldoAtual.Moeda.ToString());
    }

    [Fact]
    public void Deve_Depositar_E_Debitar_Um_Valor_Na_Conta_Corrente_E_Atualizar_Seu_Saldo()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Extrato(new Saldo(new Moeda(0.0m)), new Saldo(new Moeda(0.0m)))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.Extrato.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));

        conta?.Extrato.AdicionarMovimentacao(new Movimentacao(new Moeda(1.5m), TipoMovimentacao.Debito));

        conta?.Extrato.RecalcularSaldo();

        Assert.Equal("R$ 3,50", conta?.Extrato.SaldoAtual.Moeda.ToString());
    }

    [Fact]
    public void Deve_Recalcular_Saldo_Utilizando_Saldo_Inicial()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Extrato(new Saldo(new Moeda(2000.0m)), new Saldo(new Moeda(0.0m)))));

        var conta = cliente.ObterConta(TipoConta.Corrente);

        conta?.Extrato.AdicionarMovimentacao(new Movimentacao(new Moeda(5.0m), TipoMovimentacao.Credito));

        conta?.Extrato.AdicionarMovimentacao(new Movimentacao(new Moeda(1.5m), TipoMovimentacao.Debito));

        conta?.Extrato.RecalcularSaldo();

        Assert.Equal("R$ 2.003,50", conta?.Extrato.SaldoAtual.Moeda.ToString());
    }

    [Fact]
    public void Deve_Realizar_Trasnferencia_Entre_Contas_Corrente_E_Poupanca_Do_Mesmo_Cliente()
    {
        var cliente = new Cliente("Cliente Teste");

        cliente.AdicionarConta(new Conta(TipoConta.Corrente, 100, new Extrato(new Saldo(new Moeda(2000.0m)), new Saldo(new Moeda(0.0m)))));
        cliente.AdicionarConta(new Conta(TipoConta.Poupanca, 100, new Extrato(new Saldo(new Moeda(3000.0m)), new Saldo(new Moeda(0.0m)))));
        
        cliente.Transferencia(new Moeda(1000m),TipoConta.Corrente, TipoConta.Poupanca);

        var contaCorrente = cliente.ObterConta(TipoConta.Corrente);
        var contaPoupanca = cliente.ObterConta(TipoConta.Poupanca);

        Assert.Equal("R$ 1.000,00", contaCorrente?.Extrato.SaldoAtual.Moeda.ToString());
        Assert.Equal("R$ 4.000,00", contaPoupanca?.Extrato.SaldoAtual.Moeda.ToString());
    }
}