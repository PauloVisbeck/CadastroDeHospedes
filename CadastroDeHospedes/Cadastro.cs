using System;
namespace CadastroDeHospedes
{
    internal class Cadastro
    {
        //Atributo privado (Acesso através da Propriedade Nome)
        private string _nome;
        //Propriedade autoimplementada
        public string Email { get; set; }

        //Propriedade customizada (Faz as tratativas de acesso ao atributo _nome)
        public string Nome
        {
            set
            {
                if (value != null && value.Length > 0)
                    _nome = value;
                else
                    Console.WriteLine("Nome Inválido!");
            }
            get
            {
                return _nome;
            }
        }

    }
}
