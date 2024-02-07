# Gerenciador de Notícias


OBSERVAÇÕES:

* A branch cqrs_camada_negocio possui a implementação do serviço na camada de aplicação mas não vou tempo de finalizar tudo.
* Optei por não alterar a estrutura principal do projeto mas recomendo que seja criado um projeto específico para entidades do domínio independente do projeto Dados (Persistencia).
* Optei por utilizar sqlite inicialmente para simplificar a entrega da versão inicial. Instale um cliente sqlite para visualizar a base de dados.
  * Instale o [Cliente SQLiteBrowser](https://sqlitebrowser.org/dl/)
  * Execute o cliente sqlite
  * Selecione 'Arquivo > Abrir banco de dados' para exibir a caixa de diálogo 'Escolha um arquivo do banco de dados'
  * Navegue para pasta do projeto 'ICI.ProvaCandidato.Web' e selecione o arquivo 'gerenciadornoticias.db'
* Optei por não alterar o tipo do identificador 'Id' mas recomendo que seja alterado para string para reduzir a dependência entre frontend e backend ao permitir a criação de identificadores do tipo Guid no frontend.
* No meu entendimento, a estrutura fornecida objetiva verificar meus conhecimentos relacionados ao uso da tecnologia Razor para o frontend em uma aplicação asp.net mvc.
* Recomendo adotar o padrão BEM (Block Element Modifier) para estilização da aplicação.
* Utilize o comando abaixo para atualizar a base de dados se necessário

	dotnet ef database update InitialCreate -p ICI.ProvaCandidato.Dados/ -s ICI.ProvaCandidato.Web/

ATIVIDADES:

* Barra de Ferramentas 
  * Criado estilo '.action-toolbar' para formatação barra de ferramentas inline utilizada em tabelas para ações de editar, excluir, etc.
  * Utilizado elemento 'ol' para melhorar a acessibilidade da barra de ferramentas inline.
  * 

REFERÊNCIAS:

* [jQuery DataTable](https://datatables.net/)
* [Bootbox](https://bootboxjs.com/)
* 
