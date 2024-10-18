using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Entities;
using System.Text.RegularExpressions;

namespace ValidadorCPF.Services
{
    class CPFvalidator : Validator
    {


        public bool Validate(object item)
        {
            CPF cpf = (CPF)item;
            string pattern = "[^0-9.-]";
            string patternCpfOnlyNumber = "^[0-9]";
            string cpfModel = "^[0-9]{3}\\.[0-9]{3}\\.[0-9]{3}[-\\.][0-9]{2}$";
            

            try
            {
                //Verificação se o CPF é valido
                // Se o CPF possuir letras 
                if (Regex.Match(cpf.Serial, pattern).Success == true ||
                   cpf.Serial.Length < 11 || cpf.Serial.Length > 14)

                    throw new Exception();
                //Se o CPF possuir 14 digitos quer dizer que possui pontos e traço
                else if (cpf.Serial.Length == 14)
                {
                    // Verifica se está de acordo com o modelo de cpf xxx.xxx.xxx-xx
                    if (Regex.Match(cpf.Serial, cpfModel).Success == false)
                        throw new Exception();
                }
                //
                else if (Regex.Match(cpf.Serial, patternCpfOnlyNumber).Success == true &&
                    cpf.Serial.Length != 11)
                    throw new Exception();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro no cpf: " + e.Message);
            }
        }
    }
}
