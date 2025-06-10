public class Produto
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataCadastro { get; private set; }

    protected Produto() { }

    public Produto(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido");
        if (preco <= 0) throw new ArgumentException("Preço deve ser maior que zero");

        Nome = nome;
        Preco = preco;
        DataCadastro = DateTime.UtcNow;
        // Id será definido no repositório (simulando auto-incremento)
    }

    public void AlterarPreco(decimal novoPreco)
    {
        if (novoPreco <= 0) throw new ArgumentException("Preço inválido");
        Preco = novoPreco;
    }
}
