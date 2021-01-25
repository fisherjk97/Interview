using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;
using System;

namespace LinkedListLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeleteDupsFromLinkedList()
        {

            LinkedListNode n1 = new LinkedListNode(1);
            LinkedListNode n2 = new LinkedListNode(2);
            LinkedListNode n3 = new LinkedListNode(3);
            LinkedListNode n4 = new LinkedListNode(2);

            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;

            Print(n1);

            LinkedListLibrary.DeleteDups(n1);

            Print(n1);

            Assert.IsNotNull(n1);
        }


        public static void Print(LinkedListNode n){

            while(n != null){
                int data = n.Data;
                string nextNode = "";
                if(n.Next != null){
                    nextNode = " -> ";
                }

                Console.WriteLine(data + nextNode);
                n = n.Next;
            }
        }
    }
}
