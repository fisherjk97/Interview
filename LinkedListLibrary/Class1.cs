using System;
using System.Collections.Generic;

namespace UtilityLibraries
{

    public class LinkedListNode {

        public LinkedListNode(int data){
            Data = data;
            Next = null;
        }

        public LinkedListNode(int data, LinkedListNode next){
            Data = data;
            Next = next;
        }

        public int Data {get;set;}

        public LinkedListNode Next {get;set;}



    }


    public static class LinkedListLibrary
    {

        /*Cracking the coding interview*/

        /// <summary>
        /// Remove duplicates from an unsorted linked list
        /// </summary>
        public static void DeleteDups(LinkedListNode n){
            HashSet<int> set = new HashSet<int>();
            LinkedListNode previous = null;
            while(n != null){//looop until the end
                if(set.Contains(n.Data)){//if the list already contains this data, then remove it by removing it from the list by assignment
                    previous.Next = n.Next;
                }else{
                    set.Add(n.Data);
                    previous = n;
                }
                n = n.Next;//move forward
            }
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
