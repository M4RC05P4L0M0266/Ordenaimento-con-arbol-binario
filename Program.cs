using System;

namespace Ordenaimento_con_arbol_binario
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidad = 1;
            ArbolBinario ArbolBinario = new ArbolBinario();
            Console.WriteLine("Limite del arbol: ");
            cantidad = int.Parse(Console.ReadLine());
            for (int i = 1; i <= cantidad; i++)
            {
                Console.WriteLine("Introduzca el valor " + i);
                ArbolBinario.Add(int.Parse(Console.ReadLine()));
            }

            Nodo Nodo = ArbolBinario.Find(5);
            int depth = ArbolBinario.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            ArbolBinario.TraversePreOrder(ArbolBinario.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");
            ArbolBinario.TraverseInOrder(ArbolBinario.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            ArbolBinario.TraversePostOrder(ArbolBinario.Root);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
