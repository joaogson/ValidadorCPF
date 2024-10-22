
using System;
using ValidadorCPF.Entities;
using ValidadorCPF.Services;

namespace ValidadorCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            CPFvalidator validator = new CPFvalidator();


            bool menu = true;

            while (menu)
            {
                Console.Clear();
                Console.WriteLine("1. Adicionar CPF");
                Console.WriteLine("2. Remover CPF");
                Console.WriteLine("3. Listar CPF's");
                Console.WriteLine("4. Sair");

                char opc = char.Parse(Console.ReadLine());

                switch (opc)
                {
                    case '1':

                        Console.Clear();
                        Console.WriteLine("Informe um CPF válido: ");
                        string serialAdicionar = Console.ReadLine();
                        Console.Clear();
                        CPF cpf = new CPF(serialAdicionar, validator);
                        Console.ReadKey();

                        break;
                    case '2':

                        Console.Clear();
                        Console.WriteLine("Informe o cpf no formato (xxx.xxx.xxx-xx) para remover: ");
                        string serialRemover = Console.ReadLine();
                        CPFmanager.DeleteCPF(serialRemover);

                        Console.ReadKey();

                        break;
                    case '3':
                        Console.Clear();
                        CPFmanager.ListCPFs();
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '4':
                        menu = false;
                        break;
                    default:
                        menu = false;
                        break;
                }
            }
        }
    }
}
