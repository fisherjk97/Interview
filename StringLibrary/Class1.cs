using System;
using System.Text;

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


        /// <summary>
        /// There are 3 types of edits that can be performed on a string. 
        /// insert a char, remove a char, replace a char. 
        /// Given 2 strings, write a function to check if they are one edit (or zero edits) away
        /// Example:
        /// pale, ple - > true
        /// pales, pale - > true
        /// pale, bale - > true
        /// pale, bae - > false
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool OneEditAway(this string a, string b){

            //the lengths of the strings will determine the edits

            
            if(a.Length == b.Length){ //equal length, check for replacment
                return OneEditReplace(a, b);
            }else if (a.Length +  1 == b.Length){//adding 1 char to string a makes it equal to b, check for inserts
                return OneEditInsert(a, b);
            }else if (a.Length -  1 == b.Length){//removing 1 char to string a makes it equal to b, check for deletes
                return OneEditDelete(a, b);
            }else{
                return false;
            }
    
        }

        private static bool OneEditReplace(string a, string b){ 
            bool foundDifference = false;
            for(int i = 0; i < a.Length; i++){
                if(a[i] != b[i]){
                    if(foundDifference){
                        return false;
                    }
                    foundDifference = true;
                }
            }
            return true;
        }


        private static bool OneEditInsert(string a, string b){ 
            int index1 = 0;
            int index2 = 0;
            while(index2 < b.Length && index1 < a.Length){
                if(a[index1] != b[index2]){
                    if(index1 != index2){
                        return false;
                    }
                    index2++;
                } else{
                    index1++;
                    index2++;
                }
            }
            return true;
        }


        private static bool OneEditDelete(string a, string b){
            return OneEditInsert(b, a);
        }



        /// <summary>
        /// Implement a method to perform basic string compression using the counts of repeated chars
        /// example: aabcccccaaa = a2b1c5a3
        /// If the compressed string does not become smaller than the original, return the original. 
        /// assume only uppercase and lowercase letters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressBad(this string str){

            string compressed = "";
            int countConsecutive = 0;
            for(int i = 0; i < str.Length; i++){
                countConsecutive++;

                //if the next character is different from the current, append this char to the result
                if(i + 1 >= str.Length || str[i] != str[i+1]){
                    compressed += "" + str[i] + countConsecutive;
                    countConsecutive = 0;
                }

            }

            return compressed.Length < str.Length? compressed: str;

        }


        //Better version of the CompressBad. Uses StringBuilder
        public static string Compress(this string str){

            //check final length and return input string if it would be longer
            int finalLength = CountCompression(str);
            if(finalLength >= str.Length){
                return str;
            }


            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;
            for(int i = 0; i < str.Length; i++){
                countConsecutive++;

                //if the next character is different from the current, append this char to the result
                if(i + 1 >= str.Length || str[i] != str[i+1]){
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }

            }

            return compressed.Length < str.Length? compressed.ToString(): str;

        }

        private static int CountCompression(string str){
            int compressedLength = 0;
            int countConsecutive = 0;
            for(int i = 0; i < str.Length; i++){
                countConsecutive++;

                //if the next char is different than current, increase the length

                if(i + 1 >= str.Length || str[i] != str[i+1]){
                    compressedLength +=1 + countConsecutive.ToString().Length;
                    countConsecutive = 0;
                }
            }
            return compressedLength;
        }


        

    

    }


}