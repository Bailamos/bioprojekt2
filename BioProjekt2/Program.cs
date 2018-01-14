using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioProjekt2
{
    class Program
    {
        public class SquareError
        {
            private float[][] Dmatrix;
            private float[][] dmatrix;

            public SquareError(float[][] Dmatrix, float[][] dmatrix)
            {
                this.Dmatrix = Dmatrix;
                this.dmatrix = dmatrix;
            }

            public float calculateSquaredError()
            {
                float squaredError = 0.0f;
                for (int i = 0; i < Dmatrix.Length; i++)
                {
                    for (int j = 0; j < Dmatrix.Length; j++)
                    {
                        squaredError += (Dmatrix[i][j] - dmatrix[i][j]) * (Dmatrix[i][j] - dmatrix[i][j]);
                    }
                }

                return squaredError;
            }
        }


        public class Tree
        {
            public Node root;
            public float sumDistance = 0.0f;
            public Tree(Node root)
            {
                this.root = root;
            }

            public void DFS(Node node)
            {
                if (node.left == null && node.right == null)
                {
                    return;
                }

                sumDistance += node.distanceToLeft + node.distanceToRight;    

                DFS(node.left);
                DFS(node.right);
            }
        }

        public class Node
        {
            public Node left;
            public float distanceToLeft;
            public Node right;
            public float distanceToRight;
            public Boolean visited;

            public Node(Node left, float distanceToLeft, Node right, float distanceToRight)
            {
                this.distanceToLeft = distanceToLeft;
                this.left = left;
                this.right = right;
                this.distanceToRight = distanceToRight;
                this.visited = false;
            }
        }

        public class SumBranches
        {

        }
     
        static void Main(string[] args)
        {
            float[][] Dmatrix = new float[4][]
            {
                new float[4] {0, 3, 4, 3},
                new float[4] {3, 0, 4, 5},
                new float[4] {4, 4, 0, 2},
                new float[4] {3, 5, 2, 0},
            };

            float[][] dmatrix = new float[4][]
            {
                new float[4] {0, 3, 4, 4},
                new float[4] {3, 0, 4, 4},
                new float[4] {4, 4, 0, 2},
                new float[4] {4, 4, 2, 0},
            };

            Node nodeI = new Node(null, 0.0f, null, 0.0f);
            Node nodeJ = new Node(null, 0.0f, null, 0.0f);
            Node nodeK = new Node(null, 0.0f, null, 0.0f);
            Node nodeL = new Node(null, 0.0f, null, 0.0f);
            Node nodeIJ = new Node(nodeI,1.5F,nodeJ,1.5f);
            Node nodeKL = new Node(nodeK, 1F, nodeL, 1f);
            Node root = new Node(nodeIJ, 1.5f / 2, nodeKL, 1.5f / 2);
            Tree tree = new Tree(root);

            tree.DFS(tree.root);
            Console.WriteLine(tree.sumDistance);
            Console.WriteLine("----");
            SquareError squareError = new SquareError(Dmatrix, dmatrix);
            Console.WriteLine(squareError.calculateSquaredError());
        }
    }
}
