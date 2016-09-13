using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Pig_Latin
{
    class Translator
    {
        public String Translate(String input)
        {
            List<String> words          = new List<String>();

            foreach(String word in input.Split(' '))
            {
                bool   capitalized = IsCapitalized(FirstLetter(word));
                String wordParsed  = ParsePigLatin(word);

                if(capitalized)
                    wordParsed = Capitalize(wordParsed.ToLower());

                words.Add(wordParsed);
            }

            return String.Join(" ", words.ToArray());
        }
        private String ParsePigLatin(String input)
        {
            int consonantCount = CountConsonants(input.ToLower());

            if(isVowel(FirstLetter(input)))
                return HandleVowel(input);
            else
                return HandleConsonant(input, consonantCount);
        }

        private bool isVowel(String letter)
        {
            String vowels = "aeiouAEIOU";

            return vowels.Contains(letter);
        }

        private bool IsCapitalized(String letter)
        {
            if(letter == letter.ToUpper())
                return true;
            else 
                return false;
        }

        private String FirstLetter(String input)
        {
            return input.Substring(0,1);
        }

        private String Capitalize(String word)
        {
            return word.Substring( 0, 1 ).ToUpper() + word.Substring( 1 );
        }

        private String HandleConsonant(String input, int count)
        {
            return input.Substring( count ) + input.Substring( 0, count ) + "ay";
        }

        private String HandleVowel(String input)
        {
            return input + "ay";
        }

        private int CountConsonants(String word)
        {
            int  count = 0;
            char prev  = 'c';

            foreach(char letter in word)
            {
                if(prev == 'q' && letter == 'u'){
                    count++;
                    continue;
                }

                if(isVowel(letter.ToString()))
                    break;
                else
                    count++;
                
                prev = letter;
            }

            return count;
        }
    }
}
