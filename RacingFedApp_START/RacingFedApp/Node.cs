using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingFedApp
{
    class Node
    {
        Racer Racer;
        Node Next;

       public Node(Racer racer)
        {
            this.Racer = racer;
            this.Next = null;
        }

        public Racer GetRacer()
        {
            return this.Racer;
        }
        public Node GetNext()
        {
            return this.Next;
        }
        public void setNext(Node n)
        {
            this.Next = n;
        }
    }
}
