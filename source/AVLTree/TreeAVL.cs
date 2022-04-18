using System;

namespace DoAn20880230
{
    public class Node
    {
        public string key;
        public string value;
        public Node left;
        public Node right;
        public int height;
        public Node(string Key, string Value)
        {
            this.key = Key;
            this.value = Value;
            this.height = 1;
        }
    }
    class AVLTree
    {
        int ID;
        Node root;
        int height(Node current)
        {
            if(current==null)
            {
                return 0;
            }
            return current.height;
        }
        public AVLTree()
        {

        }
        public void DeleteTree()
        {
            root = null;
        }        
        public void AddNode(string English, string Mean)
        {
            Node newItem = new Node(English, Mean);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = Insert(root, English, Mean);
            }                
        }
        public int getBalance (Node current)
        {
            if (current == null)
                return 0;
            return height(current.left) - height(current.right);
        }
        //đệ quy chèn phần tử vào các node tiếp theo của cây
        private Node Insert(Node current, string key, string value)
        {
            if (current == null)
            {
                current = new Node(key, value);
                return current;
            }
            int compare = string.Compare(key, current.key);
            if (compare < 0)
            {
                current.left = Insert(current.left, key, value);                
            }
            else if (compare > 0)
            {
                current.right = Insert(current.right, key, value);                
            }            
            Updateheight(current);
            int b_factor = getBalance(current);         
            //b_factor = hiệu độ lệch cây con trái và phải
            if (b_factor > 1)
            {
                // Left Left
                if (string.Compare(key, current.left.key) < 0)
                return RotateRight(current);
                // Left Right
                else if (string.Compare(key, current.left.key) > 0)
                {
                    current.left = RotateLeft(current.left);
                    return RotateRight(current);
                }    
            }            
            else if (b_factor < -1)
            {
                // Right Right
                if (string.Compare(key, current.right.key) > 0)
                return RotateLeft(current);
                // Right Left
                else if (string.Compare(key, current.right.key) < 0)
                {
                    current.right = RotateRight(current.right);
                    return RotateLeft(current);
                }    
            }         
            return current;
        }
        public string Search(string keyword)
        {
            return Searchkey(keyword, root);
        }
        private string Searchkey(string keyword, Node current)
        {
            if (current == null)
            {
                return null;
            }
            else
            {
                int compare = string.Compare(keyword, current.key);
                if (compare == 0)
                {
                    return current.value.ToLower();
                }
                else if (compare < 0)
                {
                    return Searchkey(keyword, current.left);
                }
                else
                {
                    return Searchkey(keyword, current.right);
                }
            }
        }
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                Console.WriteLine($"{ID++}\t{current.key}:\t{current.value}");
                InOrderDisplayTree(current.left);
                InOrderDisplayTree(current.right);
            }
        }
               
        //xử lý mất cân bằng phải phải
        private Node RotateRight(Node parent)
        {
            Node pivot = parent.left;
            Node Temp = pivot.right;
            pivot.right = parent;
            parent.left = Temp;
            Updateheight(parent);
            Updateheight(pivot);            
            return pivot;
        }
        //xử lý mất cân bằng trái trái
        private Node RotateLeft(Node parent)
        {
            Node pivot = parent.right;            
            Node Temp = pivot.left;
            pivot.left = parent;
            parent.right = Temp;
            Updateheight(parent);
            Updateheight(pivot);            
            return pivot;
        }
        void Updateheight(Node current)
        {
            current.height = 1 + Math.Max(height(current.left), height(current.right));
        }        
              
    }
}

