# Gerenciador de Not�cias


OBSERVA��ES:

* A branch cqrs_camada_negocio possui a implementa��o do servi�o na camada de aplica��o mas n�o vou tempo de finalizar tudo.
* Optei por n�o alterar a estrutura principal do projeto mas recomendo que seja criado um projeto espec�fico para entidades do dom�nio independente do projeto Dados (Persistencia).
* Optei por utilizar sqlite inicialmente para simplificar a entrega da vers�o inicial. Instale um cliente sqlite para visualizar a base de dados.
  * Instale o [Cliente SQLiteBrowser](https://sqlitebrowser.org/dl/)
  * Execute o cliente sqlite
  * Selecione 'Arquivo > Abrir banco de dados' para exibir a caixa de di�logo 'Escolha um arquivo do banco de dados'
  * Navegue para pasta do projeto 'ICI.ProvaCandidato.Web' e selecione o arquivo 'gerenciadornoticias.db'
* Optei por n�o alterar o tipo do identificador 'Id' mas recomendo que seja alterado para string para reduzir a depend�ncia entre frontend e backend ao permitir a cria��o de identificadores do tipo Guid no frontend.
* No meu entendimento, a estrutura fornecida objetiva verificar meus conhecimentos relacionados ao uso da tecnologia Razor para o frontend em uma aplica��o asp.net mvc.
* Recomendo adotar o padr�o BEM (Block Element Modifier) para estiliza��o da aplica��o.
* Utilize o comando abaixo para atualizar a base de dados se necess�rio

	dotnet ef database update InitialCreate -p ICI.ProvaCandidato.Dados/ -s ICI.ProvaCandidato.Web/

ATIVIDADES:

* Barra de Ferramentas 
  * Criado estilo '.action-toolbar' para formata��o barra de ferramentas inline utilizada em tabelas para a��es de editar, excluir, etc.
  * Utilizado elemento 'ol' para melhorar a acessibilidade da barra de ferramentas inline.
  * 

REFER�NCIAS:

* [jQuery DataTable](https://datatables.net/)
* [Bootbox](https://bootboxjs.com/)
* 
