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
using System.Diagnostics;

namespace Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Attendance : ContentPage
	{
        public HttpServices services = new HttpServices();
        string start, end, newStart, newEnd, start1, end1, reasons;
        int idd, fingID;
        string start_time_stamp, end_time_stamp, subID, presentTime;
        Attend body = new Attend();

        public Attendance ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = false;
        }


        protected override async void OnAppearing()
        {
            this.IsBusy = true;

            base.OnAppearing();

            var attend = await services.Attendance();
            for(int i = 0;i < attend.Count();i++)
            {
                if (attend[i].finger_id == Convert.ToInt32(Settings.fingID))
                {
                    /*idd = Convert.ToInt32(attend[i].id);
                    fingID = Convert.ToInt32(attend[i].finger_id);
                    start_time_stamp = attend[i].time_stamp;
                    end_time_stamp = attend[i].end_time_stamp;
                    presentTime = attend[i].present_time;*/

                    body.id = Convert.ToInt32(attend[i].id);
                    body.finger_id = Convert.ToInt32(attend[i].finger_id);
                    body.time_stamp = attend[i].time_stamp;
                    body.end_time_stamp = attend[i].end_time_stamp;
                    body.present_time = attend[i].present_time;
                    body.subject_id = attend[i].subject_id;

                }
            }

            var log = await services.Log();
            if (log.Count() > 1)
            {
                var list = log.FindAll(x => x.FINGER_ID == Convert.ToInt32(Settings.fingID));
                FlightView.ItemsSource = list;

                for (int i = 0; i < log.Count(); i++)
                {
                    if (log[i].FINGER_ID == Convert.ToInt32(Settings.fingID))
                    {
                        start = log[i].STUDENT_PRESENT_BEGIN;
                        end = log[i].STUDENT_PRESENT_END;

                        start1 = log[i].START_TIME;
                        end1 = log[i].END_TIME;
                    }
                }

                this.IsBusy = false;
            }

            string[] slpitStart = start.Split(' ');
            newStart = slpitStart[1];

            string[] slpitStar2t = end.Split(' ');
            newEnd = slpitStar2t[1];

        }

        private async void FlightView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sub = e.Item as Log;

            string[] slpitStart = sub.STUDENT_PRESENT_BEGIN.Split(' ');
            var present_begin = slpitStart[1];

            string[] slpitStar2t = sub.STUDENT_PRESENT_END.Split(' ');
            var present_end = slpitStar2t[1];

            if (present_begin == sub.START_TIME && present_end == sub.END_TIME)
            {
                await DisplayAlert("Selected Subject ", "Start Time : " + sub.START_TIME
                                 + "\nEnd Time : " + sub.END_TIME
                                 + "\nDate&Time Present: " + sub.STUDENT_PRESENT_BEGIN
                                 + "\nDate&Time Absent: " + sub.STUDENT_PRESENT_END
                                 + "\nDuration : " + sub.DURATION
                                    , "", "Ok");

            }
            else
            {
                 body.COMMENTS = await DisplayActionSheet("Missing hours reasons", "ok", null, "Late", "Was sick", "Went to the bathroom");
                 if(body.COMMENTS != " ")
                {
                    var isSuccess = await services.updateAttend(body);
                    if (isSuccess)
                    {
                        this.IsBusy = false;
                        await DisplayAlert("Comment", "Successfully added", "ok");
                    }
                    else
                    {
                        this.IsBusy = false;
                        await DisplayAlert("Comment failed.", "", "ok");
                    }
                }
            }




           /* if (await DisplayAlert("Flight Selected", "Price p.person R" + flight.Price
    + ", Cabin: " + flight.Cabin
    + ", Travel Time" + flight.TotTime,
    "Continue", "Cancel"))
            {
                await Navigation.PushAsync(new TravellerPage());
                //Application.Current.MainPage = new RegisterPage();
            }*/
        }

    }
}