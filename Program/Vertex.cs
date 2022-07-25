using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    public enum ColorVertex // раскраска вершин
    {
        White,
        Gray,
        Black
    }
    class Vertex
    {
        public string Name { get; set; } // название вершины
        public Vertex prevVertex;    // предыдущая вершина, от которой пришли
        public double distance;     // суммарное расстояние
        public List<Edge> AdjEdges;   // набор смежных ребер (ребра, которые выходят из данной вершины)
        public ColorVertex color;

        // для DFS
        public int discovered;  // обнаруженная вершина
        public int finished;    // обработанная вершина
        public int time;        // метка времени
        Vertex() // пустой констуктор
        {
            Name = "No name";
            AdjEdges = new List<Edge>();
        }

        public Vertex(string name) // констуктор для создания вершины
        {
            Name = name;
            AdjEdges = new List<Edge>();
        }

        public override string ToString()
        {
            return string.Format("vertex({0})", Name);
        }
    }
}