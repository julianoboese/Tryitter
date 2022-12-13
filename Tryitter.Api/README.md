# ✨ Sejam bem vindos ao repositório do projeto Tryitter

Este projeto consiste em criar uma API para ser consumida por uma aplicação que se assemelha a uma rede social próxima ao Twitter.

<details>
<summary><strong>🍀 Endpoints:</strong></summary><br />

  - Fazer o login
  - Buscar todos os posts
  - Buscar post por id do estudante
  - Buscar último post de um estudante
  - Adicionar post
  - Atualizar post
  - Deletar post
  - Buscar todos estudantes
  - Buscar por id um estudante
  - Adicionar um estudante
  - Atualizar um estudante
  - Deletar um estudante
</details>

### 🔎 Orientações

1. Clone o repositório:

   - `https://github.com/julianoboese/Tryitter`

   - Entre na pasta do repositório:

    - `cd Tryitter`
  

2. Instale as dependências com:
   
     -  `dotnet restore`

3. Suba o container do banco de dados com:
   
     - `docker-compose up -d`

4. Use o comando abaixo para rodar as migrations:
   
   - `dotnet ef database update`
  
  OBS: este comando irá criar as tabelas POST, STUDENTS e MODULE, também será populada a tabela Module. As outras tabelas do bancos encontram-se vazias, para testar o seu funcionamento, rode aplicação e abra o Swagger para interagir com as rotas.

5. Entre na pasta Tryitter.Api:
   
   - `cd Tryitter.Api:`

6. Para rodar a aplicação:
   
   - `dotnet run`

7. O link para o Swagger:
     - `https://localhost:7143/swagger/index.html`


<details>
<summary><strong>🍀 Melhorias:</strong></summary><br />

   - Melhorar Swagger
   - Fazer o deploy da aplicação
   - Fazer possíveis melhorias de refatoração, e até mesmo implantação de novos recursos.

</details>


 ✨ Este projeto foi desenvolvido por: 
  - Juliano Boese 
  - Marcela Arroyo 
  - Bárbara Queiroz