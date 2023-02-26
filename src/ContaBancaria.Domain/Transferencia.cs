namespace ContaBancaria.Domain;

public class Transferencia : Entity
{
    public Conta Origem { get; private set; }

    public Conta Destino { get; private set; }

    public StatusTransferencia Status { get; private set; }

    public DateTime DataDeRealizacao { get; private set; }

    public Transferencia(Conta origem, Conta destino, DateTime dataDeRealizacao)
    {
        Origem = origem;
        Destino = destino;
        DataDeRealizacao = dataDeRealizacao;

        Status = StatusTransferencia.Pendente;

        if (dataDeRealizacao.Date > DateTime.Now.Date)
        {
            Status = StatusTransferencia.Agendada;
        }
    }
}

public enum StatusTransferencia
{
    Pendente,
    Agendada,
    Compensada
}

public abstract class Entity
{
    public Guid Id { get; private set; }

    public DateTime DataDeCadastro { get; private set; }

    public DateTime DataDeAtualizacao { get; private set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        DataDeCadastro = DateTime.Now;
        DataDeAtualizacao = DateTime.Now;
    }
} 