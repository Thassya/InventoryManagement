# InventoryManagement

Projeto de estudo utilizando **Domain-Driven Design (DDD)** para modelar um domínio de controle de estoque doméstico, receitas e catálogo de produtos.
O foco atual está no **modelo de domínio** (camada `InventoryManagement.Domain`) e em um **console de testes** (`InventoryManagement.Runner`).
Projeto parte integrante da matéria **Engenharia de Software [25E4-25E4] - PGLLNE01C0-24-L1** Clean Code e Padrões de Projetos. 

---

## Objetivo

Implementar o modelo de domínio feito na matéria de Domain Driven Design, no qual prevê desenvolver um sistema para controle de estoque domiciliar facilitando a vida do usuário que esquece das coisas que tem em casa. 
Entidades mapeadas: 

- Catálogo de produtos (ex.: alimentos, itens de cozinha)
- Estoque do usuário (o que a pessoa tem em casa)
- Receitas (que usam produtos do catálogo)
- Integração entre estoque e receitas

**Padrões de DDD** identificados para realização desse trabalho (até agora):

- Entidades (Entities)
- Objetos de Valor (Value Objects)
- Agregados (Aggregates)
- Repositórios (Repositories)
- Serviços de Domínio (Domain Services)

---

## Estrutura da Solução

```text
InventoryManagement.sln
 ├── InventoryManagement.Domain
 │    ├── Common
 │    │    ├── Entity.cs
 │    │    └── ValueObject.cs
 │    ├── Entities
 │    │    ├── EstoqueProduto.cs
 │    │    ├── ItemReceita.cs
 │    │    ├── Produto.cs
 │    │    ├── Receita.cs
 │    │    └── Usuario.cs
 │    ├── Enums
 │    │    ├── Dificuldade.cs
 │    │    └── UnidadeMedida.cs
 │    ├── Repositories
 │    │    ├── IReceitaRepository.cs
 │    │    └── IProdutoRepository.cs
 │    ├── ValueObjects
 │    │    ├── Categoria.cs
 │    │    ├── ProdutoId.cs
 │    │    └── Quantidade.cs
 │    └── (outros arquivos futuros)
 │
 └── InventoryManagement.Runner
      └── Program.cs
```

## InventoryManagement.Domain

Camada de **domínio**, sem dependência de banco de dados, UI ou frameworks.  
Aqui ficam os conceitos centrais do negócio, expressos através de **Entidades**, **Objetos de Valor**, **Agregados**, **Enums**, **Repositórios** e **Serviços de Domínio**.

### Estrutura interna
```text
InventoryManagement.Domain
 ├── Common
 ├── Entities
 ├── Enums
 ├── Repositories
 ├── ValueObjects
 └── Services (a serem implementados)
 ```

### Common

Contém classes base reutilizadas por todo o domínio.

---

#### `Entity.cs`
- Classe base para todas as entidades que garantem identidade via `Id` (Guid). Serve como raiz para qualquer objeto com ciclo de vida próprio no domínio.

#### `ValueObject.cs`
- Classe base para todos os Objetos de Valor, com igualdade baseada em componentes retornados por `GetEqualityComponents()`. Utiliza `yield return` para declarar quais propriedades compõem o valor e não precisar lidar com listas instanciadas.
- Representa conceitos como:
  - `Categoria`
  - `ProdutoId`
  - `Quantidade`

### Entities

Objetos com **identidade própria** (possuem `Id`) e que participam de **agregados**. Somente a **Aggregate Root** é exposta externamente; entidades internas são manipuladas apenas através da raiz.

---

#### `Usuario` (Aggregate Root — Estoque)
Representa o usuário/dono do estoque. Possuí a responsabilidade de: 
- Controlar a coleção interna de `EstoqueProduto`.
- Garantir variações do agregado (ex.: quantidade > 0).
- Expor apenas métodos que sejam seguros para o domínio.

#### `EstoqueProduto` (Entity interna do agregado Usuario)
Representa um item de estoque ligado ao usuário. 

#### `Produto.cs` (Aggregate Root — Catálogo de Produtos)
Representa um produto disponível no catálogo global.

#### `Receita` (Aggregate Root — Receitas)
Representa uma receita culinária completa.

#### `ItemReceita` (Entity interna do agregado Receita)
Representa um ingrediente da receita.

---
### Enums

Enums representam **conceitos fixos** do domínio.

---

#### `Dificuldade`
Enum que representa a complexidade de uma receita.

Valores:
- `Facil`
- `Medio`
- `Dificil`

#### `UnidadeMedida`
Enum que representa unidades de medida utilizadas tanto no estoque quanto nas receitas.

Valores:
- `Quilograma`
- `Gramas`
- `Litro`
- `Mililitro`
- `ColherDeSopa`
- `ColherDeCha`
- `Copo`
- `Xicara`
- `Unidade`

---

### ValueObjects

Representam conceitos do domínio **sem identidade própria**, definidos somente pelos seus atributos, sendo imutáveis e comparados por valor.

---

#### `Categoria`
Representa a categoria de um produto (ex.: “Hortifruti”, “Limpeza”, “Congelados”).

#### `ProdutoId`
Objeto de valor que encapsula o identificador de um produto.

#### `Quantidade`
Representa a quantidade de um item juntamente com sua unidade de medida.

---

### Repositories

Interfaces de persistência **pertencentes ao domínio**. Como toda interface, define a assinatura do que o domínio precisa salvar mas deixa a implementação livre para outra camada. 

#### `IReceitaRepository`
Responsável por persistir e recuperar agregados `Receita`.

---

#### `IProdutoRepository`
Responsável pelo agregado `Produto` (Catálogo de Produtos).

---


