using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenaimento_con_arbol_binario
{
    class ArbolBinario
    {
        public Nodo Root { get; set; }

        public bool Add(int value)
        {
            Nodo before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Datos) //Is new Nodo in left tree? 
                    after = after.NodoIzquierdo;
                else if (value > after.Datos) //Is new Nodo in right tree?
                    after = after.NodoDerecho;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Nodo newNodo = new Nodo();
            newNodo.Datos = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNodo;
            else
            {
                if (value < before.Datos)
                    before.NodoIzquierdo = newNodo;
                else
                    before.NodoDerecho = newNodo;
            }

            return true;
        }

        public Nodo Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Nodo Remove(Nodo parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Datos) parent.NodoIzquierdo = Remove(parent.NodoIzquierdo, key);
            else if (key > parent.Datos)
                parent.NodoDerecho = Remove(parent.NodoDerecho, key);

            // if value is same as parent's value, then this is the Nodo to be deleted  
            else
            {
                // Nodo with only one child or no child  
                if (parent.NodoIzquierdo == null)
                    return parent.NodoDerecho;
                else if (parent.NodoDerecho == null)
                    return parent.NodoIzquierdo;

                // Nodo with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Datos = MinValue(parent.NodoDerecho);

                // Delete the inorder successor  
                parent.NodoDerecho = Remove(parent.NodoDerecho, parent.Datos);
            }

            return parent;
        }

        private int MinValue(Nodo Nodo)
        {
            int minv = Nodo.Datos;

            while (Nodo.NodoIzquierdo != null)
            {
                minv = Nodo.NodoIzquierdo.Datos;
                Nodo = Nodo.NodoIzquierdo;
            }

            return minv;
        }

        private Nodo Find(int value, Nodo parent)
        {
            if (parent != null)
            {
                if (value == parent.Datos) return parent;
                if (value < parent.Datos)
                    return Find(value, parent.NodoIzquierdo);
                else
                    return Find(value, parent.NodoDerecho);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Nodo parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.NodoIzquierdo), GetTreeDepth(parent.NodoDerecho)) + 1;
        }

        public void TraversePreOrder(Nodo parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Datos + " ");
                TraversePreOrder(parent.NodoIzquierdo);
                TraversePreOrder(parent.NodoDerecho);
            }
        }

        public void TraverseInOrder(Nodo parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.NodoIzquierdo);
                Console.Write(parent.Datos + " ");
                TraverseInOrder(parent.NodoDerecho);
            }
        }

        public void TraversePostOrder(Nodo parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.NodoIzquierdo);
                TraversePostOrder(parent.NodoDerecho);
                Console.Write(parent.Datos + " ");
            }
        }
    }
}
