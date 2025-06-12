# 🛒 PedidosDDD

Projeto de API REST desenvolvida em .NET 8 usando o padrão Domain-Driven Design (DDD) para gestão de pedidos e produtos.

---

## 📦 Tecnologias Utilizadas

- ✅ .NET 8
- ✅ ASP.NET Core Web API
- ✅ DDD (Domain-Driven Design)
- ✅ Injeção de Dependência (DI)
- ✅ Swagger para documentação
- ✅ Repositório em memória (simulando banco)
- ✅ Docker (opcional)
- ✅ PostgreSQL (estrutura preparada para futuro)

---

## 📂 Estrutura de Projeto

PedidosDDD/
├── PedidosDDD.API # API REST (controllers, swagger)
├── PedidosDDD.Application # Camada de aplicação (DTOs, Services)
├── PedidosDDD.Domain # Entidades, Regras de negócio, Repositórios
├── PedidosDDD.Infrastructure # Repositórios em memória

---

## 🚀 Como Rodar o Projeto

### 1. Clone o repositório
```bash
git clone https://github.com/seuusuario/PedidosDDD.git
cd PedidosDDD
```

## 2.Restaure os pacotes e compile
```bash
dotnet restore
dotnet build
```

## 3. Execute o projeto
```bash
dotnet run --project PedidosDDD.API
```


## 4. Acesse o Swagger
```bash
https://localhost:xxxx/swagger
```


📘 Endpoints disponíveis

## Produtos

GET /api/produto
GET /api/produto/{id}

POST /api/produto

PUT /api/produto

DELETE /api/produto/{id}

## Pedidos

GET /api/pedido
GET /api/pedido/{id}

POST /api/pedido (cria pedido com lista de produtos)

PUT /api/pedido/finalizar/{id}
PUT /api/pedido/cancelar/{id}

---

🧠 Conceitos aplicados

Entidades Ricas com validação (ex: Produto, Pedido, ItemPedido)

Camada de Aplicação com DTOs e Services

Repositórios desacoplados via interfaces

Regras de domínio isoladas

Injeção de dependência com DI container

Validação em memória para testes rápidos

---

🧑‍💻 Autor
Cayque Guilherme
Desenvolvedor Back-end apaixonado por boas práticas, domínio do código e evolução contínua.
