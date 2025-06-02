namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Cupom
{
    public Guid Id { get; set; }

    public string Codigo { get; set; }

    public int PercentualDesconto { get; set; }

    public DateTime Validade { get; set; }

    public IEnumerable<Compra>? Compras { get; set; }

    public Cupom(string codigo, int percentualDesconto, DateTime validade)
    {
        Id = Guid.NewGuid();
        Codigo = codigo;
        PercentualDesconto = percentualDesconto;
        Validade = validade;
    }
}