# BattleRoyale-Remote-Control - Aplicativo Web
Desafio lançado pelo Instituto Atlântico. Gerenciamento de máquinas clientes via linha de comando através de um servidor Web.

## Executando o código-fonte
#### Para executar o código-fonte, você precisará das seguintes ferramentas:
* Visual Studio 2015 ou superior
* .Net Core SDK
* NPM instalado

Feito isso, basta clonar o repositório, abrir a solução e compilar.

## Executando a aplicação e cadastrando os clientes
1. Para cadastrar clientes, é necessário que a máquina cliente esteja executando o Windows Service cliente (código e instruções aqui: https://github.com/vanilsonbr/BattleRoyale-Remote-Control-Client).
2. Rode o aplicativo Web.
3. Verifique qual é o seu IP Local (cmd > ipconfig > procurar por **Endereço IPv4**)
4. No arquivo .config do cliente Windows Service, altere o termo **localhost** para o IP Local.
5. Inicie/Reinicie o cliente Windows Service para que ele se cadastre na aplicação web e apareça no painel.

Tambem é possível cadastrar qualquer outra máquina que esteja na mesma rede local, bastando apenas executar os passos 3, 4 e 5

Com estes passos feitos, voce verá os clientes cadastrados no servidor e poderá executar comandos do CMD neles.

## À equipe de avaliação do Instituto Atlântico
Me esforçei bastante para entregar a aplicação web com todos os requisitos pedidos. Por falta de tempo hábil, resolvi focar na implementação
e fazer os testes ao longo do caminho. Os bugs existem, mas tentei eliminá-los pela raiz durante a implementação mesmo, planejando tudo com calma.

Dos projetos em que trabalhei até hoje (React/Redux, ASP NET, Qt, entre outros), poucos deles foram com SPA, então ainda estou aprendendo.
Tive uma evolução rápida nessa semana em que fiz este projeto. Embora simples, pude aprender muito, e quero continuar aprendendo.

Alguns pontos de melhoria:
* **Persistir as informações dos clientes conectados**: Nesta versão da aplicação web, usei uma classe C# como singleton para armazenar os
clientes que vão se cadastrando na aplicação Web, mas para que ficasse mais interessante, uma base de dados NoSql, como por exemplo um MongoDb
poderia fazer isso para mim.
* **Fazer os testes unitários para o front-ed**: Eu gostaria de ter começado este projeto com TDD, o que com toda certeza é um passo crucial para o desenvolvimento do sotware,
mas como tinha pouco tempo hábil e o trabalho no escritório, resolvi começar pela implementação, como já havia dito. Quero aprender e ter conhecimentos sólidos de testes
com bibliotecas de javascript. Isso me ajudará bastante e ajudará bastante a equipe.

Muito obrigado pela oportunidade e espero que gostem do código! Qualquer dúvida, reclamação, crítica, estou à disposição para ouvir.
É sempre bom saber como está meu trabalho através de um feedback. :)

