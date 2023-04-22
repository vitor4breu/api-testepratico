namespace Dominio.Retorno
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
