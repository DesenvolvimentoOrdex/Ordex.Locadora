using CSharpFunctionalExtensions;

namespace Ordex.Locadora.Shared.Validations
{
    public static class DocumentoValidation
    {
        public static Result<bool, string> CpfValidate(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !IsDigitsOnly(cpf))
                return false;

            int[] numbers = new int[11];

            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(cpf[i].ToString());

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += numbers[i] * (10 - i);

            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += numbers[i] * (11 - i);

            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;

            
             bool resultTrue = numbers[9] == digit1 && numbers[10] == digit2;
            if (resultTrue)
            {
                return resultTrue;
            }
            return Result.Failure<bool, string>("Cpf Inválido");
        }

        public static Result<bool, string> CnpjValidate(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14 || !IsDigitsOnly(cnpj))
                return false;

            int[] numbers = new int[14];

            for (int i = 0; i < 14; i++)
                numbers[i] = int.Parse(cnpj[i].ToString());

            int sum = 0;
            int multiplier = 2;
            for (int i = 11; i >= 0; i--)
            {
                sum += numbers[i] * multiplier;
                multiplier = multiplier == 9 ? 2 : multiplier + 1;
            }

            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 2;
            for (int i = 12; i >= 0; i--)
            {
                sum += numbers[i] * multiplier;
                multiplier = multiplier == 9 ? 2 : multiplier + 1;
            }

            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;

            bool resultTrue = numbers[12] == digit1 && numbers[13] == digit2;

            if (resultTrue)
            {
                return resultTrue;
            }
            return Result.Failure<bool, string>("Cnpj Inválido");
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}