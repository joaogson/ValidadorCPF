using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Services;
using ValidadorCPF.Entities.Enums;
using System.Text.RegularExpressions;

namespace ValidadorCPF.Entities
{
    class CPF
    {
        public string Serial { get; set; }
        public Validator cpfValidator { get; set; }
        public Region TaxRegion { get; set; }
        public string Validate { get; set; }


        public CPF(string serial)
        {
            Serial = serial;
        }

        public CPF(string serial, CPFvalidator cpfValidator)
        {
            //Padroniza o tipo do cpf para (xxx.xxx.xxx-xx) para buscas na lista
            string patternCpfOnlyNumber = "[0-9]";
            //Converte para um array apenas com os numeros do cpf
            int[] cpfNumber = Regex.Matches(serial, patternCpfOnlyNumber)
                    .Cast<Match>()
                    .Select(m => int.Parse(m.Value))
                    .ToArray();

            //Padroniza o array para uma string (xxx.xxx.xxx-xx)
            Serial = (string)$"{cpfNumber[0]}{cpfNumber[1]}{cpfNumber[2]}." +
                $"{cpfNumber[3]}{cpfNumber[4]}{cpfNumber[5]}." +
                $"{cpfNumber[6]}{cpfNumber[7]}{cpfNumber[8]}-" +
                $"{cpfNumber[9]}{cpfNumber[10]}";

            
            this.cpfValidator = cpfValidator;

            //Caso o cpf ja exista, a função Validate ira retornar false e não adicionará à lista
            if (cpfValidator.Validate(this))
            {
                Validate = "Válido";
            }
            else
            {
                Validate = "Inválido";
            }

            //Adicioa na lista de cpf
            CPFmanager.AddCPF(this);

            //Define a região que ele pertence
            SetTaxRegion(this);

        }
        public void SetTaxRegion(CPF cpf)
        {
            //Transformação da string cpf em um array de inteiros para não ter diferença na verificação do digito quando o input tiver pontos ou traços ou for só numeros
            string patternCpfOnlyNumber = "[0-9]";
            int[] cpfNumber = Regex.Matches(cpf.Serial, patternCpfOnlyNumber)
                    .Cast<Match>()
                    .Select(m => int.Parse(m.Value))                    
                    .ToArray();

            int numberRegion = cpfNumber[8];
            cpf. TaxRegion = (Region)numberRegion;

        }

        public string DescribeRegion(Region taxRegion)
        {

            string Description;
            
            switch (taxRegion)
            {
                case Region.RegiaoFiscal0:
                    Description = "Rio Grande do Sul";
                    break;
                case Region.RegiaoFiscal1:
                    Description = "Distrito Federal, Goiás, Mato Grosso e Mato Grosso do Sul";
                    break;
                case Region.RegiaoFiscal2:
                    Description = "Acre, Amapá, Amazonas, Pará, Rondônia e Roraima";
                    break;
                case Region.RegiaoFiscal3:
                    Description = "Cerá, Maranhão e Piauí";
                    break;
                case Region.RegiaoFiscal4:
                    Description = "Alagoas, Paraíba, Pernambuco e Rio Grande do Norte";
                    break;
                case Region.RegiaoFiscal5:
                    Description = "Bahia e Sergipe";
                    break;
                case Region.RegiaoFiscal6:
                    Description = "Minas Gerais";
                    break;
                case Region.RegiaoFiscal7:
                    Description = "Espirito Santo e Rio de Janeiro";
                    break;
                case Region.RegiaoFiscal8:
                    Description = "São Paulo";
                    break;
                case Region.RegiaoFiscal9:
                    Description = "Paraná e Santa Catarina";
                    break;
                default:
                    Description = "Região Desconhecida";
                    break;
            }
 
            return Description;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------");
            sb.Append("CPF: ");
            sb.AppendLine(Serial);
            sb.Append("Região Fiscal: ");
            sb.AppendLine(DescribeRegion(TaxRegion));
            sb.AppendLine(Validate);
            sb.AppendLine("------------");

            return sb.ToString();
        }
    }
}
