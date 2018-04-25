using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace SocialShare
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PageBase PageBase { get; set; }

        public void Navigate(PageBase page)
        {
            NavigationPage.SetHasNavigationBar(page, false);
            PageBase.Navigation.PushAsync(page);
        }

        protected bool RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            if (PropertyChanged == null)
                return false;

            var memberExpression = property.Body as MemberExpression;

            PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));

            return true;
        }
    }
}
