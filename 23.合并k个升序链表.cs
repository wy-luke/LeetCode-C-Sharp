/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个升序链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.length == 0)
        {
            return null;
        }
        return Merge(lists, 0, lists.Length - 1);
    }

    public ListNode Merge(ListNode[] lists, int l, int r)
    {
        if (l > r) return null;

        if (l == r) return lists[l];
        if (r - 1 == l) return MergeTwoLists(lists[l], lists[r]);

        int mid = (r + l) / 2;
        return MergeTwoLists(Merge(lists, l, mid - 1), Merge(lists, mid, r));
    }


    public ListNode MergeTwoLists(ListNode l, ListNode r)
    {
        if (l == null) return r;
        if (r == null) return l;
        ListNode head = new ListNode(-1, l);
        ListNode pre = head;
        ListNode tmp;
        while (l != null && r != null)
        {
            if (l.val <= r.val)
            {
                pre = l;
                l = l.next;
            }
            else
            {
                pre.next = r;
                tmp = r.next;
                r.next = l;
                pre = r;
                r = tmp;
            }
        }

        if (l == null) pre.next = r;

        return head.next;
    }
}
// @lc code=end

