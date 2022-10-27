using U5;

using System;
using System.Text;

namespace U5
{
    public static class AvlTreeDotPrinter<Person> where Person : IComparable<Person>
    {
        public static string Print(AvlTree<Person> tree)
        {
            StringBuilder sb = new();

            DotWalk(tree.Root, sb);

            return "digraph {\ngraph [ordering=\"out\"];\n" + sb.ToString() + "}\n";
        }

        private static void DotWalk(AvlTree<Person>.Node n, StringBuilder sb)
        {
            if (n == null)
            {
                return;
            }

            sb.Append($"{n.Key} [label=\"{n.Key} ({n.Height})\"];\n");

            if (n.Left != null)
            {
                DotWalk(n.Left, sb);
                sb.Append($"{n.Key} ->  {n.Left.Key};\n");
            }

            if (n.Right != null)
            {
                DotWalk(n.Right, sb);
                sb.Append($"{n.Key} ->  {n.Right.Key};\n");
            }
        }
    }
}