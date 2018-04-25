using Xamarin.Forms;

namespace SocialShare
{
    public class PageBase : ContentPage
    {
        protected override void OnAppearing()
        {
            var viewModel = BindingContext as ViewModelBase;

            if (viewModel != null)
                viewModel.PageBase = this;

            base.OnAppearing();
        }
    }
}
