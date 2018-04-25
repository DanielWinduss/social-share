using System;
using Xamarin.Forms;

namespace SocialShare
{
    public class MainPageViewModel : ViewModelBase
    {
        private Command _loginCommand;

        public Command LoginCommand => _loginCommand ?? (_loginCommand = new Command(() => Navigate(new UserPage())));
    }
}
