using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace StringLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            //arrange
            string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };

            //act
            foreach(var word in words){
                bool result = word.StartsWithUpper();
                
            //assert
                Assert.IsTrue(result, String.Format("Expected for '{0}': true; Actual: {1}",word, result));
            }
        }


        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            //arrange
            string[] words = { "alphabet", "zebra",  "aBC", "aθήνα", "mосква" };

            //act
            foreach(var word in words){
                bool result = word.StartsWithUpper();
                
            //assert
                Assert.IsFalse(result, String.Format("Expected for '{0}': false; Actual: {1}",word, result));
            }
        }

        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            string[] words = {string.Empty, null};
             //act
            foreach(var word in words){
                bool result = word.StartsWithUpper();
                
            //assert
                Assert.IsFalse(result, String.Format("Expected for '{0}': false; Actual: {1}",word == null ? "<null>" : word, result));
            }
        }

        [TestMethod]
        public void AllCharsUnique()
        {
            string word = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=[]|/";
             //act
            bool result = word.AreAllCharsUnique();
                
            //assert
            Assert.IsTrue(result, String.Format("Expected for '{0}': true; Actual: {1}",word, result));
            
        }

        [TestMethod]
        public void AllCharsNotUnique()
        {
            //arrange
            string word = "aabbccdeeeffghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=[]|/";
            
            //act
            bool result = word.AreAllCharsUnique();
                
            //assert
            Assert.IsFalse(result, String.Format("Expected for '{0}': false; Actual: {1}",word, result));
            
        }

        [TestMethod]
        public void AreStringsPermutations()
        {
            //arrange
            string a = "racecar";
            string b = "acercar";
            //act
            bool result = a.IsPermutation(b);
                
            //assert
            Assert.IsTrue(result, String.Format("Expected for '{0}' and {1}: false; Actual: {2}", a,b, result));
            
        }

        
        [TestMethod]
        public void AreStringsNotPermutations()
        {
            //arrange
            string a = "racecar";
            string b = "car";
            //act
            bool result = a.IsPermutation(b);
                
            //assert
            Assert.IsFalse(result, String.Format("Expected for '{0}' and {1}: false; Actual: {2}", a,b, result));
            
        }


    }
}
