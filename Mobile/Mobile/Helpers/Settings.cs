using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Mobile.Models;

namespace Mobile.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }


        public static string username
        {
            get
            {
                return AppSettings.GetValueOrDefault("username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("username", value);
            }
        }

        public static string lname
        {
            get
            {
                return AppSettings.GetValueOrDefault("lname", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("lname", value);
            }
        }

        public static string fname
        {
            get
            {
                return AppSettings.GetValueOrDefault("fname", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("fname", value);
            }
        }

        public static string password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }

        public static string userId
        {
            get
            {
                return AppSettings.GetValueOrDefault("userId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("userId", value);
            }
        }

        public static string stuNum
        {
            get
            {
                return AppSettings.GetValueOrDefault("stuNum", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("stuNum", value);
            }
        }

        public static string fingID
        {
            get
            {
                return AppSettings.GetValueOrDefault("fingID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("fingID", value);
            }
        }



        public static List<StudentModel> userDetails
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("userDetails", "");
                List<StudentModel> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<StudentModel>();
                else
                    myList = JsonConvert.DeserializeObject<List<StudentModel>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("userDetails", listValue);
            }
        }
    }
}
