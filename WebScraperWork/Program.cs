using HtmlAgilityPack;
using static BankRateConstants.Constants;

namespace WebScraper
{
    internal class Program
    {
        static void Main()
        {

            // Scrape whole webpage first
            HtmlDocument page = ScrapeWholePage(BANK_RATE_URL);

            // Then select relevant rows only
            HtmlNodeCollection nodes = SelectNodes(page, FIND_ELEMENT, FIND_ID);

            // Limit years in selection
            Dictionary<DateOnly,float> filteredRows = FilterNodes(nodes, START_YEAR);

            // Now print with formatting
            PrintF(filteredRows);

        }

        static HtmlDocument ScrapeWholePage(string url) 
        {
            // Scrape whole page first
            var requests = new HtmlWeb();
            var page = requests.Load(url);

            // Check that there's definitely data
            if (page == null)
            {
                throw new Exception("Unable to scrape html document.");
            }
            return page;
        }

        static HtmlNodeCollection SelectNodes(HtmlDocument page, string element, string id)
        {
            // Now only the table I want
            var table = page.DocumentNode.SelectSingleNode($"//{element}[@id=\'{id}\']");

            // Check that there's definitely data
            if (table == null)
            {
                throw new Exception($"Unable to find element: {element} with id: {id}");
            }

            // Return all rows in the table
            var nodes = table.SelectNodes(".//tr");

            return nodes;
        }

        static Dictionary<DateOnly, float> FilterNodes(HtmlNodeCollection nodes, int startingYear)
        {
            // Create empty dict array
            var datesAndRates = new Dictionary<DateOnly, float>();

            // Now iterate through each row
            foreach (var node in nodes)
            {
                // Select each 
                var cells = node.SelectNodes(".//td");
                if (cells != null)
                {
                    // Extract data from each cell and add to dictionary
                    DateOnly tempDate = DateOnly.Parse(cells[0].InnerText.Trim());
                    float tempFloat = float.Parse(cells[1].InnerText.Trim());

                    // Check it's a year we care about
                    if (tempDate.Year >= startingYear)
                    {
                        datesAndRates.Add(tempDate, tempFloat);
                    } 
                }
            }
            // Send 
            return datesAndRates;
        }
        static void PrintF(Dictionary<DateOnly, float> rows)
        {
            // Now iterate through each row and print
            foreach (var row in rows)
            {
                Console.WriteLine($" Date: {row.Key} Rate: {row.Value}");
            }
        }
    }
}
