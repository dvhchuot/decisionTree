using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayQuyetDinhConsole.src.entity
{
    class Node
    {
        public int nClass1=0;
        public int nClass2=0;
        public double entropy;
        public List<value> data;
        public bool isLeaf = false;
        public List<Node> children;
        public string name;
        public string value;
        public int attr;
        public string classCati;
        public Node next;
        public List<int> remainingAttributes;
        
        //public Node(int C1,int C2,double d, List<string> data,List<int> remainingAttributes)
        //{
        //    this.nClass1 = C1;
        //    this.nClass2 = C2;
        //    this.entropy = d;
        //    this.data = data;
        //    this.remainingAttributes = remainingAttributes;
        //}

        
    }
}
