using System;
using System.ComponentModel.Design;

namespace WholeKitAndCaboodle.Common
{
   public static class Extentions
   {
      public static string TrimQuotes(this string str)
      {
         if (string.IsNullOrWhiteSpace(str))
         {
            return str;
         }

         if (str[0] == '"')
         {
            str = str.TrimStart('\"');
         }

         if (str[str.Length - 1] == '"')
         {
            str = str.TrimEnd('\"');
         }

         return str;
      }
   }
}