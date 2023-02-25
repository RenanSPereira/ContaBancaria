using System.Globalization;

namespace ContaBancaria.Domain;

public class Moeda
{
    public decimal Valor { get; private set; }

    public Moeda(decimal valor)
    {
        Valor = valor;
    }

    public override string ToString()
    {
        var specifier = "C";
        var culture = CultureInfo.CreateSpecificCulture("pt-BR");
        return Valor.ToString(specifier, culture);
    }

    public Moeda Negativar()
    {
        return new Moeda(Valor * -1);
    }
}
