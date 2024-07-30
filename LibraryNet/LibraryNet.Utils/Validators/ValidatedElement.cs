using System;

namespace LibraryNet.Utils.Validators
{
    public class ValidatedElement
    {
        public ValidatedElement(bool valido, string mensagem)
        {
            Invalido = valido;
            Mensagem = mensagem;
        }
        public bool Invalido { get; }
        public string Mensagem { get; }
    }
}
