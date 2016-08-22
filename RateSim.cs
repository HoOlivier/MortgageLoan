using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MortgageLoan
{
    public class RateSim : ContentPage
    {
        public RateSim()
        {
            // Input entities.
            var capitalField = new Stepper(0, 1000000, 200000, 10000);
            var durationField = new Stepper(0, 40, 20, 1);
            var loanField = new Stepper(0, 20000, 1500, 100);
            var launchSim = new Button { Text = "Launch simulation" };
            var done = new Button { Text = "I'm done" };
            done.Clicked += OnDoneButtonClicked;

            // Text entities.
            var menu = new Label { Text = "How much will you pay?" };
            var capitalText = new Label { Text = String.Format("How much you need to borrow: {0}", capitalField.Value) };
            var durationText = new Label { Text = String.Format("Your time horizon: {0}", durationField.Value) };
            var loanText = new Label { Text = String.Format("How much you can repay each month: {0}", loanField.Value) };

            // Update on input.
            durationField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                durationText.Text = String.Format("Your time horizon: {0}", durationField.Value);
            loanField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                loanText.Text = String.Format("How much you can repay each month: {0}", loanField.Value);
            capitalField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                capitalText.Text = String.Format("How much you need to borrow: {0}", capitalField.Value);

            // Launch of simulation.
            launchSim.Clicked += (object sender, EventArgs e) =>
            {
                var simulatedLoan = new Loan(capitalField.Value, durationField.Value, 0, loanField.Value);
                simulatedLoan.solveRate();
                launchSim.Text = simulatedLoan.rate.ToString();
            };


            // Page structure.
            Title = "Rate simulation";
            Content = new StackLayout
            {
                Children = {
                    menu,
                    capitalText,
                    capitalField,
                    durationText,
                    durationField,
                    loanText,
                    loanField,
                    launchSim,
                    done }
            };

        }


        async void OnDoneButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
