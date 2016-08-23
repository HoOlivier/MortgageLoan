using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoan
{
    class Loan
    {
        // Loan parameters.
        public double capital;
        public double duration;
        public double rate;
        public double loan;

        // Loan constructor.
        public Loan(double cap, double dur, double rat, double loa)
        {
            capital = cap;
            duration = dur;
            rate = rat;
            loan = loa;
        }

        // Solving for capital.
        public void solveCapital()
        {
            capital = 12 * duration * loan;
            double range = capital/2;
            double res = loanResidue();
                        
            while (!loanIsSolved())
            {
                System.Diagnostics.Debug.WriteLine("Test: {0} +- {1}", capital,range);
                if (res>=0.01)
                {
                    capital -= range;
                    range /= 2;
                    res = loanResidue();
                }
                else
                {
                    res = capital;
                    capital += range;
                    range /= 2;
                    res = loanResidue();
                }
            }

        }

        // Solving for monthly loan.
        public void solveLoan()
        {
            var solvedLoa = new double();
            // solving
            loan = solvedLoa;
        }

        // Solving for needed annual rate.
        public void solveRate()
        {
            var solvedRat = new double();
            // solving
            rate = solvedRat;
        }


        public double loanResidue()
        {
            double residue = capital;
            var interests = new double();
            double monthlyRate = Math.Pow(rate+1, Math.Pow(12, -1)) - 1;
            for (int i = 0; i < 12*duration; i++)
            {
                interests = monthlyRate * residue;
                residue += interests - loan;
            }

            return residue;
        }

        public bool loanIsSolved()
        {
            return ((loanResidue() < 0.01) & (loanResidue() > -0.01));
        }
    }
}
