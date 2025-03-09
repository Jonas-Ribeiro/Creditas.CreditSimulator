namespace Creditas.CreditSimulator.Domain.Entities
{
    public class User
    {
        public readonly string Name;
        public readonly double CreditRequest;
        public readonly DateTime BirthDate;
        public readonly int MonthsPaymentTerm;

        public User(string name, double creditRequest, DateTime birthDate, int monthsPaymentTerm)
        {
            Name = name;
            CreditRequest = creditRequest;
            BirthDate = birthDate;
            MonthsPaymentTerm = monthsPaymentTerm;
        }
    }
}
