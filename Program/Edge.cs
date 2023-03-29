using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class Edge
    {
        public Vertex From { get; set; } // откуда 
        public Vertex To { get; set; }  // куда
        public double Weight { get; set; } // вес ребра
        public Edge() // пустой конструктор
        {
            From = null;
            To = null;
            Weight = 0;
        }
        public Edge(Vertex from, Vertex to, double weight = 1) // конструктор для создания ребра с весом 1 по умолчанию
        {
            From = from;
            To = to;
            Weight = weight;
        }
        public override string ToString()
        {
            return string.Format("from {0} to {1} (weight = {2}); ", From.ToString(), To.ToString(), Weight.ToString());
        }
    }
}