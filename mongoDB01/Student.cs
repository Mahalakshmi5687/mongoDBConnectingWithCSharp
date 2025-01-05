using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mongo_01
{
    public class Student
    {

        public ObjectId Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }

        public Student(string first_Name, string last_Name, string city, string department)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            City = city;
            Department = department;
        }




    }
}
