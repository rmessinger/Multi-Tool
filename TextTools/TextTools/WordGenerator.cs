using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextTools
{
    public class WordGenerator
    {
        private ISet<string> words;
        private const string FileName = "generatedWords.txt";
        private char[] alphabetArray;
        private object lockObject = new object();
        private CountdownEvent finished;
        private IDictionary<ISet<char>, IList<string>> wordsByCharCombination;

        public WordGenerator()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            this.alphabetArray = alphabet.ToCharArray();
            this.wordsByCharCombination = new Dictionary<ISet<char>, IList<string>>();
        }

        public void Run()
        {
            this.words = new HashSet<string>();

            DateTime startTime = DateTime.Now;

            if (!File.Exists(FileName))
            {
                this.finished = new CountdownEvent(26);
                string testWord = string.Empty;

                foreach(char letter in this.alphabetArray)
                {
                    Thread task = new Thread(() => GenerateWords(letter));
                    task.Start();
                }

                this.finished.Wait();
                File.WriteAllLines(FileName, words);
            }
            else
            {
                foreach(string word in File.ReadAllLines(FileName))
                {
                    words.Add(word);
                    char[] wordLetters = new List<char>(word).Distinct().ToArray();
                    this.PopulateCombinations(word, wordLetters, new HashSet<char>());
                }
            }

            TimeSpan elapsed = DateTime.Now - startTime;
            ConsoleUtilities.Log($"Execution took {elapsed.TotalMilliseconds}ms");
        }

        private void PopulateCombinations(string word, char[] wordLetters, ISet<char> workingCombination)
        {
            int index = 0;

            // for each letter in the word, iterate forward with each n=2 combination
            // after all n=2 combinations, combine current letter with next
            // for each letter after the current combination, iterate forward
            foreach (char letter in wordLetters)
            {
                ISet<char> combination = new HashSet<char>(workingCombination);
                combination.Add(letter);
                if (!this.wordsByCharCombination.ContainsKey(combination))
                {
                    this.wordsByCharCombination.Add(combination, new List<string>());
                }

                this.wordsByCharCombination[combination].Add(word);
                int letterPosition = Array.IndexOf(wordLetters, letter);
                if (wordLetters.Length > 1)
                {
                    char[] subset = new ArraySegment<char>(wordLetters, letterPosition + 1, wordLetters.Length - 1).ToArray();
                    this.PopulateCombinations(word, subset, combination);
                }
            }
        }

        private IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
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
                                words.Add(testWord);
                            }
                        }
                    }
                }
            }

            this.finished.Signal();
        }
    }
}
