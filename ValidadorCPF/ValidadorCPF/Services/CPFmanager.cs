using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Entities;

namespace ValidadorCPF.Services
{
    class CPFmanager
    {
        public List<CPF> CPFs { get; set; } = new List<CPF>();

        public void AddCPF(CPF cpf)
        {
            CPFs.Add(cpf);
        }

        public void UpdateCPF()
        {

        }

        public void DeleteCPF(CPF cpf)
        {
            CPFs.Remove(cpf);
        }

        public void ListCPFs()
        {
            foreach (var cpf in CPFs)
                Console.WriteLine(cpf.ToString());
        }
    }
}
