using CayQuyetDinhConsole.src.dao;
using CayQuyetDinhConsole.src.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayQuyetDinhConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start.... "+DateTime.Now);
            FileStream fs = new FileStream("train.txt", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string line;
            string class1 = "Yes";
            string class2 = "No";
            

            
            List<string> attribute = new List<string>();
            line = rd.ReadLine();
            attribute = line.Split(',').ToList();
            List<int> remainingAttribute = new List<int>();
            for(int i=0;i< attribute.Count; i++)
            {
                remainingAttribute.Add(i);
            }
            List<value> listData = new List<value>();
            int c1=0;
            int c2=0;
            while ((line = rd.ReadLine()) != null)
            {
                List<string> item = new List<string>();
                item = line.Split(',').ToList();
                if (item[item.Count - 1] == class1) c1++;
                else c2++;
                value value = new value();
                value.values = item;
                listData.Add(value);
            }

            //foreach (var i in listData)
            //{
            //    Console.WriteLine(i.toString());
            //}
            //Console.WriteLine("C1=" + c1 + " C2=" + c2);
            //entropy entropy = new entropy();
            //Node node= entropy.tinhEntropy(c1, c2, remainingAttribute, listData, class1, class2);
            //List<int> newremain = remainingAttribute.FindAll(x => x != node.attr).ToList();
            //foreach (var i in newremain) Console.WriteLine(i);
            //foreach(var i in node.children)
            //{
            //    Console.WriteLine(i.value + " c1 " +i.nClass1 + " c2 " + i.nClass2);
            //    if(i.isLeaf)
            //    { 

            //    }
            //    else
            //    {
            //        Node nodec = entropy.tinhEntropy(i.nClass1, i.nClass2, newremain, i.data, class1, class2);
            //    }
            //}
            rd.Close();

            DateTime trainStart = DateTime.Now;

            Console.WriteLine("Training...." + trainStart);


            ID3 iD = new ID3(attribute, remainingAttribute, listData, class1, class2, c1, c2);
            iD.start();
            DateTime trainEnd = DateTime.Now;
            Console.WriteLine("End training...." + trainEnd);

            Console.WriteLine("time training...." + (trainEnd-trainStart).ToString() +" Tong du lieu traning: "+ listData.Count);

            Console.WriteLine("Print...." + DateTime.Now);

            Node no = new Node();
            //Console.WriteLine(no.isLeaf);
            
            iD.printTree();

            //value value2 = new value();
            //List<string> newlist = new List<string>();
            //newlist.Add("black");
            //newlist.Add("number");
            //newlist.Add("yamaha");
            //newlist.Add("blade");
            //newlist.Add("conanhoa");
            //value2.values = newlist;
            //string s=iD.Ktra(value2);
            //string d=value2.toString();
            //Console.WriteLine( d);
            //Console.WriteLine("kq " + s);
            FileStream fstest = new FileStream("test.txt", FileMode.Open);
            StreamReader rdtest = new StreamReader(fstest, Encoding.UTF8);
            List<value> listDataTest = new List<value>();
            
            while ((line = rdtest.ReadLine()) != null)
            {
                List<string> item = new List<string>();
                item = line.Split(',').ToList();
                
                value value = new value();
                value.values = item;
                listDataTest.Add(value);
            }

            foreach(var i in listDataTest)
            {
                Console.WriteLine(i.toString() + " --> " + iD.Ktra(i));
            }

            rdtest.Close();

            Console.ReadLine();
        }
    }
}
