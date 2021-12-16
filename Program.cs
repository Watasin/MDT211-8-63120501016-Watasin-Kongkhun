using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace week11_3
{
    class Node
    {
        public int DecayCount;
        public char Ray;
        public Node Next;
        public Node(int decayCountValue, char rayValue)
        { DecayCount = decayCountValue;
          Ray = rayValue;
        }
    }class Queue
    {private Node Root;
        public void Push(Node node)
        {if (Root == null)
            {Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }
        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
    }

    class Program
    {
        static char GetNextRay(char ray)
        {
            switch (ray)
            {
                case 'A':
                    return 'B';
                case 'B':
                    return 'C';
                case 'C':
                    return 'D';
                case 'D':
                    return 'E';
                case 'E':
                    return 'A';
                default:
                    return '?';
            }
        }

        static void Main(string[] args)
        {
            Queue moleculeQueue = new Queue();

            int decayCount;
            char ray;
            while (true)
            {
                decayCount = int.Parse(Console.ReadLine());
                if (decayCount < 0)
                {
                    break;
                }
                ray = char.Parse(Console.ReadLine());
                Node molecule = new Node(decayCount, ray);
                moleculeQueue.Push(molecule);
            }
            Node decayMolecule;
            while (true)
            {
                decayMolecule = moleculeQueue.Pop();
                if (decayMolecule == null)
                {
                    break;
                }
                Console.Write(decayMolecule.Ray);
                if (decayMolecule.DecayCount > 1)
                {
                    Node childMolecule1 = new Node(decayMolecule.DecayCount - 1, GetNextRay(decayMolecule.Ray));
                    Node childMolecule2 = new Node(decayMolecule.DecayCount - 1, GetNextRay(decayMolecule.Ray));
                    moleculeQueue.Push(childMolecule1);
                    moleculeQueue.Push(childMolecule2);
                }
            }
        }
    }
}
