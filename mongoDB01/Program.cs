using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("myfirstdb");
            var collection = db.GetCollection<Student>("students");
            Student student = new Student("Mahalakshmi", "Musanalli", "kurnool", "CSE");
            collection.InsertOne(student);

            var studentList = new List<Student> { new Student ( "John", "George", "Bangalore", "CS" ),
                                                  new Student ( "Harry", "Potter", "US", "CSIT" ),
                                                  new Student ( "Marry", "Zhao", "Bangalore", "EEE" )};
            collection.InsertMany(studentList);

            var response = await collection.FindAsync(_ => true);

            foreach (var stu in response.ToList())
            {
                Console.WriteLine($"Firstname: {stu.First_Name}, Lastname: {stu.Last_Name}, City: {stu.City}, Department: {stu.Department}");
            }
        }
    }
}
