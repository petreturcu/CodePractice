// -----------------------------------------------------------------------
// <copyright file = "Sets.cs" author = "Petre Turcu" company = "LadApps">
//      Copyright (c) 16/06/2016
// </copyright>
// -----------------------------------------------------------------------
namespace Algorithms
{
    using System;

    public class Sets
    {
        public static void PermuteSimple(string set, string prefix = "")
        {
            if (set.Length == 0) Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    prefix = prefix + set[i];
                    PermuteSimple(set.Remove(i, 1), prefix);
                    prefix = prefix.Remove(prefix.Length - 1, 1);
                }
            }
        }
    }
}