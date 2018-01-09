# testapp05
Naskar.TestApp05: Architecture: Proof of Concept


Prova de conceito feita como arquitetura inicial de um projeto para criação de um ERP interno. 

### Principais pontos:

- Transaction: simples gerenciamento de transação baseado em aspectos/pointcuts, ou seja, indique somente a camada que irá iniciar/fechar a transação.

- Injection/Mapping instrusive-less: mapeamentos das entidades e injeção das dependências sem dependências de outros frameworks utilizando Convention-Over-Configuration.

- Specification Pattern: padrão utilizado para criar "pedaços" de consultas a banco de dados reusáveis.

- AjaxBind: extension method para criação de chamadas ajax de forma fluente.

- InputBuilder: binding entre os templates e o model do MVC de forma fluente e typechecking, ou seja, se o modelo mudar, os templates quebram durante a compilação.
 
 
