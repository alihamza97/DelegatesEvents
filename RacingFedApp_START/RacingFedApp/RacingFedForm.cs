using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingFedApp
{
    public partial class RacingFedForm : Form
    {
        private RedScoutForm redScoutFrm;                   // var for red scout window
        private BlueScoutForm blueScoutFrm;                 // var for blue scout window
      //  Racer racer;
        private List<Racer> racers = new List<Racer>();     // the list of all racers
        LinkedList linkedlist;

        public RacingFedForm()
        {
            InitializeComponent();
            this.redScoutFrm = new RedScoutForm();      // the window instance for Red Scout
            this.blueScoutFrm = new BlueScoutForm();    // the window instance for Blue Scout
            linkedlist = new LinkedList();
            
            addSomeTestingStuff();

            foreach(Racer r in racers)
            {
                r.RaceEventHandler += new Racer.RaceHander(redScoutFrm.showRankChanges);


                r.RaceEventHandler += new Racer.RaceHander(blueScoutFrm.showRankChanges);

                r.eventHandler += new Racer.RaceHander(blueScoutFrm.showRacers);
                r.eventHandler += new Racer.RaceHander(redScoutFrm.showRacers);


            }
            showAllRacers();
        }

        public int getHighestRank(int n)
        {
            // to do: assignment 4
            if (n == 0)
                return -1;
            else
            {
                if (racers[n - 1].Type.Equals("pro"))
                {
                    int maxPriceOfTheRest = getHighestRank(n - 1);
                    if (racers[n - 1].Rank > maxPriceOfTheRest)
                        return racers[n - 1].Rank;
                    else
                        return maxPriceOfTheRest;
                }
                else
                    return getHighestRank(n - 1);
            }
        }

        private void showAllRacers()
        {
            lbRacers.Items.Clear();
            foreach (Racer r in racers)
            {
                lbRacers.Items.Add(r);
            }
        }

        // potential
        internal List<Racer> getAllRacers()
        {
            return this.racers;
        }

        private void addRacer(Racer r)
        {
            racers.Add(r);
        }

        // you may assume valid user tb inputs
        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            int nr = Convert.ToInt32(tbNr.Text);
            string name = tbName.Text;
            int rank = Convert.ToInt32(tbNrOfWins.Text);
            string type = tbType.Text;
            int nrOfWins = Convert.ToInt32(tbNrOfWins.Text);
            Racer r = new Racer(nr, name, rank, type, nrOfWins);
            addRacer(r);
            
            r.eventHandler += new Racer.RaceHander(blueScoutFrm.showRacers);
            r.eventHandler += new Racer.RaceHander(redScoutFrm.showRacers);
           
            
            showAllRacers();
        }

        private void btnSortRank_Click(object sender, EventArgs e)
        {
            // to do: assignment 1a
            lbRacers.Items.Clear();
            racers.Sort();
            foreach(Racer r in this.racers)
            {
                lbRacers.Items.Add(r.ToString());
            }
            showAllRacers();
        }

        private void btnSortTypeNrOfWins_Click(object sender, EventArgs e)
        {
            // to do: assignment 1b
            lbRacers.Items.Clear();
            foreach(Racer r in this.racers)
            {
                racers.Sort(new Comparison<Racer>(r.mySortMethod));
                lbRacers.Items.Add(r.ToString());
            }
            showAllRacers();
        }

        private void btnChangeRank_Click(object sender, EventArgs e)
        {
            // to do: assignment 2

            Racer selectedRacer = (Racer)lbRacers.SelectedItem;
            if (selectedRacer != null)
            {
                int newRank = Convert.ToInt32(tbNewRank.Text);
                selectedRacer.setRank(newRank);

                showAllRacers();
                //foreach(Racer r in racers)
                //{
                //    r.
                //}

            }
            else
            {
                MessageBox.Show("no racer selected");
            }


        }


        private void btnAddTestRide_Click(object sender, EventArgs e)
        {
            // to do: assignment 3b
            Racer selectedRacer = (Racer)lbRacers.SelectedItem;
            if (selectedRacer != null)
            {
                linkedlist.addRacerToList(selectedRacer);
            }

        }

        private void btnGetHighestRank_Click(object sender, EventArgs e)
        {
            // to do: assignment 4

           
            int rank = getHighestRank(racers.Count);
            MessageBox.Show("the max rank is " + rank.ToString());
            
            



        }

        private void addSomeTestingStuff()
        {
            addRacer(new Racer(45, "Marko", 100, "pro", 5));
            addRacer(new Racer(33, "Alban", 95, "pro", 4));
            addRacer(new Racer(41, "Jack", 100, "pro", 4));
            addRacer(new Racer(37, "Arnaud", 88, "pro", 0));
            addRacer(new Racer(45, "Davide", 83, "pro", 1));
            addRacer(new Racer(11, "Jean", 59, "pro", 0));
            addRacer(new Racer(21, "Eric", 91, "rec", 3));
            addRacer(new Racer(61, "Gary", 91, "pro", 2));
        }


    }
}
