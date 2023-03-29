using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASID
{
    class Graph
    {
        public List<Vertex> Vertices = new List<Vertex>(); // cписок всех вершин
        public List<Edge> AllEdges = new List<Edge>(); // cписок всех ребер
        public int VertexCount { get { return Vertices.Count; } } // количество вершин
        public int EdgeCount { get { return AllEdges.Count; } } // количество ребер
        public bool AddVertex(Vertex vertex) // добавить вершину в граф
        {
            if (VertexIsContains(vertex)) return false;
            Vertices.Add(vertex);
            return true;
        }
        public bool AddEdge(Vertex from, Vertex to, double Weight = 1) // добавить ребро в граф
        {
            Edge edge = new Edge(from, to, Weight); // создаем ребро / экземпляр класса Edge
            if (EdgeIsContains(edge)) return false;
            AllEdges.Add(edge); // добавляем вершину в список всех вершин
            from.AdjEdges.Add(edge); // добавляем вершину в список смежных вершин
            return true;
        }
        public void RemoveVertex(Vertex vertex) // удаление вершины
        {
            Vertices.Remove(vertex);
        }
        public bool VertexIsContains(Vertex vertexName) // наличие вершины
        {
            foreach (var v in Vertices)
            {
                if (v.Equals(vertexName))
                {
                    return true;
                }
            }
            return false;
        }
        public bool EdgeIsContains(Edge edge) // наличие вершины
        {
            foreach (var v in AllEdges)
            {
                if (v.From == edge.From && v.To == edge.To && v.Weight == edge.Weight)
                {
                    return true;
                }
            }
            return false;
        }
        public Vertex FindVertex(Vertex vertexName) // поиск вершины
        {
            foreach (var v in Vertices)
            {
                if (v.Equals(vertexName))
                {
                    return v;
                }
            }
            return null;
        }
        public void View() // просмотр графа
        {
            foreach (Vertex v in Vertices)
            {
                Console.WriteLine("Vertex : {0}", v);
                foreach (Edge e in v.AdjEdges)
                {
                    Console.WriteLine("Edge : {0}", e);
                }
            }
        }
        public void BFS(Vertex startVertex)     // поиск в ширину (обход графа)
        {
            //v - вершина; u - вершина смежная с v;
            foreach (Vertex vertex in Vertices)
            {
                vertex.distance = double.MaxValue; // (бесконечность)
                vertex.prevVertex = null;          // предшественник
                vertex.color = ColorVertex.White;  // раскраска вершин в белый
            }
            startVertex.color = ColorVertex.Gray; // красим начальную вершину в серый
            startVertex.distance = 0;
            startVertex.prevVertex = null;
            Queue<Vertex> Q = new Queue<Vertex>(); // создаем очередь
            Q.Enqueue(startVertex);                // добавить в конец очереди

            while (Q.Count > 0)
            {
                Vertex u = Q.Dequeue();  // возвращаем элемент из начала очереди

                foreach (Edge ee in u.AdjEdges) // перебираем смежные ребра вершины взятой из очереди
                {
                    Vertex v = ee.To; // вершина, куда идет ребро
                    if (v.color == ColorVertex.White) // совершаем обход
                    {
                        v.color = ColorVertex.Gray; // красим пройденную вершину в серый
                        v.distance = u.distance + 1; // задаем расстояние от начала до текущей вершины
                        v.prevVertex = u; // обозначение для вершины предшестенника
                        Q.Enqueue(v);
                    }
                }
                u.color = ColorVertex.Black; // при возврате красим вершину в черный
            }
        }
        public void DFS(Vertex startVertex) // поиск в глубину (обход графа)
        {
            foreach (Vertex vertex in Vertices) // раскраска вершин в белый
            {
                vertex.color = ColorVertex.White;
                vertex.prevVertex = null;
            }
            startVertex.time = 0;
            foreach (Vertex vertex in Vertices)
            {
                if (vertex.color == ColorVertex.White)   // если перед вызовом DFS_Visit вершина белая
                {
                    DFS_Visit(startVertex);
                }
            }
        }
        public void DFS_Visit(Vertex u)     // вспомогательный метод DFS
        {
            u.color = ColorVertex.Gray;    // красим в серую
            u.discovered = u.time;
            u.time += 1;    // счетчик времени увеличиваем на 1

            foreach (Edge ee in u.AdjEdges) // перебираем смежные ребра вершины взятой из очереди
            {
                Vertex v = ee.To; // вершина, куда идет ребро
                if (v.color == ColorVertex.White)
                {
                    v.prevVertex = u; // обозначение для вершины предшестенника 
                    DFS_Visit(v); // рекурсивно продолжаем обход дальше
                }
            }
            u.color = ColorVertex.Black;
            u.finished = u.time; // вершина пройдена
            u.time += 1;
        }
        public int GraphConnectivity()      // cвязность графа
        {
            foreach (Vertex vertex in Vertices)
            {
                vertex.distance = double.MaxValue; //(бесконечность)
            }
            int cс = 0; // счетчик компонентов связности
            while (true)
            {
                foreach (Vertex vertex in Vertices) // перебор всех вершин
                { // у исследованных вершин (черных) dinstance != MaxValue
                    if (vertex.distance == double.MaxValue)
                    {
                        cс++;
                        BFS(vertex); // совершаем обход всего графа или его части
                    }
                }
                return cс;
            }
        }
        public void Dijkstra(Vertex startVertex) // алгоритм дийкстры
        {
            foreach (Vertex vertex in Vertices) // раскраска вершин в белый
            {
                vertex.color = ColorVertex.White;
                vertex.distance = double.PositiveInfinity;
            }
            startVertex.distance = 0;

            Queue<Vertex> Q = new Queue<Vertex>(); // создаем очередь
            Q.Enqueue(startVertex);

            while(Q.Count > 0) 
            { 
                Vertex v = Q.Dequeue();
                if (v.color == ColorVertex.White)
                {
                    foreach (Edge e in v.AdjEdges)
                    
                        Vertex nv = e.To; // вершина, куда идет ребро
                        if (nv.distance > e.Weight + v.distance)
                        {
                            nv.distance = e.Weight + v.distance;
                        }
                        Q.Enqueue(nv);
                    }
                    v.color = ColorVertex.Black;
                }
            }
            foreach (Vertex vertex in Vertices) // раскраска вершин в белый
            {
                Console.WriteLine("shortest distance from {0} to {1} is : {2}",startVertex, vertex, vertex.distance);
            }
        }
    }
}