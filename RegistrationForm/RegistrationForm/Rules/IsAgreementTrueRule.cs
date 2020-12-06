namespace RegistrationForm.Rules
{
    public class IsAgreementTrueRule
    {
        public bool Check(string agreement)
        {
            return bool.Parse(agreement);
        }
    }
}
