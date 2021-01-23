using System;

namespace UtilityLibraries
{
    public static class StringLibrary
    {
        public static bool StartsWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];
            return char.IsUpper(ch);
        }
    
        /*Cracking the coding interview*/
        
        
        /// <summary>
        /// Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures
        /// </summary>
        public static bool AreAllCharsUnique(this string str){

            //assume 128 characters - ASCII
            //assume 256 characters - extended ASCII
            int asciiMax = 128;
            if(str.Length > asciiMax){
                return false;
            }
            
            bool[] chars = new bool[128];
            for(int i = 0; i < str.Length; i++){
                int val = str[i];
                if(chars[val]){//already found this char in the string
                    return false;
                }
                chars[val] = true;//mark as found
            }

            return true;

        }

        private static string Sort(string s){
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new String(content);
        }

        /// <summary>
        /// Given two strings, write a method to decide if one is a permutation of the other
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsPermutation(this string a, string b){

            //questions to ask: is the permutation case sensitive, is whitespace significant

            //observations: strings of different lengths cannot be permutations of the other


            //option 1: Sort the strings

            /*
            if(a.Length != b.Length){
                return false;
            }else{
                return Sort(a).Equals(Sort(b));
            }
            */

            //option 2 check if two strings have identical character counts

            //using the definition of permutation, two words with the same character count. 

            //iterate through code, counting how many times each char appears

            if(a.Length != b.Length){
                return false;
            }

            int[] letters = new int[128];//assumption


            char[] a_array = a.ToCharArray();
            foreach(char c in a_array){//count the number of each char in s
                letters[c]++;
            }

            for(int i = 0; i < b.Length; i++){
                int c = (int) b[i];//charAt
                letters[c]--;//subtract the frequency
                if(letters[c] < 0){//we encountered a character in b that doesn't exist in a already
                    return false;
                }
            }

            return true;


        }
    
    }




}