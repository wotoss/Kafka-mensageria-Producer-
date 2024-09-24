# Mensageria com Kafka - Projeto console.

Estamos usando três projetos 
## 1º projeto - /Kafka/docker-compose.yml
Ao chegar na pasta Kafka damos um code .

Logo que abrimos o projeto docker digitamos o comando
docker compose pull => baixamos os containner 


## 2º projeto - /KAFKA.PRODUCER.API
Abrir o projeto na pasta /KAFKA.PRODUCER.API
dou o comando code .

Lembrando que este projeto:
(produzir as informações as mensagens).

## 3º projeto - /KAFKA.CONSUMER.CONSOLE
Ao chegar nesta pasta /KAFKA.CONSUMER.CONSOLE
dou o comando code .

Lembrando que o consumer vai trabalhar em background(pano de fundo).

Ficará (escultando e consumindo) as mensagens ou ações.

### Instalação
dotnet add package Confluent.kafka

instalar um pacote "opensource" que nós permite a conectar aos kafka.
é um cliente para nós conectarmos ao apache kafka

### Instalação no consummer
dotnet add package Microsoft.Extensions.Hosting
Instalamos no Consummer 
Para deixar a aplicação rodando em background

### Extensão Recomendadas para o VSCode

Instale as seguintes extensões no VSCode para facilitar o desenvolvimento com .NET:

.NET Extension: Extensão para adicionar suporte completo ao .NET no VSCode



