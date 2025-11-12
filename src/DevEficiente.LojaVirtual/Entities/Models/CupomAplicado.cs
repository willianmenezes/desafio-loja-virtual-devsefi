namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class CupomAplicado
{
    public Guid IdCupom { get; private set; }

    public string Codigo { get; set; }

    public int PercentualDesconto { get; set; }

    public DateTime Validade { get; set; }

    public CupomAplicado(
        Guid idCupom, 
        string codigo,
        int percentualDesconto,
        DateTime validade)
    {
        IdCupom = idCupom;
        Codigo = codigo;
        PercentualDesconto = percentualDesconto;
        Validade = validade;
    }
}