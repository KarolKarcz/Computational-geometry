using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace MeshGO.Models
{
    public class Node
    {
        public Rect rectangle;

        public Node n1, n2, n3, n4;

        public Node(Rect rectangle, Node n1, Node n2, Node n3, Node n4)
        {
            this.rectangle = rectangle;

            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
        }
    }
}
