using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MortgageLoan
{
    public class SimulationPage : ContentPage
    {
        public SimulationPage()
        {
            var menu = new Label { Text = "I want to simulate..." };

            var button1 = new Button { Text = "...how much I can borrow" };
            button1.Clicked += onButton1Clicked;

            var button2 = new Button { Text = "...how much I will pay monthly" };
            button2.Clicked += onButton2Clicked;

            var button3 = new Button { Text = "...which rate I should aim for" };
            button3.Clicked += onButton3Clicked;

            Title = "Main menu";
            Content = new StackLayout
            {
                Children = { menu, button1, button2, button3 }
            };
        }

        async void onButton1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CapitalSim());
        }

        async void onButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoanSim());
        }

        async void onButton3Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RateSim());
        }
    }
}
