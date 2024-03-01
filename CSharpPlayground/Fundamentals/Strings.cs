using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Strings
    {
        public void Driver()
        {
            //GetSapProvidedByEntityName("902902 Lala Murrey Van Heerden");
            //ExtractDocumentIDs(new List<string> { "0412/00101576", "0426/00052724" });

            Extract3rdValue("905906-20240115-60635_BCA_INV.PDF");
        }

        public void Extract3rdValue(string input)
        {
            var fileNameSplit = input.Replace(".PDF", "", StringComparison.InvariantCulture).Split("-");
            var lastBit = fileNameSplit[2][..fileNameSplit[2].IndexOf("_")];

            Console.WriteLine(lastBit);
        }

        public void GetSapProvidedByEntityName(string input)
        {

            var providedBy = input.Trim();

            var startIndex = providedBy.IndexOf(" ") + 1;

            var result = providedBy[startIndex..].Trim();

            Console.WriteLine(result);
        }

        private void TrimString()
        {
            var bpNumber = "0000937644";

            Console.WriteLine(bpNumber.TrimStart('0'));
        }

        private List<string> ExtractDocumentIDs(List<string> invoiceReferences)
        {
            if (invoiceReferences != null && invoiceReferences.Any())
            {
                var documentIDs = new List<string>();
                invoiceReferences.ForEach(invoiceReference =>
                {
                    var documentID = invoiceReference.Split('/').LastOrDefault();

                    if (!string.IsNullOrWhiteSpace(documentID))
                    {
                        documentID = documentID.TrimStart('0');
                        if (!string.IsNullOrWhiteSpace(documentID))
                        {
                            documentIDs.Add(documentID);
                        }
                    }
                });

                Console.WriteLine(string.Join(",", documentIDs));
                return documentIDs;
            }

            return new List<string>();
        }

        private void SplitWord()
        {
            var word = "VATNumber123TestWorksJack1";
            var letters = word.ToCharArray();
            var sentenceSb = new StringBuilder();

            for (var i = 0; i < letters.Length; i++)
            {
                char? previous = i > 0 ? letters[i - 1] : null;
                var current = letters[i];
                char? next = i < letters.Length - 1 ? letters[i + 1] : null;
                bool split = false;

                if (char.IsUpper(current))
                {
                    if (previous.HasValue && next.HasValue)
                    {
                        if (char.IsLower(previous.Value) && char.IsLower(next.Value)) split = true;
                        if (char.IsUpper(previous.Value) && char.IsLower(next.Value)) split = true;
                    }

                    if (previous != null)
                    {
                        if (char.IsDigit(previous.Value)) split = true;
                    }
                }

                if (char.IsDigit(current))
                {
                    if (previous != null)
                    {
                        if (char.IsLetter(previous.Value)) split = true;
                    }
                }

                sentenceSb.Append(split ? " " + letters[i] : letters[i]);
            }

            Console.WriteLine(sentenceSb.ToString());
        }
    }
}
