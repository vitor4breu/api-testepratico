using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RetornoApi<T>
    {
        public T Retorno { get; set; }
        public bool ContemErro { get; set; }


        public RetornoApi(T retorno, bool contemErro)
        {
            Retorno = retorno;
            ContemErro = contemErro;
        }




    }
}
