using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDDD.Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataCadastro { get; private set; }

    protected Produto() { }

    public Produto(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido");
        if (preco <= 0) throw new ArgumentException("Preço deve ser maior que zero");

        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        DataCadastro = DateTime.UtcNow;
    }

    public void AlterarPreco(decimal novoPreco)
    {
        if (novoPreco <= 0) throw new ArgumentException("Preço inválido");
        Preco = novoPreco;
    }
}

