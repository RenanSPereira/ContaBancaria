using System.Globalization;

namespace ContaBancaria.Domain;

public class Saldo
{
    public Moeda Moeda { get; private set; }

    public Saldo(Moeda moeda)
    {
        Moeda = moeda;
    }
}
