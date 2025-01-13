namespace TermProject.Models
{
    public class WordBankSearchFilter
    {
        public WordBankSearchFilter()
        {

        }

        public List<string> GenNumBathsBeds()
        {
            List<string> list = new List<string>();
            list.Add("1+");
            list.Add("2+");
            list.Add("3+");
            list.Add("4+");
            list.Add("5+");
            return list;
        }

        public Dictionary<string, double> GenMinMaxPrice()
        {
            Dictionary<string, double> prices = new Dictionary<string, double>();
            double price = 0;

            while (price < 1000000)
            {
                string displayText = $"${price:N0}";
                prices.Add(displayText, price);
                price += 50000;
            }

            while (price < 10000000)
            {
                string displayText = $"${price:N0}";
                prices.Add(displayText, price);
                price += 500000;
            }

            while (price <= 18000000)
            {
                string displayText = $"${price:N0}";
                prices.Add(displayText, price);
                price += 1000000;
            }
            return prices;
        }
    }
}
