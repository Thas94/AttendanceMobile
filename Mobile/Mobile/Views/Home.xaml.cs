using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Views;
using Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Models;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public HttpServices services = new HttpServices();
        public Home()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        private async void Login(object sender, EventArgs e)
        {
            this.IsBusy = true;

            var access = await services.Logi();
            //Settings.userDetails = access;

            for(int i = 0;i < access.Count();i++)
            {
                if (access[i].USERNAME == Username.Text && access[i].PASSWORD == Password.Text)
                {
                    Settings.userId = Convert.ToString(access[i].ID);
                    Settings.username = Convert.ToString(access[i].USERNAME);
                    Settings.lname = Convert.ToString(access[i].LNAME);
                    Settings.fname = Convert.ToString(access[i].FNAME);
                    Settings.password = Convert.ToString(access[i].PASSWORD);
                    Settings.stuNum = Convert.ToString(access[i].STUDENT_NO);
                    Settings.fingID = Convert.ToString(access[i].FINGER_ID);

                    await DisplayAlert("Login", "Login Succesful", "Ok");
                    await Navigation.PushAsync(new Profile());
                    this.IsBusy = false;
                    break;
                }
               /* else
                {
                    await DisplayAlert("Login", "Login unsuccesful, Incorrect Username or Password", "Ok");
                    this.IsBusy = false;
                    break;
                }*/
            }
        }
    }
}