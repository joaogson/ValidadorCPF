using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Services;
using ValidadorCPF.Entities.Enums;

namespace ValidadorCPF.Entities
{
    class CPF
    {
        public string Serial { get; set; }        
        public Validator cpfValidator { get; set; }
        public Region TaxRegion {
            get { return TaxRegion; }
            set { Region(this); }
        }

        public CPF(string serial, CPFvalidator cpfValidator)
        {
            Serial = serial;
            this.cpfValidator = cpfValidator;


            cpfValidator.Validate(this);


        }
        public string Region(CPF cpf)
        {
            char region = cpf.Serial[8];

            string taxRegion = null;
            switch (region)
            {

                case '1':
                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal1;

                    taxRegion = $"Região Fiscal {1}";
                    break;

                case '2':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal2;
                    taxRegion = $"Região Fiscal {2}";
                    break;

                case '3':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal3;

                    taxRegion = $"Região Fiscal {3}";
                    break;

                case '4':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal4;

                    taxRegion = $"Região Fiscal {4}";
                    break;

                case '5':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal5;

                    taxRegion = $"Região Fiscal {5}";
                    break;

                case '6':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal6;

                    taxRegion = $"Região Fiscal {6}";
                    break;

                case '7':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal7;

                    taxRegion = $"Região Fiscal {7}";
                    break;

                case '8':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal8;

                    taxRegion = $"Região Fiscal {8}";
                    break;

                case '9':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal9;

                    taxRegion = $"Região Fiscal {9}";
                    break;

                case '0':

                    cpf.TaxRegion = Entities.Enums.Region.RegiaoFiscal0;

                    taxRegion = $"Região Fiscal {0}";
                    break;

            }
            return taxRegion;
        }


        public override string ToString()
        {
            return "Cpf: " + Serial
                + "Região Fiscal: " + TaxRegion;
        }
    }
}
