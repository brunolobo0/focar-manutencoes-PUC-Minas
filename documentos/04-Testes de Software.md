# Planos de Testes de Software

Casos de testes utilizados na realização da verificação e validação da aplicação. Abaixo estão os cenários de testes que estão demonstrando os requisitos sendo satisfeitos bem como o tratamento de erros (robustez da aplicação).

### Tipo de Teste
- **Sucesso**: Tem o objetivo de verificar se as funcionalidades funcionam corretamente.
- **Insucesso**: Tem o objetivo de verificar se o sistema trata erros de maneira correta.

#### Exemplo de Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-001<br>Solicitação de Orçamento Válida</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Este caso de teste verifica se todos os campos obrigatórios estão preenchidos para a solicitação ser validada.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Diogo Victor Santos Silva</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
  <td><strong>Requisitos associados</strong></td>
    <td>RF-001: O usuário deve conseguir enviar uma solicitação de orçamento</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Abrir o site.<br>
      2. Inserir nome e sobrenome.<br>
      3. Inserir e-mail válido.<br>
      4. Inserir telefone.<br>
      5. Inserir a mensagem de solicitação.<br>
      5. Clicar no botão "Enviar"<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Nome Completo:</strong> Colocar nome e sobremone<br>
      - <strong>E-mail:</strong> Colocar e-mail válido<br>
      - <strong>Telefone:</strong> Colocar número de telefone<br>
      - <strong>Mensagem:</strong> Colocar a mensagem de solicitação<br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
     <td>O sistema deve armazenar com sucesso todos os dados da solicitação no banco de dados.</td>
  </tr>
</table>

#### Exemplo de Caso de Teste de Insucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-002<br>Solicitação de Orçamento Inválida</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Este caso de teste analisa os dados não preenchidos.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Diogo Victor Santos Silva</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Insucesso</td>
    </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-001: O usuário não conseguirá enviar a solicitação.</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Abrir o site.<br>
      2. Deixar algum campo em branco.<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>:</strong><br>
      - <strong>:</strong> 
       </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O sistema deve apresentar a mensagem de campo obrigaório em branco.</td>
  </tr>
</table>


#### Exemplo de Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-003<br>Cadastro de Usuário</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Este caso de teste verifica se um usuário é cadastrado com os dados válidos.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Diogo Victor Santos Silva</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
  <td><strong>Requisitos associados</strong></td>
    <td>RF-001: O usuário deve conseguir cadastrar no site</td>
      </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Abrir o site.<br>
      2. Inserir nome completo.<br>
      3. Inserir e-mail válido.<br>
      4. Inserir senha.<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Nome Completo:</strong> Colocar nome e sobremone<br>
      - <strong>E-mail:</strong> Colocar e-mail válido<br>
      - <strong>Senha:</strong> Colocar a senha.<br>
        </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
     <td>O sistema deve armazenar com sucesso todos os dados do usuário no banco de dados.</td>
  </tr>
</table>

#### Exemplo de Caso de Teste de Insucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-004<br>Cadastro de Usuário Inválido</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
        <td>Este caso de teste verifica o tratamento de credenciais inválidas no cadastro de usuário.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Diogo Victor Santos Silva</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Insucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-001: O Usuário não conseguirá cadastrar no site</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Abrir o site.<br>
      2. Inserir o e-mail inválido.<br>
      3. Inserir a senha inválida.<br>
      4. Clicar no botão "Entrar".
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>E-mail:</strong> Colocar e-mail inválido<br>
      - <strong>Senha:</strong> Colocar senha inválida
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O sistema deve apresentar a mensagem de cadastro inválido.</td>
  </tr>
</table>







 
# Evidências de Testes de Software

Apresente imagens e/ou vídeos que comprovam que um determinado teste foi executado, e o resultado esperado foi obtido. Normalmente são screenshots de telas, ou vídeos do software em funcionamento.

Imagem de validação do cadastro

![Image](https://github.com/user-attachments/assets/5e0c0d9f-541f-447a-98fb-9fbca5930504)

Integração de solicitação de orçamento com o MongoDB

https://github.com/user-attachments/assets/fa7d5735-163a-4a9f-9764-88325510ff8d

Integração de cadastro com o MongoDB

https://github.com/user-attachments/assets/fcdc764b-29a6-4b97-bdb8-f6a14e8e4dd7

## Parte 1 - Testes Unitários
Cada funcionalidade desenvolvida deve ser testada utilizando os casos de testes (sucesso e insucesso) criados pelo responsável pela funcionalidade. Todos os testes devem ser evidenciados.

### Exemplo
<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br>Login com credenciais válidas</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve redirecionar o usuário para a página inicial do aplicativo após o login bem-sucedido.</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">José da Silva </td>
     <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">08/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo o login corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-time-sheet/assets/82043220/2e3c1722-7adc-4bd4-8b4c-3abe9ddc1b48"/></td>
  </tr>
</table>

## Parte 2 - Testes por pares
A fim de aumentar a qualidade da aplicação desenvolvida, cada funcionalidade deve ser testada por um colega e os testes devem ser evidenciados. O colega "Tester" deve utilizar o caso de teste criado pelo desenvolvedor responsável pela funcionalidade (desenvolveu a funcionalidade e criou o caso de testes descrito no plano de testes).

### Exemplo
<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br funcionalidade de obtenção de valores no banco</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve buscar os dados do banco de Orçamento de dados pelo service.</td>
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">Érica Rodrigues Almeida Almarim </td>
      <td><strong>Responsável pelo teste</strong></td>
    <td width="430">Matheus Oliveira Rosário </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">02/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo obter os dados corretamente</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/90b21961-1df8-4863-8109-e233cb055cb3"/></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br funcionalidade de obtenção de valores no banco</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve buscar os dados do banco de Fornecedor de dados pelo service.</td>
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">Matheus Oliveira Rosário </td>
      <td><strong>Responsável pelo teste</strong></td>
    <td width="430">Érica Rodrigues Almeida Almarim </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">02/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo obter os dados corretamente</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/7cf67bbc-58b8-467f-9255-fe0f8d50fc5b"/></td>
  </tr>
</table>


<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br funcionalidade de obtenção de valores no banco</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve buscar os dados do banco de Solicitação de dados pelo service.</td>
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">Diogo Victor Santos Silva </td>
      <td><strong>Responsável pelo teste</strong></td>
    <td width="430">Nathan Teixeira Rizzatte </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">02/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo obter os dados corretamente</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/54417429-99b3-48b5-9375-68643e3f7acb"/></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br funcionalidade de obtenção de valores no banco</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve buscar os dados do banco de Usuário de dados pelo service.</td>
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">Nathan Teixeira Rizzatte </td>
      <td><strong>Responsável pelo teste</strong></td>
    <td width="430">Diogo Victor Santos Silva </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">02/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo obter os dados corretamente</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src=https://github.com/user-attachments/assets/f27ce825-63ad-47b0-b004-1f43ad47066b"/></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br CRUD COMPLETO FORNECEDOR</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve Criar, Editar, Vizualizar os Forncedores. 
      O sistema deve Pesquisar os Fornecedores por Nome Fantasia, Razão Social e CNPJ</td>
    
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
      <td width="430">Matheus Oliveira Rosário </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">31/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Está sendo possível criar, editar e vizualiar os forncedores. O campo pesquisa está funcional.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
   <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/86787207-8faf-45b0-a430-c6c9ec375e6a"/></td>
  </tr>
</table>


<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br>CRUD COMPLETO LOGIN_CADASTRO</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve permitir o cadastro de usuários, solicitando obrigatoriamente os campos: Nome de usuário, E-mail e Senha. O sistema deve permitir também a edição e visualização dos dados do usuário.</td>
  </tr>
  <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">Anthony Gabriel Santana dos Santos</td>
    <td width="100"><strong>Data do teste</strong></td>
    <td width="150">01/06/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Está sendo possível cadastrar, editar e visualizar os dados dos usuários. A autenticação com e-mail e senha está funcional.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
   <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/e4cce327-3ef1-4adf-bd60-c858b78332be"/></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br CRUD COMPLETO DE ORÇAMENTO</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve Criar, Editar e Visualizar Orçamentos. O sistema deve permitir a inclusão de produtos, cálculo do valor total e salvar o orçamento com status.</td>
    
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
      <td width="430">Erica Rodrigues Almeida Almarim</td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">01/06/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Está sendo possível criar, editar e visualizar os orçamentos. Os produtos são adicionados corretamente e o valor total é calculado conforme esperado.</td>
  </tr>
  <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
   <td colspan="6" align="center"><video src="https://github.com/user-attachments/assets/ae32cb10-9f0a-43cd-8f13-f5b075efe039"/></td>
  </tr>
</table>
     
<table>
<th colspan="6" width="1000">CT-001<br CRUD COMPLETO DE SOLICITAÇÃO</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve Criar, Editar e Visualizar as Solicitações.</td>
    
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
      <td width="430">Diogo Victor Santos Silva</td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">01/06/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Está sendo possível criar, editar e visualizar as Solicitações. Estão sendo são adicionados corretamente conforme o teste abaixo.</td>
  </tr>
  <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
   <td colspan="6" align="center"><video src=https://github.com/user-attachments/assets/250d1acb-2746-40f2-b60b-d41c3bc33dda/></td>
  </tr>
</table>

