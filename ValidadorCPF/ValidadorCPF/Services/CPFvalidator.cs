using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ValidadorCPF.Services;
using ValidadorCPF.Entities;
using ValidadorCPF.Entities.Enums;

namespace ValidadorCPF.Services
{
    class CPFvalidator : Validator
    {
        public bool Validate(object item)
        {
            //Downcast do parametro que é do tipo object para uma variavel do tipo cpf para poder realizar as operãções com suas propriedades
            CPF cpf = (CPF)item;

            //Padrão de cpf, verifica se possui algum digito que não seja um numero, um ponto ou um traço
            string pattern = "[^0-9.-]";
            //Padrão do cpf quando digitado apenas com numeros
            string patternCpfOnlyNumber = "[0-9]";
            //Modelo de cpf xxx.xxx.xxx-xx ou xxx.xxx.xxx.xx
            string cpfModel = "^[0-9]{3}\\.[0-9]{3}\\.[0-9]{3}[-\\.][0-9]{2}$";

            try
            {

                //------------------------ Verificação dos caracteres do input ------------------------
                //Verificação se o CPF é valido
                // Se o CPF possui letras 
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
                //Verifica se o cpf não possui 11 digitos logo,não está no padrão correto
                //Verifica se possui qualquer outro caracter que não seja um numero
                else if (Regex.Match(cpf.Serial, $"^{patternCpfOnlyNumber}").Success == true &&
                    cpf.Serial.Length != 11)
                    throw new Exception();

                //------------------------ Verificação Matemática ------------------------

                //Regex.Matches = procura dentro da string ocorrencias do patternCpfOnlyNumber
                int[] cpfNumber = Regex.Matches(cpf.Serial, patternCpfOnlyNumber)
                    //Cast = converte a coleção MatchCollection(tipo de retorno da função matches) em um tipo que herda de IEnumerable para poder ultilizar as outras funções
                    .Cast<Match>()
                    //Select = seleciona valores retornados da funçãao matches e converte para inteiros
                    .Select(m => int.Parse(m.Value))
                    //To array = cria um array para mandar os valores
                    .ToArray();

                int j = 10;
                int soma = 0;

                /*
                Multiplicação da primeira casa do cpf por 10, da segunda por 9 e assim por diante
                se essa multiplicação divido por 11 for menor que 2 o primeiro numero verificador deve ser 0, se não
                o numero verificador deve ser igual a 11 - o resto
                 */
                for (int i = 0; i < cpfNumber.Length - 2; i++)
                {
                    soma += cpfNumber[i] * j;
                    j--;
                }

                // Verificação do primeiro digito verificador

                int primeiroValidador = soma % 11;

                if (primeiroValidador >= 2)
                {
                    if (cpfNumber[9] != 11 - primeiroValidador)
                        
                        return false;

                }
                else
                {
                    if (cpfNumber[9] != 0)
                        
                    return false;
                }

                //Verificação segundo digito verificador
                j = 11;
                soma = 0;

                for (int i = 0; i < cpfNumber.Length - 1; i++)
                {
                    soma += cpfNumber[i] * j;
                    j--;
                }

                primeiroValidador = soma % 11;

                if (primeiroValidador >= 2)
                {
                    if (cpfNumber[10] != 11 - primeiroValidador)
                        
                    return false;
                }
                else
                {
                    if (cpfNumber[10] != 0)
                        
                    return false;
                }

                //------------------------ Verificação blacklist ------------------------

                long[] blackList = {11111111111,
                22222222222,
                33333333333,
                44444444444,
                55555555555,
                66666666666,
                77777777777,
                88888888888,
                99999999999,
                00000000000};

                long cpfValidateBlackList = long.Parse(string.Join("", cpfNumber));

                foreach(long num in blackList)
                {
                    if(cpfValidateBlackList == num)
                    {
                        return false;
                    }
                }


                //Verifica se ja existe
                if (CPFmanager.CPFs.FirstOrDefault(x => x.Serial.Equals(cpf.Serial)) != null)
                {
                    Console.Clear();
                    Console.WriteLine("CPF ja existe");

                    
                    return false;
                }                

                return true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro no cpf: " + e.Message);
            }
        }


    }
}
