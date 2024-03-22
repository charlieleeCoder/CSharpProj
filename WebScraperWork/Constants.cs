// .data
namespace BankRateConstants
{
    public static class Constants
    {
        // url to scrape
        public const string BANK_RATE_URL = "https://www.bankofengland.co.uk/boeapps/database/Bank-Rate.asp";
        // element to scrape
        public const string FIND_ELEMENT = "table";
        // id to scrape
        public const string FIND_ID = "stats-table";
        // relevant operating years are from 2014, but that base rate was set in 2009
        public const int START_YEAR = 2009;
    }
}