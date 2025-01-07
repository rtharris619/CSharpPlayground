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

public class ArrayStringProblems
{
    public void Driver()
    {
        var problem_1768 = new MergeStringsAlternately();
        problem_1768.Solve();
    }
}
