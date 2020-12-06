namespace RegistrationForm.Rules
{
    public class IsPhoneValidRule
    {

        public bool Check(string number)
        {
            if (!string.IsNullOrWhiteSpace(number)) 
            {
                if (number[0] == '8'&&number.Length==11||number[0]=='+'&&number[1]=='7' && number.Length == 12) { return true; }
                else return false;
            }      
            else return false;
        }
    }
}
