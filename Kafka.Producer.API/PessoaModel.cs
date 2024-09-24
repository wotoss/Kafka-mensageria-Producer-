using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kafka.Producer.API
{
    //vamos este modelo via mensagem.
    public class PessoaModel
    {
        public string? nome { get; set; }

        public int idade { get; set; }
    }
}