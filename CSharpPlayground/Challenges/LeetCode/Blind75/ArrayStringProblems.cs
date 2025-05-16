using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Challenges.LeetCode;

// https://leetcode.com/problems/merge-strings-alternately
public class MergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        var merge = string.Empty;

        var current = 0;

        while (current < word1.Length && current < word2.Length)
        {
            merge = merge + word1[current] + word2[current];
            current++;
        }

        if (current < word1.Length)
        {
            merge += string.Join("", word1.Skip(current).Take(word1.Length - current));
        }

        if (current < word2.Length)
        {
            merge += string.Join("", word2.Skip(current).Take(word2.Length - current));
        }

        return merge;
    }

    public string MergeAlternately2(string word1, string word2)
    {
        var merge = new StringBuilder();

        int i = 0, j = 0;

        while (i < word1.Length && j < word2.Length)
        {
            merge.Append(word1[i]).Append(word2[j]);
            i++;
            j++;
        }

        while (i < word1.Length)
        {
            merge.Append(word1[i]);
            i++;
        }

        while (j < word2.Length)
        {
            merge.Append(word2[j]);
            j++;
        }

        return merge.ToString();
    }

    public string MergeAlternately3(string word1, string word2)
    {
        var merge = new StringBuilder();

        int lengthy = (word1.Length > word2.Length ? word1.Length : word2.Length);

        for (int i = 0; i < lengthy; i++)
        {
            if (word1.Length > i)
            {
                merge.Append(word1[i]);
            }
            if (word2.Length > i)
            {
                merge.Append(word2[i]);
            }
        }

        return merge.ToString();
    }

    public void Solve()
    {
        var word1 = "abc";
        var word2 = "pqr";

        var result = MergeAlternately3(word1, word2);
        Console.WriteLine(result);

        word1 = "ab";
        word2 = "pqrs";

        result = MergeAlternately3(word1, word2);
        Console.WriteLine(result);

        word1 = "abcd";
        word2 = "pq";

        result = MergeAlternately3(word1, word2);
        Console.WriteLine(result);

        word1 = "cf";
        word2 = "eee";

        result = MergeAlternately3(word1, word2);
        Console.WriteLine(result);
    }
}

// https://leetcode.com/problems/greatest-common-divisor-of-strings
public class GCDStrings
{
    // The greatest common divisor must be a prefix of each string, so we can try all prefixes.
    public string GcdOfStrings(string str1, string str2)
    {
        var result = "";

        if (str1.Length % str2.Length > 0) return "";

        var str2Current = str2;
        var str1Current = str1;

        var ratio = str1.Length / str2Current.Length; // 2

        var indexShift = ratio + 1;

        while (indexShift <= str1.Length)
        {
            var startsWith = str1Current.StartsWith(str2Current);

            if (!startsWith) return "";

            str1Current = str1.Substring(indexShift);

            indexShift += indexShift;
        }

        return str2Current;
    }

    public void TestCases()
    {
        var str1 = "ABCABC";
        var str2 = "ABC";
        Console.WriteLine(GcdOfStrings(str1, str2)); // ABC

        str1 = "ABABAB";
        str2 = "ABAB";
        Console.WriteLine(GcdOfStrings(str1, str2)); // AB

        str1 = "LEET";
        str2 = "CODE";
        Console.WriteLine(GcdOfStrings(str1, str2)); // ""

        str1 = "ABCDEF";
        str2 = "ABC";
        //Console.WriteLine(GcdOfStrings(str1, str2)); // ""
    }

    public void Solve()
    {
        TestCases();
    }
}

public class ArrayStringProblems
{
    public void Driver()
    {
        //var problem_1768 = new MergeStringsAlternately();
        //problem_1768.Solve();

        var problem_1071 = new GCDStrings();
        problem_1071.Solve();
    }
}
