using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTools.Types
{
    public class Word
    {
        public string Text { get; private set; }

        public ISet<char> Letters { get; private set; }

        public int ScrabbleScore { get; private set ;
        }

        public int CommonnessRating { get; private set; }

        public Word(string text)
        {
            this.Text = text;
            this.Letters = this.Text.ToCharArray().ToHashSet();
            int score = 0;
            foreach (var letter in this.Letters)
            {
                score += WordUtils.GetScrabbleScore(letter);
            }

            this.ScrabbleScore = score;
        }

        public override bool Equals(object obj)
        {
            return this.Text.Equals((obj as Word)?.Text);
        }

        public override string ToString()
        {
            return this.Text;
        }

        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }
    }
}
