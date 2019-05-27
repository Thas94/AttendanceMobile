using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpServices
    {
        public string url = "http://attedanco.000webhostapp.com";


        public async Task<List<StudentModel>> Logi()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/STUDENT/GetAll.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<StudentModel>>(content);
            return claims;
        }


        public async Task<bool> updateStudent(StudentModel model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "/Attendance/STUDENT/update.php", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> updateAttend(Attend model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "/Attendance/ATTENDANCE/update.php", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<StudentCourse>> StuCourse()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/STUDENT_COURSE/GetAll.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<StudentCourse>>(content);
            return claims;
        }

        public async Task<List<Subject>> Subjects()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/SUBJECT/GetAll.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<Subject>>(content);
            return claims;
        }

        public async Task<List<Course>> Course()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/COURSE/GetAll.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<Course>>(content);
            return claims;
        }

        public async Task<List<Attend>> Attendance()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/ATTENDANCE/arduino.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<Attend>>(content);
            return claims;
        }

        public async Task<List<Log>> Log()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url + "/Attendance/ATTENDANCE/GetAll.php");

            var content = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<Log>>(content);
            return claims;
        }

    }
}
