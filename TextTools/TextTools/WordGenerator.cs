using ICSharpCode.SharpZipLib.BZip2;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TextTools
{
    public class HashKey<T> : HashSet<T>
    {
        public override bool Equals(object obj)
        {
            return this.SetEquals(obj as ISet<T>);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach(char c in this as HashKey<char>)
            {
                hashCode += (int)c;
            }

            hashCode *= this.Count;
            return hashCode;
        }
    }

    public class WordGenerator
    {
        private const string FileName = "generatedWords.txt";
        private const string startTag = "<";
        private const string endTag = "/>";
        private const int targetLength = 5;

        private ISet<Word> words;
        private IList<string> replacementTokens = new List<string>() { "<.*?>", "[^0-9A-Za-z ,]", @"\s+" };
        private char[] alphabetArray;
        private object lockObject = new object();
        private CountdownEvent finished;
        private IDictionary<HashKey<char>, IList<string>> wordsByCharCombination;

        public WordGenerator()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            this.alphabetArray = alphabet.ToCharArray();
            this.wordsByCharCombination = new Dictionary<HashKey<char>, IList<string>>();
        }

        public void Run()
        {
            this.words = new HashSet<Word>();

            DateTime startTime = DateTime.Now;

            if (!File.Exists(FileName))
            {
                this.finished = new CountdownEvent(26);
                string testWord = string.Empty;

                foreach (char letter in this.alphabetArray)
                {
                    Thread task = new Thread(() => GenerateWords(letter));
                    task.Start();
                }

                this.finished.Wait();
                // File.WriteAllLines(FileName, words);
            }
            else
            {
                foreach (string word in File.ReadAllLines(FileName))
                {
                    words.Add(new Word(word));
                    char[] wordLetters = new List<char>(word).Distinct().ToArray();
                    this.PopulateCombinations(word, wordLetters.ToHashSet<char>());
                }
            }

            var filename = "G:\\Books\\enwiki-20220101-pages-articles-multistream\\enwiki-20220101-pages-articles-multistream.xml.bz2";

            var settings = new XmlReaderSettings()
            {
                ValidationType = ValidationType.None,
                ConformanceLevel = ConformanceLevel.Auto // Fragment ?
            };

            using (var stream = File.Open(filename, FileMode.Open))
            using (var bz2 = new BZip2InputStream(stream))
            using (var reader = new StreamReader(bz2))
            {
                int bz2chunkSize = 600;
                uint lineCount = 0;
                while (bz2.Position < bz2.Length)
                {
                    byte[] data = new byte[1024];
                    bz2.Read(data, 0, 600);

                    while (!reader.EndOfStream)
                    {
                        ++lineCount;
                        string line = reader.ReadLine();
                        ConsoleUtilities.Log(line);
                        bool skip = false;

                        foreach (string token in this.replacementTokens)
                        {
                            line = Regex.Replace(line, token, "");
                            ConsoleUtilities.Log(line);

                            if (line.Length < targetLength)
                            {
                                skip = true;
                                break;
                            }
                        }

                        if (skip)
                        {
                            continue;
                        }

                        string[] words = line.Split(' ');

                        foreach (string word in words)
                        {
                            if (this.words.Contains(new Word(word)))
                            {

                            }
                        }
                    }
                }
                ConsoleUtilities.Log($"Processed {lineCount} lines");
            }
            TimeSpan elapsed = DateTime.Now - startTime;
            ConsoleUtilities.Log($"Execution took {elapsed.TotalMilliseconds}ms");
        }

        private void PopulateCombinations(string word, ISet<char> uniqueLetters)
        {
            foreach (var result in Subsets<char>(uniqueLetters))
            {
                if (result.Count() == 0)
                {
                    continue;
                }

                HashKey<char> key = result as HashKey<char>;
                if (!this.wordsByCharCombination.ContainsKey(key))
                {
                    this.wordsByCharCombination.Add(key, new List<string>());
                }
                else
                {
                    ;
                }

                this.wordsByCharCombination[key].Add(word);
            }
        }

        public static IEnumerable<IEnumerable<T>> Subsets<T>(IEnumerable<T> source)
        {
            List<T> list = source.ToList();
            int length = list.Count;
            int max = (int)Math.Pow(2, list.Count);

            for (int count = 0; count < max; count++)
            {
                ISet<T> subset = new HashKey<T>();
                uint rs = 0;
                while (rs < length)
                {
                    if ((count & (1u << (int)rs)) > 0)
                    {
                        subset.Add(list[(int)rs]);
                    }
                    rs++;
                }

                yield return subset;
            }
        }

        private void GenerateWords(char firstLetter)
        {
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.Initialize();
            Spelling spellCheck = new Spelling();
            spellCheck.Dictionary = wordDictionary;
            spellCheck.ShowDialog = false;
            char[] wordBuilder = new char[5];
            string testWord;

            wordBuilder[0] = firstLetter;
            for (int second = 0; second < this.alphabetArray.Length; second++)
            {
                wordBuilder[1] = this.alphabetArray[second];
                for (int third = 0; third < this.alphabetArray.Length; third++)
                {
                    wordBuilder[2] = this.alphabetArray[third];
                    for (int fourth = 0; fourth < this.alphabetArray.Length; fourth++)
                    {
                        wordBuilder[3] = this.alphabetArray[fourth];
                        for (int fifth = 0; fifth < this.alphabetArray.Length; fifth++)
                        {
                            wordBuilder[4] = this.alphabetArray[fifth];
                            testWord = new string(wordBuilder);
                            if (spellCheck.TestWord(testWord))
                            {
                                words.Add(new Word(testWord));
                            }
                        }
                    }
                }
            }

            this.finished.Signal();
        }
    }
}
