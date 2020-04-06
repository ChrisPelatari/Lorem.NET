using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoremNET
{
    public static class Source
    {

        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split(" ").OrderBy(x => RandomHelper.Instance.Next());
        }

        // https://stackoverflow.com/questions/421616/
        internal static IEnumerable<string> WordList(bool includePunctuation) => includePunctuation ? Rearrange(Lipsum.Text) : Rearrange(Depunctuate());

        internal static string Depunctuate()
        {
            var s = from ch in Lipsum.Text
                    where !char.IsPunctuation(ch)
                    select ch;

            var bytes = Encoding.ASCII.GetBytes(s.ToArray());
            return Encoding.ASCII.GetString(bytes);
        }

        public static void Update(string text)
        {
            Lipsum.Text = text;
        }
    }
}