using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoremNET.Resources;

namespace LoremNET
{
    public static class Source
    {
        internal static string Text = Lipsum.Text;

        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split(" ").OrderBy(x => RandomHelper.Instance.Next());
        }

        // https://stackoverflow.com/questions/421616/
        internal static IEnumerable<string> WordList(bool includePunctuation) => includePunctuation ? Rearrange(Text) : Rearrange(Depunctuate());

        internal static string Depunctuate()
        {
            var s = from ch in Text
                    where !char.IsPunctuation(ch)
                    select ch;

            var bytes = Encoding.ASCII.GetBytes(s.ToArray());
            return Encoding.ASCII.GetString(bytes);
        }

        public static void Update(string text)
        {
            Text = text;
        }
    }
}