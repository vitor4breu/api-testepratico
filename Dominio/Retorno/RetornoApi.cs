using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Retorno
{
    public class RetornoApi<T>
    {
        public T Retorno { get; set; }
        public MensagemRetorno Mensagens { get; set; }


        public RetornoApi(T retorno, MensagemRetorno mensagens)
        {
            Retorno = retorno;
            Mensagens = mensagens;
        }




    }
}
