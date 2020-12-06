using RegistrationForm.Rules;
using System;

namespace RegistrationForm.Services
{
    public static class Validation
    {
        public static string ValidateAge(this String value)
        {
            var age = new IsAgeValid();
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!age.Check(value))
                {
                    return "Возраст участника не может быть больше 100 лет или меньше 1 года";
                }
                else return "";
            }
            else
                return "Введите возраст участника";
        }

        public static string ValidateAgreement(this String value)
        {
            var agreement = new IsAgreementTrueRule();
            if (!agreement.Check(value)) 
                return "Пожалуйста, примите согласие на обработку персональных данных";
            else
                return "";
        }

        public static string ValidateNotEmpty(this String value)
        {
            if (string.IsNullOrWhiteSpace(value)) 
                return "Заполните поле";
            return "";
        }

        public static string ValidateLength(this String value, int Max, int Min)
        {
            var length = new IsLengthValidRule();
            if (!length.Check(value, Max, Min)) 
                return String.Format("Некорректная длина(от {0} до {1} символов)", Min, Max).ToString();
            else
                return "";
        }

        public static string ValidatePhone(this String value)
        {
            var phone = new IsPhoneValidRule();
            if (!phone.Check(value))
                return "Введите корректный номер телефона (без скобок и тире, начинается с +7 или 8, 11 цифр)";
            return "";
        }
    }
}
