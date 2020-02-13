using System.Text.RegularExpressions;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Model { get; protected set; }

        public string Call(string number)
        {
            var regex = new Regex("^\\d+$").IsMatch(number);
            if (!regex)
            {
                return $"Invalid number!";
            }
            return $"Calling... {number}";
        }

        public string Browse(string webSite)
        {
            var regex = new Regex("\\d").IsMatch(webSite);
            if (regex)
            {
                return $"Invalid URL!";
            }
            return $"Browsing: {webSite}!";
        }
    }
}
