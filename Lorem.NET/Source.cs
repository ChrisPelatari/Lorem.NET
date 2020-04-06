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

        // https://stackoverflow.com/questions/421616/
        internal static IEnumerable<string> WordList(bool includePunctuation) => includePunctuation ? Rearrange(Lipsum.Text) : Rearrange(new string(Lipsum.Text.Where(c => !char.IsPunctuation(c)).ToArray()));

        public static void Update(string text)
        {
            Lipsum.Text = text;
        }
    }
}