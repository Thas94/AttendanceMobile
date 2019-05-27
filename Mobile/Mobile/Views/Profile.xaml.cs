using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private async void Attendance(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Attendance());

        }

        private async void Course_Sub(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Course_Sub());
        }

        private async void Stu_Prof(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Update());
        }
    }

}