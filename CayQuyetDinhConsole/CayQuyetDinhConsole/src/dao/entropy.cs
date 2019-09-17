using CayQuyetDinhConsole.src.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayQuyetDinhConsole.src.dao
{
    class entropy
    {

        public Node tinhEntropy(int c1, int c2, List<int> remainingAttribute, List<value> listData, string class1, string class2)
        {
            double max = -1;
            int tong = c1 + c2;
            double Sentropy = entropyS(c1, c2);
            int count = listData.Count;
            Node node = new Node();
            
            node.entropy = Sentropy;
            for (int i = 0; i < remainingAttribute.Count; i++)
            {
                List<Node> listchildren = new List<Node>();
                List<children> list = new List<children>();

                for (int j = 0; j < listData.Count; j++)
                {
                    bool check = true;
                    foreach (var x in list)
                    {
                        if (x.name == listData[j].values[remainingAttribute[i]])
                        {
                            check = false;
                            if (listData[j].values[listData[j].values.Count - 1] == class1) x.c1++;
                            if (listData[j].values[listData[j].values.Count - 1] == class2) x.c2++;
                        }

                    }
                    if (check)
                    {

                        children child = new children();
                        
                        child.name = listData[j].values[remainingAttribute[i]];
                        if (listData[j].values[listData[j].values.Count - 1] == class1) child.c1 = 1;
                        else child.c2 = 1;
                        list.Add(child);

                    }
                }
                double gain=Sentropy;
                foreach (var x in list)
                {

                    x.entropy = entropyS(x.c1, x.c2);
                    gain -= x.entropy * (x.c1 + x.c2) / listData.Count;
                    
                }
                if (gain > max)
                {
                    node.attr = remainingAttribute[i];
                    max = gain;
                    //Console.WriteLine("chon" + i);
                    foreach (var x in list)
                    {
                        Node nodeChild = new Node();
                        nodeChild.entropy = x.entropy;
                        nodeChild.nClass1 = x.c1;
                        nodeChild.nClass2 = x.c2;
                        if (nodeChild.nClass1 == 0)
                        {
                            nodeChild.isLeaf = true;
                            nodeChild.classCati = "No";
                        }
                        
                        if (nodeChild.nClass2 == 0)
                        {
                            nodeChild.isLeaf = true;
                            nodeChild.classCati = "Yes";
                        }
                        nodeChild.value = x.name;
                        nodeChild.data = updateDataTrain(listData, remainingAttribute[i], x.name);
                        listchildren.Add(nodeChild);
                    }
                    node.children = listchildren;
                }
                
            }
            foreach (var i in node.children)
            {
                //Console.WriteLine("value "+i.value);
                //Console.WriteLine("data " + i.data.Count);
                //if (i.isLeaf) Console.WriteLine("kq " + i.classCati);
            }
            //Console.WriteLine(node.attr);
            //Console.WriteLine("max" + max);
            //Console.WriteLine("entrype" + Sentropy);
            return node;
        }
        public List<value> updateDataTrain(List<value> list,int attr,string value)
        {
            List<value> newList = list.FindAll(x => x.values[attr] == value).ToList();
            return newList;
        }
        public double entropyS(int c1, int c2)
        {
            int tong = c1 + c2;
            if (c1 == 0 || c2 == 0) return 0;
            double s = (-1) * ((double)c1 / tong) * (Math.Log(c1) - Math.Log(tong)) / Math.Log(2) - ((double)c2 / tong) * (Math.Log(c2) - Math.Log(tong)) / Math.Log(2);
            
            return s;
        }
    }
}
