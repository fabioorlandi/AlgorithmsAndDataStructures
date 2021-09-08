using System.Globalization;
using System.Text;

namespace Util
{
    public static class StringExtensions
    {
        public static string RemoveDiacritics(this string @string)
        {
            var normalizedString = @string.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
