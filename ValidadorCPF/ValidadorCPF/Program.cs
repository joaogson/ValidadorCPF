using System;
using ValidadorCPF.Entities;
using ValidadorCPF.Services;

namespace ValidadorCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o serial do cpf");
            String serial = Console.ReadLine();

            CPFvalidator validator = new CPFvalidator();
            CPF cpf = new CPF(serial, validator);

            Console.WriteLine();
            Console.WriteLine("CPF VALIDO: " + cpf);
        }
    }
}
