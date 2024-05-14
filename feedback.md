## Pontos Fortes
- Nomenclatura clara e simples
- Organizacao basica porem simples
## Pontos Fracos
- ContratacaoController RealizarContratacaoAsync aplicar o pattern Command para reduzir o numero de parametros utilizados, limitar a 3 no maximo
- ContratacaoController linha 36/37 falta seguir o padrao de retorno em caso de falha com uma mensagem clara
- Remover comentarios desnecessarios do codigo
- As chamadas estao retornando NULL poderiam utilizar o pattern Notification
- No EF Core utilizar a fluent api
- Falta logs na aplicacao e no tratamento de erro
- Projeto de infraestrutura nao esta sendo usado para nada
- Falta de testes de unidade