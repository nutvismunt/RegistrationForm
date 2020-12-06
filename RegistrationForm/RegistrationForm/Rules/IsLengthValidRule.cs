namespace RegistrationForm.Rules
{
    public class IsLengthValidRule
    {
        public bool Check(string value, int MaxLength, int MinLength)
        {
            if (value == null) return false;
            return (value.Length>=MinLength&&value.Length<=MaxLength);
        }
    }
}
