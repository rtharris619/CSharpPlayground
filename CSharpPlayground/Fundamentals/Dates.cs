using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Dates
    {
        public void Driver()
        {
            //Translate();

            TranslateSpecificDate(DateTime.Now);
        }

        public enum MonthAfrikaans
        {
            Januarie = 1,
            Februarie = 2,
            Maart = 3,
            April = 4,
            Mei = 5,
            Junie = 6,
            Julie = 7,
            Augustus = 8,
            September = 9,
            Oktober = 10,
            November = 11,
            Desember = 12,
        }

        private void Translate()
        {
            // English month names
            string[] englishMonths = DateTimeFormatInfo.CurrentInfo.MonthNames;

            // Create Afrikaans culture
            CultureInfo afrikaansCulture = new CultureInfo("af-ZA");

            // Translate each month to Afrikaans
            string[] afrikaansMonths = new string[englishMonths.Length];
            for (int i = 0; i < englishMonths.Length; i++)
            {
                DateTimeFormatInfo afrikaansFormat = afrikaansCulture.DateTimeFormat;
                afrikaansMonths[i] = afrikaansFormat.MonthNames[i];
            }

            // Display the translated months
            for (int i = 0; i < englishMonths.Length; i++)
            {
                Console.WriteLine($"{afrikaansMonths[i]}");
            }
        }

        private void TranslateSpecificDate(DateTime date)
        {
            var result = (MonthAfrikaans)Enum.Parse(typeof(MonthAfrikaans), date.Month.ToString());
            Console.WriteLine(result);
        }
    }
}
