using System;

namespace Cadmus.Dominio
{
    public class ResponseApi
    {
        public ResponseApi(bool sucesso, string mensagem, object dados = null)
        {
            if (mensagem == null)
                throw new ArgumentException($"'{nameof(mensagem)}' não pode ser nulo.", nameof(mensagem));
            
            Mensagem = mensagem;
            Sucesso = sucesso;

            if (dados != null)
                Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem  { get; set; }
        public object Dados { get; set; }
    }
}
