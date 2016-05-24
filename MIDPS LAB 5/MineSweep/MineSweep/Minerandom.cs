using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweep
{
    public class Game
    {
        bool[,] visited;
        public int[,] array;
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Game(int width, int height)
        {
            Width = width;
            Height = height;
            array = new int[Width, Height];
            visited= new bool[Width, Height];
            Random random = new Random();
             
            var copy = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    array[i, j] = copy[i,j] = random.NextDouble() < 0.1 ? -1 : 0;
                }

            }
            

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (array[i, j] == -1)
                        continue;

                    if(i != 0)
                    {
                        if (j != 0)
                            array[i, j] -= copy[i - 1, j - 1];
                        array[i, j] -= copy[i - 1, j];
                        if(j != Height - 1)
                            array[i, j] -= copy[i - 1, j + 1];
                    }

                    if (j != 0)
                        array[i, j] -= copy[i, j - 1];
                    if (j != Height - 1)
                        array[i, j] -= copy[i, j + 1];


                    if (i != Width - 1)
                    {
                        if (j != 0)
                            array[i, j] -= copy[i + 1, j - 1];
                        array[i, j] -= copy[i + 1, j];
                        if (j != Height - 1)
                            array[i, j] -= copy[i + 1, j + 1];
                    }

                }
            }





        }
        
        public bool CheckState()
        {

            string ar = string.Empty;
            string vi = string.Empty;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ar += array[j, i] + " ";
                    vi += (visited[j, i] ? "+" : "-") + " ";
                }
                ar += Environment.NewLine;
                vi += Environment.NewLine;
            }

            

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (array[i, j] != -1 && visited[i, j] == false)
                        return false;
                       
                    
                }
            }
            return true;
        }
        public Dictionary<Tuple<int,int>, int> Dig(int x, int y)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            Queue<Tuple<int, int>> processed = new Queue<Tuple<int, int>>();

            visited[x, y] = true;

            if (array[x,y] != 0)
            {
                if (array[x, y] == -1)
                    return null;

                return new Dictionary<Tuple<int, int>, int> { [new Tuple<int, int>(x, y) ] = array[x,y] };
            }


            queue.Enqueue(new Tuple<int, int>(x, y));
            while (queue.Any())
            {
                var cell = queue.Dequeue();
                processed.Enqueue(cell);
                int i = cell.Item1;
                int j = cell.Item2;

                if (i != 0)
                {
                    if (j != 0 && visited[i - 1, j - 1] == false)
                    {
                        if (array[i - 1, j - 1] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i - 1, j - 1));
                            visited[i - 1, j - 1] = true;
                        }
                        else if(array[i - 1, j - 1] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i - 1, j - 1));
                            visited[i - 1, j - 1] = true;
                        }

                    }
                    if (visited[i - 1, j] == false)
                    {
                        if (array[i - 1, j] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i - 1, j));
                            visited[i - 1, j] = true;
                        }
                        else if (array[i - 1, j] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i - 1, j));
                            visited[i - 1, j] = true;
                        }
                    }
                    if (j != Height - 1 && visited[i - 1, j + 1] == false)
                    {
                        if (array[i - 1, j + 1] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i - 1, j + 1));
                            visited[i - 1, j + 1] = true;
                        }
                        else if (array[i - 1, j + 1] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i - 1, j + 1));
                            visited[i - 1, j + 1] = true;
                        }
                    }
                }

                if (j != 0 && visited[i, j - 1] == false)
                {
                    if (array[i, j - 1] == 0)
                    {
                        queue.Enqueue(new Tuple<int, int>(i, j - 1));
                        visited[i, j - 1] = true;
                    }
                    else if (array[i, j - 1] != -1)
                    {
                        processed.Enqueue(new Tuple<int, int>(i, j - 1));
                        visited[i, j - 1] = true;
                    }

                }
                if (j != Height - 1  && visited[i, j + 1] == false)
                {
                    if(array[i, j + 1] == 0)
                    {
                        queue.Enqueue(new Tuple<int, int>(i, j + 1));
                        visited[i, j + 1] = true;
                    }
                    else if (array[i, j + 1] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i, j + 1));
                            visited[i, j + 1] = true;
                        }
                }

                if (i != Width - 1)
                {
                    if (j != 0 && visited[i + 1, j - 1] == false)
                    {
                        if (array[i + 1, j - 1] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i + 1, j - 1));
                            visited[i + 1, j - 1] = true;
                        }
                        else if (array[i + 1, j - 1] != -1)
                            {
                                processed.Enqueue(new Tuple<int, int>(i + 1, j - 1));
                                visited[i + 1, j - 1] = true;
                            }
                    }
                    if (visited[i + 1, j] == false)
                    {
                        if (array[i + 1, j] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i + 1, j));
                            visited[i + 1, j] = true;
                        }
                        else if (array[i + 1, j] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i + 1, j));
                            visited[i + 1, j] = true;
                        }
                    }
                    if (j != Height - 1 && visited[i + 1, j + 1] == false)
                    {
                        if (array[i + 1, j + 1] == 0)
                        {
                            queue.Enqueue(new Tuple<int, int>(i + 1, j + 1));
                            visited[i + 1, j + 1] = true;
                        }
                        else if (array[i + 1, j + 1] != -1)
                        {
                            processed.Enqueue(new Tuple<int, int>(i + 1, j + 1));
                            visited[i + 1, j + 1] = true;
                        }
                    }
                }
            }
            return processed.Distinct().ToDictionary(c=>c, v=>array[v.Item1, v.Item2]);

        }
         
    }
}