# Documentação da API

API Responsável pela manipulação de compromissos

### Rota Inicial Azure
```
compromissos-api.azurewebsites.net
```
---
## InserirCompromisso

Endpoint responsável por inserir um compromisso no banco de dados.

### Rota

```
POST /api/compromissos
```

### Corpo

- `compromisso` - Objeto com a data e o texto do compromisso a ser inserido.

### Resposta

Retorna o Id do compromisso inserido.

### Exemplo

```
curl -X 'POST' \
  'https://compromissos-api.azurewebsites.net/Compromisso/InserirCompromissos' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "2022-04-20T15:46",
  "texto": "Texto teste"
}'
```

---
## ObterCompromissos

Endpoint responsável por obter todos os compromissos existentes.

### Rota

```
GET /api/compromissos
```

### Resposta

Retorna uma lista com todos os compromissos existentes.

### Exemplo

```
curl -X 'GET' \
  'https://compromissos-api.azurewebsites.net/Compromisso/ObterCompromissos' \
  -H 'accept: */*'
```

---
## ObterCompromisso

Endpoint responsável por obter determinado compromisso de acordo com o Id inserido.

### Rota

```
GET /api/compromissos/{idCompromisso}
```

### Parâmetros

- `idCompromisso` - Id do compromisso a ser obtido.

### Resposta

Retorna um objeto com a data e o texto do compromisso.

### Exemplo

```
curl -X 'GET' \
  'https://compromissos-api.azurewebsites.net/Compromisso/ObterCompromisso/1' \
  -H 'accept: */*'
```
---
## AlterarCompromisso

Endpoint responsável por alterar um compromisso existente no sistema de acordo com o Id inserido.

### Rota

```
PUT /api/compromissos
```
### Corpo

- `compromisso` - Objeto com o Id, o texto e a data do compromisso a ser alterado.

### Resposta
Retorna um booleano referente ao sucesso na alteração do compromisso.
---

### Exemplo

```
curl -X 'PUT' \
  'https://compromissos-api.azurewebsites.net/Compromisso/AlterarCompromisso' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "2023-04-20T15:48",
  "texto": "Teste Texto Alteração",
  "id": 1
}'
```

## DeletarCompromisso

Endpoint responsável por deletar um compromisso de acordo com o Id inserido.

### Rota

```
DELETE /api/compromissos/{idCompromisso}
```

### Parâmetros

- `idCompromisso` - Id do compromisso a ser deletado.

### Resposta

Retorna um booleano referente ao sucesso ao deletar o compromisso.

### Exemplo

```
curl -X 'DELETE' \
  'https://compromissos-api.azurewebsites.net/Compromisso/DeletarCompromisso/1' \
  -H 'accept: */*'
```
---
