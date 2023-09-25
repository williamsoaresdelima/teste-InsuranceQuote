# Exame Prático Stack .NET

Esta aplicação consiste em efetuar cálculo para cotação de seguro veicular 

A api deste projeto foi feito com [.Net 7](https://learn.microsoft.com/en-us/dotnet/), [Docker]() e [Postgres]().\
O frontend deste projeto foi feito com [Create React App](https://github.com/facebook/create-react-app).


## Projeto feito por 
William Soares de Lima.\
[![](https://skillicons.dev/icons?i=github)](https://github.com/williamsoaresdelima)

## Rodandos os projetos
### Criando banco de dados e iniciando a api

Para este projeto será usado docker com postgres.\

Criando container no docker
### `docker run --name InsuranceQuote -e POSTGRES_PASSWORD=admin -e POSTGRES_USER=admin -p 5455:5432 -d postgres`

No console do visual studio rodar o comando para criar as tabelas no docker
### `add-migration migrationInsureQuote`

Atualizar o banco de dados após gerar a migration
### `update-database`

## Inicializando o frontend

No diretorio do projeto, você pode usar:

### `npm start`

Roda a aplicação no modo desenvolverdor.\
Abra [http://localhost:3000](http://localhost:3000) para ver no navegador.

### `npm run build`

Builds o app para a pasta `build`.\
Ele agrupa corretamente o React no modo de produção e otimiza a construção para o melhor desempenho.

A compilação é reduzida e os nomes dos arquivos incluem os hashes.\
Seu aplicativo está pronto para o deploy!

Veja a seção sobre [deploy](https://facebook.github.io/create-react-app/docs/deployment) para mais informações.


## Tecnologias usadas
[![My Skills](https://skillicons.dev/icons?i=dotnet,react,typescript,docker,mysql,postgres&perline=3)](https://skillicons.dev)
