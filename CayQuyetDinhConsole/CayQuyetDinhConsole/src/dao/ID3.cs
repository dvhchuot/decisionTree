using CayQuyetDinhConsole.src.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayQuyetDinhConsole.src.dao
{
    class ID3
    {
        public List<string> attribute;
        public List<int> remainingAttribute;
        public List<value> listData;
        public string class1;
        public string class2;
        public Node root;
        public int c1;
        public int c2;
        public ID3(List<string> attribute, List<int> remainingAttribute, List<value> listData, string class1, string class2, int c1, int c2)
        {

            this.attribute = attribute;
            this.remainingAttribute = remainingAttribute;
            this.listData = listData;
            this.class1 = class1;
            this.class2 = class2;
            this.root = new Node();
            this.c1 = c1;
            this.c2 = c2;
        }

        public void start()
        {
            this.root.next = generate(remainingAttribute, listData, c1, c2);

           

        }

        public Node generate(List<int> remainingAttribute, List<value> listData, int c1, int c2)
        {
            entropy entropy = new entropy();
            Node node = entropy.tinhEntropy(c1, c2, remainingAttribute, listData, class1, class2);
            node.name = this.attribute[node.attr];
            List<int> newremain = remainingAttribute.FindAll(x => x != node.attr).ToList();
            //foreach (var i in newremain) Console.WriteLine(i);
            foreach (var i in node.children)
            {

                //Console.WriteLine(i.value + " c1 " + i.nClass1 + " c2 " + i.nClass2);
                if (i.isLeaf)
                {

                }
                else
                {

                    i.next = generate(newremain, i.data, i.nClass1, i.nClass2);
                    //Node nodec = entropy.tinhEntropy(i.nClass1, i.nClass2, newremain, i.data, class1, class2);
                }
            }
            return node;
        }

        public void printTree()
        {


            string tree = " root -> ";
            toString(root.next, tree, true);
            //Console.WriteLine(tree);


        }
        public void toString(Node node, string tree, bool isroot)
        {
           

            if(isroot) tree += node.name;
            else tree += " and "  + node.name;
            foreach (var i in node.children)
            {
                if (!i.isLeaf)
                {
                    string s = tree + " = " + i.value;
                    toString(i.next, s,false);
                }
                else
                {
                    Console.WriteLine(tree + " = " + i.value + " Then " + i.classCati);
                }
            }

        }

        public string  Ktra(value value)
        {

            
            return toKtra(value,this.root.next);

        }
        public string toKtra(value value,Node node)
        {
            //bool check = false;
            //Console.WriteLine(value.values[node.attr]);
            foreach (var i in node.children)
            {
                if (i.value == value.values[node.attr])
                {
                    //Console.WriteLine(i.isLeaf);
                    if (i.isLeaf) return i.classCati;
                    else
                    {
                        return toKtra(value, i.next);
                    }
                }
            }
            return "?";
            
        }
    }
}
