# ✨ Sejam bem vindos ao repositório do projeto Tryitter

Este projeto consiste em criar uma API para ser consumida por uma aplicação que se assemelha a uma rede social próxima ao Twitter.

<details>
<summary><strong>🍀 Endpoints:</strong></summary><br />

  - Fazer o login
  - Buscar todos os posts
  - Buscar post por id
  - Buscar último post do estudante :lock:
  - Adicionar post :lock:
  - Atualizar post :lock:
  - Deletar post :lock:
  - Buscar todos estudantes
  - Buscar um estudante por id
  - Adicionar um estudante
  - Atualizar o estudante :lock:
  - Deletar o estudante :lock:
</details>

### 🔎 Orientações

1. Clone o repositório e entre na pasta do projeto:

    - `cd Tryitter`
  
2. Instale as dependências:
   
    -  `dotnet restore`

3. Suba o container do banco de dados:
   
    - `docker-compose up -d`

4. Rode as migrations:
   
    - `dotnet ef database update`
  
OBS: este comando irá criar as tabelas Posts, Students e Modules e também será populada a tabela Modules. As outras tabelas do bancos encontram-se vazias. Para testar o seu funcionamento, rode aplicação e abra o Swagger para interagir com as rotas.

5. Entre na pasta Tryitter.Api:
   
   - `cd Tryitter.Api`

6. Rode a aplicação:
   
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
