// -----------------------------------------------------------------------
// <copyright file = "Strings.cs" author = "Petre Turcu" company = "LadApps">
//      Copyright (c) 16/06/2016
// </copyright>
// -----------------------------------------------------------------------
namespace Algorithms
{
    public class Strings
    {
        public static bool CompareNoLib(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            for (int i = 0; i <= str1.Length - 1; i++)
            {
                if (str1[i] != str2[i]) return false;
            }

            return true;
        }
    }
}