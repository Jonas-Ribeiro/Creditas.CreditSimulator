# Creditas.CreditSimulator

Projeto desenvolvido para teste de entrevista na Creditas.

Consiste em um **Simulador de Empréstimo** que permite aos usuários simular empréstimos, visualizando as condições de pagamento baseadas no valor solicitado, taxa de juros e prazo de pagamento.

## Pré Requisito

IDE instalado na máquina e/ou ISS Express para executar local

## Como executar

- Clone o repositório
- Abra a solution Creditas.CreditSimulator.sln na IDE de sua preferência
- Selecione o projeto Creditas.CreditSimulator.WebApi como projeto startup
- Execute

## Como fazer as simulações?

Após executar o projeto, o *swagger* irá abrir

![image](https://github.com/user-attachments/assets/306cc4d0-5cd3-491b-aa6d-308feba7ade7)

Preencha o json conforme schema

![image](https://github.com/user-attachments/assets/92008613-3b5f-4ab7-8463-b97ff2f3cffc)

### Descrição das propriedades

**name**: Nome do usuário

**creditRequest**: Valor simulado do empréstimo

**birthDate**: Data de nascimento do usuário

**monthsPaymentTerm**: prazo em meses para pagamento do empréstimo

Após preencher as propriedades, clique em *Execute* e logo você terá o resultado da simulação

![image](https://github.com/user-attachments/assets/033ecf00-673f-42e0-8ff3-dd105366b56a)

### Descrição das propriedades

**totalAmount**: Total a ser pago do empréstimo

**monthlyPayment**: Valor a ser pago mensalmente

**totalFee**: Total de taxa no período (1 é 100%, no exemplo de response ficou 0.04, ou seja, 4%)

**success**: True caso a simulação seja executada com sucesso

**id**: Id de controle







