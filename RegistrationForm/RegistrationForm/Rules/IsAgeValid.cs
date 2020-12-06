using System;

namespace RegistrationForm.Rules
{
    public class IsAgeValid
    {

        public bool Check(string date)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                DateTime now = DateTime.Now;
                return ((now.Year - Convert.ToDateTime(date).Year) <= 100 && (now.Year - Convert.ToDateTime(date).Year) >=1? true : false);
            }
            else return false;
        }
    }
}
