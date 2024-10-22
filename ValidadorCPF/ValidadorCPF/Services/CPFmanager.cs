using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Entities;

namespace ValidadorCPF.Services
{
    static class CPFmanager
    {
        static public List<CPF> CPFs { get; set; } = new List<CPF>();
        

        static public void AddCPF(CPF cpf)
        {
            CPFs.Add(cpf);
            Console.WriteLine();
            Console.WriteLine("CPF Adicionado!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Lista Atualizada: ");
            ListCPFs();
            
        }
        static public void DeleteCPF(string cpf)
        {
            if (CPFmanager.CPFs.FirstOrDefault(x => x.Serial.Equals(cpf)) == null)
            {
                Console.WriteLine("CPF não existe!");
                
            }
            else
            {
                Console.WriteLine();
                CPFs.Remove(CPFmanager.CPFs.FirstOrDefault(x => x.Serial.Equals(cpf)));
                Console.WriteLine(CPFmanager.CPFs.FirstOrDefault(x => x.Serial.Equals(cpf)));
                Console.WriteLine("CPF removido!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Lista Atualizada");
                ListCPFs();
                Console.ReadKey();
            }

            
        }

        static public void ListCPFs()
        {
            Console.WriteLine("CPFs: ");
            foreach (var cpf in CPFs)
                Console.WriteLine(cpf.ToString());
        }
    }
}
