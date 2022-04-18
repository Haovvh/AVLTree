using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn20880230
{
    class Dictionary
    {
        private AVLTree dictionary;
        public int Count = 0;
        
        public string[] ArrayKeys;
        public Dictionary()
        {
            dictionary = new AVLTree();
            ArrayKeys = new string[1000000];
        }
        public void Add(string key, string value)
        {
            ArrayKeys[Count] = key;
            dictionary.AddNode(key, value);
            Count++;            
        }
        public string Search(string key)
        {
            return dictionary.Search(key);
        }
        public void Clear()
        {
            dictionary.DeleteTree();
        }
        public void print()
        {
            dictionary.DisplayTree();
        }
    }
}
