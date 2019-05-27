using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Helpers;
using Mobile.Models;
using Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        StudentModel body = new StudentModel();
        public HttpServices services = new HttpServices();

        public Update()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;

            username.Text = Settings.username;
            FirstName.Text = Settings.fname;
            LastName.Text = Settings.lname;
            StuNum.Text = Settings.stuNum;
            Password.Text = Settings.password;
            fingerID.Text = Settings.fingID;
            ID.Text = Settings.userId;
        }

        private async void UpdateStudent(object sender, EventArgs e)
        {
            this.IsBusy = true;

            body.ID = Convert.ToInt32(ID.Text);
            body.USERNAME = username.Text;
            body.FNAME = FirstName.Text;
            body.LNAME = LastName.Text;
            body.STUDENT_NO = Convert.ToInt32(StuNum.Text);
            body.PASSWORD = Password.Text;
            body.FINGER_ID = Convert.ToInt32(fingerID.Text);

            var isSuccess = await services.updateStudent(body);
            if (isSuccess)
            {
                this.IsBusy = false;
                await DisplayAlert("Update", "Successful", "ok");
                await Navigation.PushAsync(new Profile());

            }
            else
            {
                this.IsBusy = false;
                await DisplayAlert("Update failed.", "", "ok");
            }

        }
    }
}