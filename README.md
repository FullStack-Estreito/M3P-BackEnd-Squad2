# M3P-BackEnd-Squad2
LabSchool Manager - Gestão de Atendimentos Escolares

 - Escopo do Projeto
A LABSchool Edu, empresa líder no segmento tecnológico de gestão educacional, foi
selecionada em edital e recebeu um aporte financeiro para aprimorar seu principal produto,
o LABSchool Manager. A expectativa é desenvolver um novo sistema no formato white-label,
capaz de ser personalizado e comercializado para escolas e demais instituições de ensino de
todo o país.
O modelo white-label consiste em um software padrão que pode ser personalizado com as
cores, tipografias, logotipos e demais elementos visuais da identidade do cliente,
proporcionando um resultado personalizado.

- Requisitos do sistema
Para construção do sistema LabSchool Manager foram utilzados as seguintes ferramentas:
Skills: Organização com Trello, criação de documentação e apresentação de solução;
MySQL Workbench: Documentaçao dos bancos de dados SQL;
Versionamento: Uso do GitHub para versionamento de código;
IDE utilizada: Visual Studio Code;
Banco de dados: SQL Server;
Programação WEB(API): C#, .NetFramework;

- Descritivo para execução do sistema
Considerando que os procedimentos para execução via linha de comando do GitHub estejam instalados, segue:
Escolher um diretório da sua preferência;
Clicar com o botão direito e escolhar a opção, (git Bash Here);
Executar a linha de comando: (git init);
Executar a linha de comando: (git clone URL); Copiar a URL do repositório do GitHub onde a aplicação está armazenada;
Comando: git clone https://github.com/FullStack-Estreito/M3P-BackEnd-Squad2.git

No mesmo diretório onde foi efetuado o clone(download) do sistema, executar a linha de comando (code .) para abrir o Visual Studio Code;
Depois de aberto o Visual Studio Code, clicar na barra superior, opção (New Terminal) para abrir um terminal para digitação dos comandos necessários para execução do sistema, segue os comandos:

            cd Backend <posicionar o prompt do terminal no diretório onde está a aplicação>
            dotnet run <execução/compilação do sistema e demais inicializações dos pacotes>

Se a execução do comando (dotnet run) ocorrer sem erros de compilação, deverá ser exibido no terminal a seguinte mensagem(exemplo):

info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5009
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\angelo.souza\source\repos\M3P-BackEnd-Squad2\Backend\Backend

--------------------------------------------------------------------------------------

Com a API (Back_End) em execução no servidor local (http://localhost:5009), pode-se executar o projeto do Front_End, as instruções 
para execução encontram-se no README do Front_End;

FIM
