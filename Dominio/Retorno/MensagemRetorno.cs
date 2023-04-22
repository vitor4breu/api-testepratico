namespace Domain.Retorno
{
    public class MensagemRetorno
    {
        public List<string> Erros { get; } = new List<string>();
        public List<string> Avisos { get; } = new List<string>();

        public bool ContemErro => Erros.Count > 0;
        public bool ContemAviso => Avisos.Count > 0;

        public void AdicionarErro(string erro) => Erros.Add(erro);
        public void AdicionarAviso(string aviso) => Avisos.Add(aviso);

    }
}
