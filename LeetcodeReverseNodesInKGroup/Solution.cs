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
            var listNodes = new Stack<ListNode>();
            var current = head;
            var i = 0;

            while (current != null && i < k)
            {
                listNodes.Push(current);
                current = current.next;
                i++;
            }

            if (listNodes.Count !=k)
            {
                newHead = head;
                newTail = null;
                return false;
            }
            
            var nodeAfterOldTail  = current;

            var headOfReversedNodes = listNodes.Pop();

            current = headOfReversedNodes;
            while (listNodes.TryPop(out ListNode listNode))
            {
                current.next = listNode;
                current = listNode;
            }

            current.next = nodeAfterOldTail;

            newHead = headOfReversedNodes;
            newTail = current;

            return true;
        }
    }
}
