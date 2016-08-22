using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MortgageLoan
{
    public class CapitalSim : ContentPage
    {
        public CapitalSim()
        {
            // Input entities.
            var durationField = new Stepper(0,40,20,1);
            var rateField = new Slider(0,0.1,0.02);
            var loanField = new Stepper(0,20000,1500,100);
            var launchSim = new Button { Text = "Launch simulation" };
            var done = new Button { Text = "I'm done" };
            done.Clicked += OnDoneButtonClicked;

            // Text entities.
            var menu = new Label { Text = "How much can you borrow?" };
            var durationText = new Label { Text = String.Format("Your time horizon: {0}", durationField.Value)};
            var rateText = new Label { Text = String.Format("The rate you'll get: {0}",rateField.Value) };
            var loanText = new Label { Text = String.Format("How much you can repay each month: {0}",loanField.Value) };

            // Update on input.
            durationField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                durationText.Text = String.Format("Your time horizon: {0}", durationField.Value);
            rateField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                rateText.Text = String.Format("The rate you'll get: {0}", rateField.Value);
            loanField.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                loanText.Text = String.Format("How much you can repay each month: {0}", loanField.Value);

            // Launch of simulation.
            launchSim.Clicked += (object sender, EventArgs e) =>
            {
                launchSim.Text = "Badaboom";
                var simulatedLoan = new Loan(0, durationField.Value, rateField.Value, loanField.Value);
                simulatedLoan.solveCapital();
                launchSim.Text = simulatedLoan.capital.ToString();
            };


            // Page structure.
            Title = "Capital simulation";
            Content = new StackLayout
            {
                Children = {
                    menu,
                    durationText,
                    durationField,
                    rateText,
                    rateField,
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
