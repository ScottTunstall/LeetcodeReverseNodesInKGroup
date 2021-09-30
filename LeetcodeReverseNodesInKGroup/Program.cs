using System;

namespace LeetcodeReverseNodesInKGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            // head = [1,2,3,4,5], k = 3

            var nodes = new ListNode(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4,
                            new ListNode(5)))));

            var solution = new Solution();
            var result =  solution.ReverseKGroup(nodes, 2);


        }
    }
}
