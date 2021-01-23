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
    
    }




}