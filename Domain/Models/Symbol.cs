namespace Domain.Models
{
	public class Symbol
	{
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public decimal Price { get; private set; }
        public string? Column5 { get; private set; }
        public string? Column6 { get; private set; }
        public string? Column7 { get; private set; }
        public string? Column8 { get; private set; }
        public string? Column9 { get; private set; }
        public string? Column10 { get; private set; }
        public string? Column11 { get; private set; }
        public string? Column12 { get; private set; }
        public string? Column13 { get; private set; }
        public string? Column14 { get; private set; }
        public string? Column15 { get; private set; }

        public Symbol()
        {
            TimeFrom = DateTime.Now;
            TimeTo = DateTime.Now;
        }

        public Symbol(string name, DateTime timeFrom, DateTime timeTo)
        {
            Name = name;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
        }

        public Symbol(string name, string timeFrom, string timeTo, string price, string column5, string column6, string column7,
            string column8, string column9, string column10, string column11, string column12, string column13, string column14,
            string column15)
        {
            Name = name;

            if (DateTime.TryParse(timeFrom, out DateTime parsedTimeFrom))
            {
                TimeFrom = parsedTimeFrom;
            }
            if (DateTime.TryParse(timeTo, out DateTime parsedTimeTo))
            {
                TimeTo = parsedTimeTo;
            }
            if (decimal.TryParse(price, out decimal parsedPrice))
            {
                Price = parsedPrice;
            }
             
            Column5 = column5;
            Column6 = column6;
            Column7 = column7;
            Column8 = column8;
            Column9 = column9;
            Column10 = column10;
            Column11 = column11;
            Column12 = column12;
            Column13 = column13;
            Column14 = column14;
            Column15 = column15;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            return true;
        }
    }
}