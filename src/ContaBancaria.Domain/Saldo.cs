using System.Globalization;

namespace ContaBancaria.Domain;

public class Saldo
{
    public decimal Valor { get; private set; }

    public Saldo(decimal valor)
    {
        Valor = valor;
    }

    public override string ToString()
    {
        var specifier = "C";
        var culture = CultureInfo.CreateSpecificCulture("pt-BR");
        return Valor.ToString(specifier, culture);
    }
}
