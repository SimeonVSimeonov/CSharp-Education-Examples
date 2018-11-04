namespace P04Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }

        public string Call(string number)
        {
            Validate.PhoneNumber(number);

            return "Calling... " + number;
        }

        public string Browse(string website)
        {
            Validate.Website(website);

            return "Browsing: " + website + "!";
        }
    }
}
