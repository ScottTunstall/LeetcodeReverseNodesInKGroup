using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeReverseNodesInKGroup
{
    public class Solution
    {


        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
                return null;

            if (k == 0)
                return head;

            if (!TryReverseKNodes(head, k, out var newHead, out var newTail))
                return head;

            var current = newTail;

            while (current != null)
            {
                if (!TryReverseKNodes(current.next, k, out var headOfSubsetOfNodes, out newTail))
                    break;

                current.next = headOfSubsetOfNodes;
                current = newTail;
            }

            return newHead;
        }


        private bool TryReverseKNodes(ListNode head, int k, out ListNode newHead, out ListNode newTail)
        {
            var listNodes = CreateStackFromListNodes(head, k, out var listTail1);

            // 
            if (listNodes.Count !=k)
            {
                newHead = head;
                newTail = null;
                return false;
            }
            
            // Get the first node we *haven't* processed 
            var unprocessedAsYet = listTail1.next;

            newHead = CreateListNodesFromStack(listNodes, out var listTail2);
            newTail = listTail2;

            listTail2.next = unprocessedAsYet;

            return true;
        }


        private Stack<ListNode> CreateStackFromListNodes(ListNode headOfListNodes, int k, out ListNode tailOfListNodes)
        {
            var listNodes = new Stack<ListNode>();
            tailOfListNodes = headOfListNodes;
            var i = 0;

            var current = headOfListNodes;
            while (current != null && i < k)
            {
                listNodes.Push(current);
                tailOfListNodes = current;
                current = current.next;
                i++;
            }

            return listNodes;
        }


        private ListNode CreateListNodesFromStack(Stack<ListNode> listNodes, out ListNode tail)
        {
            var head = listNodes.Pop();

            tail  = head;
            
            while (listNodes.TryPop(out ListNode listNode))
            {
                tail.next = listNode;
                tail = listNode;
            }

            return head;
        }



    }
}
