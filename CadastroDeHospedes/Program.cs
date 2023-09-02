//using CadastroDeHospedes;
using System;

namespace CadastroDeHospedes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criação de um vetor do tipo Cadastro com a quantidade informada pelo usuário
            Console.Write("Informe quantos quartos serão disponibilizados: ");
            int qtdQuartos = int.Parse(Console.ReadLine());
            Cadastro[] cadastros = new Cadastro[qtdQuartos];
            Console.WriteLine();
            Console.WriteLine();

            //Laço while principal que define qual case será executado
            int opcao = 0;
            while (opcao != 5)
            {
                Console.Clear();
                Console.WriteLine("ESCOLHA A OPÇÃO DESEJADA");
                Console.WriteLine("     1 - CADASTRAR ALUGUEL");
                Console.WriteLine("     2 - EXCLUIR ALUGUEL");
                Console.WriteLine("     3 - LISTAR QUARTOS OCUPADOS");
                Console.WriteLine("     4 - LISTAR QUARTOS VAGOS");
                Console.WriteLine("     5 - SAIR");
                Console.WriteLine();
                Console.Write("OPÇÃO ESCOLHIDA............: ");
                opcao = int.Parse(Console.ReadLine());
                while (opcao < 1 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("OPÇÃO ESCOLHIDA............: ");
                    opcao = int.Parse(Console.ReadLine());
                }

                char continuar = 's';
                int numQuarto;
                switch (opcao)
                {
                    //Case 1 - responsável pelo cadastro de um novo aluguel
                    case 1:
                        {
                            while (continuar != 'n' && continuar != 'N')
                            {
                                Console.Clear();
                                Console.Write("Informe o nome: ");
                                string nome = Console.ReadLine();
                                Console.Write("Informe o e-mail: ");
                                string email = Console.ReadLine();
                                Console.Write("Informe o número do quarto desejado: ");
                                numQuarto = int.Parse(Console.ReadLine());
                                numQuarto = numQuarto - 1;
                                if (cadastros[numQuarto] == null)
                                {
                                    cadastros[numQuarto] = new Cadastro() { Nome = nome, Email = email };
                                }
                                else
                                {
                                    int tentativas = 1;
                                    while (cadastros[numQuarto] != null && tentativas < 4)
                                    {
                                        Console.WriteLine("Esse quarto já está ocupado!");
                                        Console.Write("Informe outro número de quarto: ");
                                        numQuarto = int.Parse(Console.ReadLine());
                                        numQuarto = numQuarto - 1;
                                        tentativas++;
                                    }
                                    if (cadastros[numQuarto] == null)
                                        cadastros[numQuarto] = new Cadastro() { Nome = nome, Email = email };
                                    if (tentativas > 3)
                                        Console.WriteLine("Número de tentativas excedidas!");
                                }

                                Console.Write("Deseja cadastrar outro aluguel (S/N)? ");
                                continuar = char.Parse(Console.ReadLine());
                            }
                            break;
                        }
                    //Case 2 - responsável pelo exclusão da locação de um quarto
                    case 2:
                        {
                            Console.Write("Informe o número do quarto para excluir: ");
                            numQuarto = int.Parse(Console.ReadLine());
                            if (numQuarto <= 0 || numQuarto > qtdQuartos)
                                Console.WriteLine("Essa numeração de quarto não existe!");
                            else
                            {
                                numQuarto = numQuarto - 1;
                                cadastros[numQuarto] = null;
                                Console.WriteLine("Exclusão realizada com sucesso!");
                            }
                            Console.ReadKey();
                            break;
                        }
                    //Case 3 - responsável por listar quartos ocupados
                    case 3:
                        {
                            Console.Clear();
                            for (int i = 0; i < qtdQuartos; i++)
                            {
                                if (cadastros[i] != null)
                                    Console.WriteLine("Quarto {0}, Nome: {1}, e-mail: {2}", i + 1, cadastros[i].Nome, cadastros[i].Email);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Precione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    //Case 4 - responsável por listar quartos vagos
                    case 4:
                        {
                            Console.Clear();
                            for (int i = 0; i < qtdQuartos; i++)
                            {
                                if (cadastros[i] == null)
                                    Console.WriteLine("Quarto vago: {0}", i + 1);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Precione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}