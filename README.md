Montei o projeto numa estrutura DDD. Com camadas de Dominio, Infra, Servicos, Rest e Api.
Também segui no desenvolvimento Database First, criando antes o banco de dados e depois mapeando todas as tabelas.

Optei por criar mais uma entidade, que faça relacionamento com Pedido e Produto, para gravar vários produtos em um pedido.
Não criei o campo Número da entidade Pedido, pelo fato do Id já ser único e sequencial.

O Script de criação das tabelas está no arquivo ScriptDB.txt.
