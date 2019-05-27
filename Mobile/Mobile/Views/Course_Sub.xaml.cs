using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Models;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Course_Sub : ContentPage
	{
        public HttpServices services = new HttpServices();
        int course_ID;

        public Course_Sub ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }

        protected override async void OnAppearing()
        {
            this.IsBusy = true;

            base.OnAppearing();

            var access = await services.StuCourse();
            var sub = await services.Subjects();
            var course = await services.Course();

            if(access.Count() > 1 && sub.Count() > 1 && course.Count() > 1)
            {
                this.IsBusy = false;
            }

            for(int i = 0;i < access.Count();i++)
            {
                if(access[i].STUDENT_ID == Convert.ToInt32(Settings.userId))
                {
                    course_ID = Convert.ToInt32(access[i].COURSE_ID);
                    break;
                }
            }

            FlightView.ItemsSource = sub.FindAll(x => x.COURSE_ID == course_ID);
            var cos = course.Find(x => x.ID == course_ID);
            courseName.Text = cos.DESCRIPTION;

        }

        private async void FlightView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sub = e.Item as Subject;

            await DisplayAlert("Selected Subject ", "Start Time : " + sub.START_TIME
                + "\nEnd Time : " + sub.END_TIME
                   , "", "Ok");
        }

        }
    }