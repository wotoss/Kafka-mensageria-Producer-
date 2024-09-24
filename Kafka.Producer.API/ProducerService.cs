
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Confluent.Kafka;
using System.Text.Json;

namespace Kafka.Producer.API
{
    public class ProducerService
    {
      //vamos usar o configuration que vou recuperar os valores do (appsettings)
      private readonly IConfiguration _configuration;
      //este config é a configuração do nosso client
      private readonly ProducerConfig _producerConfig;
      //uma variavel de log para trazemos os logs da API
      private readonly ILogger<ProducerService> _logger;
    
      //contrutor para receber configuration por injeção de dependencia.
    public ProducerService(IConfiguration configuration, ILogger<ProducerService> logger)
    {
        //vamos pegar uma sessão do nosso appsettings
         _configuration = configuration;
         _logger = logger;

         
        var bootstrap = _configuration.GetValue<string>("KafkaConfig:BootstrapServer");
  
        //var bootstrap = _configuration.GetSection("KafkaConfig").GetSection("BootstrapServer").Value;    
        _producerConfig = new ProducerConfig()
        {
            //vamos iniciarlizar - vamos definir o local que vamos iniciar nosso (cliente kafka).
            BootstrapServers = bootstrap
        };

    }
     //neste método nós vamos enviar uma mensagem para o  (broker)
    public async Task<string> SendMessage(PessoaModel pessoa)
    {
            /*
            outro exemplo de como fazer.
            var topic = _configuration.GetSection("KafkaConfig").GetSection("TopicName"); 
            */
            var topic = _configuration.GetValue<string>("KafkaConfig:TopicName"); 
            
            try
            {       
                using(var producer = new ProducerBuilder<Null, string> (_producerConfig).Build())
                {
                    var message = JsonSerializer.Serialize(pessoa);
                    var result = await producer.ProduceAsync(topic: topic, new () { Value = message });
                    //poderia lêr no console desta forma: Console.WriteLine();               
                    _logger.LogInformation("=================[ Lendo no Console - Kafka ]=================");
                    _logger.LogInformation(result.Status.ToString() + " - " + message);
                    return result.Status.ToString() + " - " + message;
                }
            }
            catch
            {
                _logger.LogError("Erro ao enviar mensagem");
                return "Erro ao enviar mensagem";
            }
        } 
    }
}
