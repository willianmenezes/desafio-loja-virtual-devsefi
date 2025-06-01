namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Compra
{
    public Guid Id { get; }

    public Guid IdPais { get; private set; }

    public Guid? IdEstado { get; private set; }

    public string Email { get; private set; }

    public string Nome { get; private set; }

    public string SobreNome { get; private set; }

    public string Documento { get; private set; }

    public string Endereco { get; private set; }

    public string Complemento { get; private set; }

    public string Cidade { get; private set; }

    public string Telefone { get; private set; }

    public string Cep { get; private set; }

    public Pais? Pais { get; set; }

    public Estado? Estado { get; set; }

    public Pedido? Pedido { get; set; }

    public Compra(
        Guid idPais,
        Guid? idEstado,
        string email,
        string nome,
        string sobreNome,
        string documento,
        string endereco,
        string complemento,
        string cidade,
        string telefone,
        string cep,
        Func<Compra, Pedido> funcaoCriarPedido)
    {
        Id = Guid.NewGuid();
        IdPais = idPais;
        IdEstado = idEstado;
        Email = email;
        Nome = nome;
        SobreNome = sobreNome;
        Documento = documento;
        Endereco = endereco;
        Complemento = complemento;
        Cidade = cidade;
        Telefone = telefone;
        Cep = cep;
        Pedido = funcaoCriarPedido(this);
    }

    [Obsolete("Para uso do EF Core apenas", true)]
    public Compra()
    {
        
    }
}