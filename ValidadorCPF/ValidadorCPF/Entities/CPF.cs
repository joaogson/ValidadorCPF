using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorCPF.Services;

namespace ValidadorCPF.Entities
{
    class CPF
    {
        public string Serial { get; set; }
        public string Region { get; set; }
        public Validator cpfValidator { get; set; }

        public CPF(string serial, CPFvalidator cpfValidator)
        {
            Serial = serial;
            this.cpfValidator = cpfValidator;

            cpfValidator.Validate(this);

            


        }
    }
}
