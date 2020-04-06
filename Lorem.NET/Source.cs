using System.Collections.Generic;
using System.Linq;

namespace LoremNET
{
    public static class Source
    {

        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split(" ").OrderBy(x => RandomHelper.Instance.Next());
        }

        internal static IEnumerable<string> WordList(bool includePuncation)
        {
            return includePuncation ? Rearrange(Lipsum.Text) : Rearrange(Lipsum.Text.Remove(","));
        }

        public static void Update(string text)
        {
            Lipsum.Text = text;
        }
    }
}