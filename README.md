# Projeto de uma API de Autenticação

- Este projeto foi criado para estudo. A ideia é criar uma API de Autenticação, porém inicialmente foi criados os Endpoints para a Entidade Produto com os métodos HTTP GET, POST, PUT e DELETE.

---
# Estrutura do Projeto

- Este projeto é composto por 5 (cinco) projetos dentro da Solução AuthApi, sendo eles:
  - AuthApi -> Projeto Principal
  - Domain -> Projeto de Classes, onde nele contém as Entidades, Enums e Constantes
  - Infra -> Projeto de Classes, onde nele contém as Extensões de Métodos de Tipos primitivos, como por exemplo: StringExtensions.
  - Repository -> Projeto de Classes, responsável por fazer a conexão com o Banco de Dados, utilizando a biblioteca EntityFrameWork. Nele também contém pastas como a de Migrations entre outras.
  - Service -> Projeto de Classes, responsável pela lógica e regra de negócio envolvendo os dados obtidos pela camada Repository

---
# Tecnologias Utilizadas

- EntityFrameWork
  - Migrations
  - CLI
- LINQ
- Dapper
- SQL Server

---
# Planos para o Futuro

- Realizar a autenticação e retornar um Token JWT.
- Realizar a autenticação SSO com o Google.
