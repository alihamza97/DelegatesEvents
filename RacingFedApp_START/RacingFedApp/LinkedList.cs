using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingFedApp
{
    class LinkedList
    {
        Node first;
        Node last;

        public LinkedList()
        {
            this.first = null;
            this.last = null;
        }

        public void addRacerToList(Racer r)
        {
            if (this.first == null)
            {
                // there are no items in the linked list
                this.first = new Node(r);
                this.last = this.first;
            }
            else
            {
                // add racer at the front of the list
                Node temp = first;
                this.first = new Node(r);
                this.first.setNext(temp);
            }
        }

        public int nrOfTestDrivesWithPlayersOfTeam(string team)
        {
            if (this.first == null)
                return 0;
            else
            {
                Node curr = this.first;
                int counter = 0;
                while (curr != null)
                {
                    if (curr.GetRacer().Type.Equals(team))
                    {
                        counter++;
                    }
                    curr = curr.GetNext();
                }
                return counter;
            }
        }
    }
}
