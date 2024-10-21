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



        public CPF(string serial, CPFvalidator cpfValidator)
        {

            Serial = serial;

            this.cpfValidator = cpfValidator;

            cpfValidator.Validate(this);

            SetTaxRegion(this);

        }
        public void SetTaxRegion(CPF cpf)
        {
            Console.WriteLine(cpf.Serial[9]);
            int numRegion = int.Parse(cpf.Serial.Substring(8,1));
            Region TaxRegion = (Region)numRegion;
            DescribeRegion(TaxRegion);
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
            return "Cpf: " + Serial
                + ", Região Fiscal: " + DescribeRegion(TaxRegion);
        }
    }
}
