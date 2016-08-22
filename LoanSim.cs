using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MortgageLoan
{
    public class LoanSim : ContentPage
    {
        public LoanSim()
        {
            // Input entities.
            var capitalField = new Stepper(0, 1000000, 200000, 10000);
            var durationField = new Stepper(0, 40, 20, 1);
            var rateField = new Slider(0, 0.1, 0.02);
            var launchSim = new Button { Text = "Launch simulation" };
            var done = new Button { Text = "I'm done" };
            done.Clicked += OnDoneButtonClicked;

            // Text entities.
            var menu = new Label { Text = "How much will you pay?" };
            var capitalText = new Label { Text = String.Format("How much you need to borrow: {0}", capitalField.Value) };
            var durationText = new Label { Text = String.Format("Your time horizon: {0}", durationField.Value) };
            var rateText = new Label { Text = String.Format("The rate you'll get: {0}", rateField.Value) };

            // Update on input.
            durationField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                durationText.Text = String.Format("Your time horizon: {0}", durationField.Value);
            rateField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                rateText.Text = String.Format("The rate you'll get: {0}", rateField.Value);
            capitalField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                capitalText.Text = String.Format("How much you need to borrow: {0}", capitalField.Value);

            // Launch of simulation.
            launchSim.Clicked += (object sender, EventArgs e) =>
            {
                var simulatedLoan = new Loan(capitalField.Value, durationField.Value, rateField.Value, 0);
                simulatedLoan.solveLoan();
                launchSim.Text = simulatedLoan.loan.ToString();
            };


            // Page structure.
            Title = "Loan simulation";
            Content = new StackLayout
            {
                Children = {
                    menu,
                    capitalText,
                    capitalField,
                    durationText,
                    durationField,
                    rateText,
                    rateField,
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
