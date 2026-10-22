# Motor de Gestão de Contas Bancárias

## Identificação
- **Aluna:** Mayara Nogueira Moreira
- **Curso:** Desenvolvedor Back-End [.Net]
- **Atividade:** Mini-Projeto Avaliativo – MiniBanco

## Objetivo
Aplicação de console em C# que simula o motor de gestão de contas de um banco digital. O sistema permite abrir contas de três tipos (Corrente, Poupança e Salário), registrar depósitos e saques, aplicar o fechamento mensal de acordo com as regras de cada tipo e gerar um relatório com a pontuação, o índice de saúde financeira, a classificação da conta e as recomendações para a gerência.

O projeto consolida os conteúdos de C# e Programação Orientada a Objetos: classes, construtores, encapsulamento, herança, polimorfismo, listas, laços, condicionais e tratamento de exceções.

## Funcionalidades
O programa abre um menu que fica em execução até o usuário escolher sair:

| Opção | Função |
|---|---|
| 1 - Abrir Nova Conta | Cadastra uma Conta Corrente, Poupança ou Salário, com os dados comuns (titular, número e saldo inicial) e os atributos específicos de cada tipo |
| 2 - Registrar Movimentação | Busca a conta pelo número e registra um depósito ou um saque |
| 3 - Aplicar Fechamento Mensal | Executa o fechamento de todas as contas, cada uma com a sua regra (polimorfismo) |
| 4 - Exibir Relatório das Contas | Mostra os dados, as movimentações, a pontuação, o índice de saúde, a classificação e as pendências de cada conta |
| 0 - Sair | Encerra o programa |

## Estrutura do Projeto
```
minibanco-dotnet/
├── src/
│   └── MiniBanco.ConsoleApp/
│       ├── Program.cs                  → menu principal e tratamento de exceções
│       ├── Models/
│       │   ├── Transacao.cs            → modelo de uma movimentação
│       │   ├── Conta.cs                → classe base abstrata
│       │   ├── ContaCorrente.cs        → conta com cheque especial
│       │   ├── ContaPoupanca.cs        → conta com rendimento mensal
│       │   └── ContaSalario.cs         → conta com limite de saques
│       ├── Exceptions/
│       │   └── SaldoInsuficienteException.cs
│       ├── Services/
│       │   └── MotorAnalise.cs         → pontuação, índice, classificação e relatório
│       └── MiniBanco.ConsoleApp.csproj
└── README.md
```

## Como Executar
**Pré-requisitos:** [.NET SDK](https://dotnet.microsoft.com/download) (o projeto foi desenvolvido com o .NET 10) e Git.

```bash
git clone https://github.com/nogueiramayaraa/minibanco-dotnet.git
cd minibanco-dotnet
dotnet run --project src/MiniBanco.ConsoleApp
```

> Em um sistema em português, valores com casas decimais são digitados com vírgula (ex.: `0,5`).

## Regras de Negócio

### Transações
- Os tipos aceitos são **Deposito**, **Saque** e **Tarifa**.
- O valor deve ser maior que zero. Caso contrário, é lançada uma `ArgumentException`.
- O saldo inicial informado na abertura não é registrado como transação.

### Regras por tipo de conta
| Conta | Atributos próprios | Saque | Fechamento mensal |
|---|---|---|---|
| Corrente | Limite do cheque especial | Permite sacar até saldo + limite | Cobra Tarifa de manutenção de R$ 10,00 |
| Poupança | Taxa de rendimento mensal (%) e dia do aniversário | Regra padrão: só até o saldo | Deposita o rendimento (saldo × taxa / 100), se for maior que zero |
| Salário | Empregador e limite de saques mensais | A partir do saque que ultrapassa o limite, cobra também Tarifa de R$ 5,00 | Zera a contagem de saques do mês |

Quando o saque não é permitido, é lançada a `SaldoInsuficienteException`.

### Pontuação por transação
| Tipo | Pontos |
|---|---|
| Deposito | 10 |
| Saque | 5 |
| Tarifa | 0 |

### Índice de saúde
**Índice (%) = (pontuação obtida ÷ pontuação máxima) × 100**, em que a pontuação máxima é o total de transações × 10. Uma conta sem transações recebe índice 0%, evitando a divisão por zero.

### Classificação
| Índice | Classificação | Ação corporativa |
|---|---|---|
| 90% a 100% | Conta Saudável | Oferecer investimentos e avaliar aumento de limite |
| 60% a 89% | Conta em Atenção | Contato da gerência para orientação financeira e revisão de tarifas |
| 0% a 59% | Conta em Risco | Bloquear aumento de limite e abrir análise de crédito |

### Pendências e recomendações
- 🔴 **Itens críticos:** cada tarifa, com a recomendação de avaliar isenção ou migração para um pacote de serviços.
- 🟡 **Itens de atenção:** cada saque, com a recomendação de acompanhar e contatar o cliente. Se a conta corrente estiver usando o cheque especial, há um aviso adicional.
- 🟢 Sem tarifas nem saques: nenhuma pendência, e a recomendação é oferecer produtos de investimento.

### Tratamento de erros
O programa não é encerrado por entradas inválidas. O menu trata `SaldoInsuficienteException`, `ArgumentException` e `FormatException`, mostra uma mensagem ao usuário e volta ao menu.

## Conceitos de POO Aplicados
- **Encapsulamento:** o `Saldo` tem `protected set` e só é alterado pelos métodos da conta e das subclasses.
- **Herança:** `ContaCorrente`, `ContaPoupanca` e `ContaSalario` herdam de `Conta` e reaproveitam o construtor com `base(...)`.
- **Polimorfismo:** `Sacar()` e `AplicarFechamentoMensal()` são `virtual` na `Conta` e sobrescritos com `override`. No fechamento mensal, o menu chama o mesmo método em todas as contas sem verificar o tipo.
- **Composição:** cada conta tem uma `List<Transacao>` como extrato.
- **Exceção própria:** `SaldoInsuficienteException`, herdando de `Exception`.
- Toda busca, filtragem e cálculo é feita com `foreach` e `if`, **sem LINQ**.

## Organização do Desenvolvimento
O trabalho foi dividido em branches, cada uma integrada à `main` por pull request:

| Branch | Conteúdo |
|---|---|
| `feature/modelos` | Transacao, exceção, Conta e ContaCorrente |
| `feature/conta-poupanca` | ContaPoupanca |
| `feature/conta-salario` | ContaSalario |
| `feature/menu` | Menu principal e tratamento de exceções |
| `feature/relatorio` | MotorAnalise e relatório |
| `feature/readme` | Documentação |

## Limitações
- Os dados ficam apenas na memória e são perdidos quando o programa é encerrado.
- A tarifa por excesso de saques da Conta Salário pode deixar o saldo negativo, caso que o enunciado não define.
- O aviso de cheque especial considera o saldo final da conta e não identifica qual saque usou o limite.
- Não há validação de número de conta duplicado na abertura.

## Vídeo de Apresentação
https://www.youtube.com/watch?v=JIlJL2GMO5w







