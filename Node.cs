using System;

namespace nhap8
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    public class BinarySearchTree
    {
        public Node Root { get; set; }

        // Thêm nút
        public bool Insert(int value)
        {
            Node before = null, after = this.Root;
            while (after != null)
            {
                before = after;
                if (value < after.Data) //left? 
                        after = after.LeftNode; 
                else if (value > after.Data) //right?
                    after = after.RightNode;
                else
                    return false;
            }

            Node newNode = new Node();
            newNode.Data = value;
            if (this.Root == null)//empty?
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }
            return true;
        }

        // Thăm nút
        // Duyệt cây theo thứ tự bé -> lớn
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        // Duyệt cây tiền thứ tự
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        // Duyệt cây hậu thứ tự
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }

        // Tìm nút min
        private int MinValueOfNode(Node node)
        {
            int minv = node.Data;
            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minv;
        }
        public int FindMin()
        {
            return MinValueOfNode(this.Root);
        }

        // Tìm nút min kết hợp 2 hàm trên
        public int FindMin2()
        {
            Node current = Root;
            while (current.LeftNode != null)
                current = current.LeftNode;
            return current.Data;
        }

        // Tìm nút max
        private int MaxValueOfNode(Node node)
        {
            int maxv = node.Data;
            while (node.RightNode != null)
            {
                maxv = node.RightNode.Data;
                node = node.RightNode;
            }
            return maxv;
        }
        public int FindMax()
        {
            return MaxValueOfNode(this.Root);
        }

        // Tìm nút max kết hợp 2 hàm trên
        public int FindMax2()
        {
            Node current = Root;
            while (current.RightNode != null)
                current = current.RightNode;
            return current.Data;
        }

        // Độ sâu của cây (chiều dài cây)
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }


        // Tìm nút
        public Node Find(int value)
        {  return this.Find(value, this.Root); }
        
        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }
            return null;
        }


        // Xóa nút
        public void Remove(int value)
        { this.Root = Remove(this.Root, value); }
        
        private Node Remove(Node parent, int key)
        {   
            if (parent == null) return parent;
            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data) parent.RightNode = Remove(parent.RightNode, key);
            else//Xóa nút hiện tại
            {   
                // Nếu nút hiện tại có 1 nút con
                if (parent.LeftNode == null) return parent.RightNode;
                else if (parent.RightNode == null) return parent.LeftNode;
                // Nếu nút có hai nút con: lấy nút nhỏ hơn (bên trái)
                parent.Data = MinValueOfNode(parent.RightNode);
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            } 
            return parent;
        }


    }

}