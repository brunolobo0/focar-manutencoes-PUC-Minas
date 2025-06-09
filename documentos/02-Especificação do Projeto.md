# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. 

| Tipo de Usuário   | Descrição | Responsabilidades |
|------------------|-----------|------------------|
| **Administrador** | Gerencia a aplicação e os usuários. | Gerenciar usuários, configurar o sistema, acessar todos os relatórios. |
| **Cliente** | Utiliza o sistema para solicitar orçamentos e acompanhar serviços. | Solicitar orçamentos, acompanhar serviços e se comunicar com a empresa. |
| **Colaborador** | Atua na execução dos serviços e na interação com clientes. | Atualizar status de serviços, responder clientes e registrar informações técnicas. |


## Arquitetura e Tecnologias

![Image](https://github.com/user-attachments/assets/ceba32a2-6a79-4d4f-b070-f7c70ec977b2)

Tecnologias Utilizadas

Frontend:

° React.js para construção da UI.

° Axios ou Fetch API para comunicação HTTP.

° Redux ou Context API para gerenciamento de estado.

Backend:

° ASP.NET Core para construir os controladores e serviços.

° MongoDB para armazenamento de dados.

° JWT para autenticação.

## Project Model Canvas

![Image](https://github.com/user-attachments/assets/8b45f11b-dba0-4f7a-9ff8-38aef4dc23f4)

Link do miro: https://miro.com/welcomeonboard/blNJemE4bFIwNHRocytPLzhvaGNRSE1sVC9vMDhUdStaYjRtN2dXbjQ0U2FVRFhrMWRoK3hhRVNyVXBBZHpPaS8vVjZoU0QrVEhCTW1rSWRJRExQeXFSWmEvUVBRODFMbHVvaFhYNHc1VDY0Qk1IUUl1dEI2cDVubElUVEMzclVBd044SHFHaVlWYWk0d3NxeHNmeG9BPT0hdjE=?share_link_id=600836402346

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01|O sistema deve permitir que os usuários solicitem orçamentos para serviços de manutenção.| ALTA | 
|RF-02|O sistema deve incluir uma funcionalidade de login, restrita exclusivamente aos funcionários da empresa, garantindo a segurança e o controle de acesso.| ALTA |
|RF-03|O sistema deve disponibilizar uma tela para o cadastro de novos usuários, com acesso restrito ao administrador do sistema. | ALTA |
|RF-04|O sistema deve permitir o cadastro de orçamentos de forma intuitiva, com todos os campos necessários para detalhamento dos serviços a serem realizados.| ALTA |
|RF-05|O sistema deve disponibilizar a exportação dos orçamentos para formatos PDF ou Excel, facilitando o compartilhamento da documentação.| BAIXA |
|RF-06|O sistema deve contar com uma tela de gestão de orçamentos, onde seja possível visualizar, editar e acompanhar o status de cada orçamento solicitado pelos clientes. | ALTA |
|RF-07|O sistema deve ter uma tela específica para o cadastro de fornecedores deve ser incluída, facilitando o gerenciamento dos parceiros de serviço. | BAIXA |
|RF-08|O sistema deve permitir o cadastro de produtos (peças) e serviços (mão de obra), com informações detalhadas sobre cada um, para facilitar a criação de orçamentos.| ALTA |
|RF-09|O sistema deve disponibilizar uma função para cadastrar clientes com informações detalhadas sobre suas necessidades e preferências, melhorando o atendimento e personalização dos serviços.| MÉDIA |
|RF-10|O sistema deve ter uma uma função de pesquisa eficaz que permita aos usuários localizar orçamentos específicos rapidamente, de acordo com critérios predefinidos.| MÉDIA |
|RF-11|O sistema deve disponibilizar uma área com documentos e guias detalhados sobre os serviços oferecidos e os cuidados necessários com as máquinas, ajudando os clientes a entender melhor os processos.| BAIXA |
|RF-12|O sistema deve enviar notificações por e-mail para os clientes sobre o status dos seus orçamentos, confirmações de serviços e outras atualizações relevantes.	| MÉDIA |
|RF-13| O sistema deve permitir que os clientes avaliem os serviços prestados e deixem feedbacks que possam ser visualizados por outros usuários.	| BAIXA |


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|------|-----------------------------------------|----|
|RNF-01|A interface do sistema deve ser intuitiva e fácil de usar, garantindo uma boa experiência ao usuário.| ALTA | 
|RNF-02|O sistema deve suportar acessos simultâneos sem comprometer a performance.| ALTA |
|RNF-03|O sistema deve implementar medidas de segurança robustas para proteger os dados dos usuários e as transações realizadas.| ALTA |
|RNF-04|O sistema deve ser fácil de atualizar e manter, permitindo a inclusão de novas funcionalidades e correções de bugs. | MÉDIA |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-01|Agende reuniões semanais com a equipe de desenvolvimento todas as terças feiras a partir das 19:30h. |
|RE-02|Entregue o projeto completo no dia 22/06/2025.|
|RE-03|Mantenha o repositório das entregas no GitHub Classroom.      |
|RE-04|Garanta que a plataforma seja compatível com as ferramentas de acessibilidade dos sistemas operacionais.       |
|RE-05|Certifique-se de que a plataforma atenda às normas da Lei Geral de Proteção de Dados (LGPD).     |

## Diagrama de Caso de Uso

Abaixo está o diagrama de casos de uso. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![Image](https://github.com/user-attachments/assets/4a471a0d-dcb8-4d6d-9e92-4a8e937ac7b3)


## Projeto da Base de Dados

## Documentação do Banco de Dados MongoDB

Este documento descreve a estrutura e o esquema do banco de dados não relacional utilizado por nosso projeto, baseado em MongoDB. O MongoDB é um banco de dados NoSQL que armazena dados em documentos JSON (ou BSON, internamente), permitindo uma estrutura flexível e escalável para armazenar e consultar dados.

## Esquema do Banco de Dados
### Coleção: Budget
Armazena as informações dos orçamentos do sistema.

Estrutura do Documento

```Json
{
  "_id": {
    "$oid": "67a7c3cc55f499fe1cfff4de"
  },
  "id": "id-do-orçamento",
  "name": "Nome do Cliente",
  "email": "email@cliente.com",
  "phone": "123456789",
  "details": "Detalhes adicionais sobre a solicitação do orçamento",
  "createdDate": "data-do-orçamento-criado",
  "updatedDate": "data-da-atualizacao"
}
```

#### Descrição dos Campos
> - <strong>_id:</strong> Identificador único do usuário gerado automaticamente pelo MongoDB.
> - <strong>id:</strong> Identificador de cada listagem de orçamento gerado.
> - <strong>name:</strong> Nome completo do usuário.
> - <strong>email:</strong> Endereço de email do usuário.
> - <strong>phone:</strong> Telefone do usuário.
> - <strong>details:</strong> Detalhes da solicitação do orçamento.
> - <strong>createdDate:</strong> Data de criação do orçamento.
> - <strong>updatedDate:</strong> Data de atualização de status da solicitação do orçamento.



### Coleção: Customer
Armazena as informações dos clientes cadastrados no sistema.

```Json
{
  "_id": {
    "$oid": "67a7c43c55f499fe1cfff4ec"
  },
  "id": "id-do-cliente",
  "name": "Nome do Cliente",
  "email": "email@cliente.com",
  "phone": "123456789",
  "address": "Rua de exemplo mais o número",
  "complement": "adcione um complemento",
  "zipCode": "coloque o cep de exemplo"
}
```

#### Descrição dos Campos
> - <strong>_id:</strong> Identificador único do usuário gerado automaticamente pelo MongoDB.
> - <strong>id:</strong> Identificador de cada listagem de cliente cadastrado.
> - <strong>name:</strong> nome do cliente.
> - <strong>email:</strong> email do cliente.
> - <strong>phone:</strong> telefone do cliente.
> - <strong>address:</strong> Endereço do cliente.
> - <strong>complement:</strong> complemento do Endereço.
> - <strong>zipCode:</strong> CEP do Endereço.

### Coleção: Solicitation
Armazena e salva as solicitações de serviço dos clientes.

Estrutura do Documento

```Json
{
  "_id": {
    "$oid": "67a7c3fa55f499fe1cfff4e6"
  },
  "id": "id-do-servico",
  "name": "Nome do Serviço",
  "description": "Descrição do Serviço",
  "price": "Preço do Serviço",
  "createdDate": "data-da-criacao",
  "updateDate": "data-da-atualizacao",
  "budgetId": "id de relacionamento com budget"
}
```

#### Descrição dos Campos
> - <strong>_id:</strong> Identificador único do produto gerado automaticamente pelo MongoDB.
> - <strong>id:</strong> Identificado de cada listagem de serviço gerado.
> - <strong>name:</strong> nome do serviço.
> - <strong>description:</strong> descrição detalhada do tipo do serviço.
> - <strong>price:</strong> preço de custo médio de cada serviço.
> - <strong>createdDate:</strong> data de criação da solicitação do serviço.
> - <strong>updateDate:</strong> data de atualizacao do status do serviço.
> - <strong>budgetId:</strong> relação com orçamento, um único orçamento poderá haver mais de um tipo de serviço.


### Coleção: users
Armazena as informações dos usuários do sistema.

Estrutura do Documento

```Json
{
  "_id": {
    "$oid": "670196168665658e8afd8bd1"
  },
  "name": "Matheus Oliveira Rosario",
  "email": "matheus_rosario@hotmail.com.br",
  "password": "123",
  "roles": "Admin"
}
```

#### Descrição dos Campos
> - <strong>_id:</strong> Identificador único do usuário gerado automaticamente pelo MongoDB.
> - <strong>name:</strong> Nome completo do usuário.
> - <strong>email:</strong> Endereço de email do usuário.
> - <strong>passwordHash:</strong> Hash da senha do usuário.
> - <strong>roles:</strong> Lista de papéis atribuídos ao usuário (por exemplo, admin, user).



