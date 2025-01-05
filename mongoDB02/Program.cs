using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_02
{
    public class Program
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("EmployeeDB");
        static IMongoCollection<Employee> collection = db.GetCollection<Employee>("EmployeesInfo");
        public static void Main(string[] args)
        {
            Employee employee = new Employee("Vidya", "Haval", "Consulting");
            ReadAll();
            CreateOne(employee);
            ReadAll();
            UpdateOne();
            ReadAll();
            DeleteOne();
            ReadAll();
            Console.ReadKey();
        }

        public static void CreateOne(Employee employee)
        {
            collection.InsertOne(employee);
        }
        public static void ReadAll()
        {
            List<Employee> list = collection.AsQueryable().ToList<Employee>();
            var employees = from e in list select e;
            Console.WriteLine("The current document/s:");
            foreach (Employee e in employees)
            {
                Console.WriteLine($"EmpFirstName: {e.FirstName}  EmpLastName: {e.LastName} EmpDepartment: {e.Department}");
            }
        }
        public static void UpdateOne()
        {
            var updateDef = Builders<Employee>.Update.Set(e => e.FirstName, "Aboode");
            collection.UpdateOne(e => e.FirstName == "Vidya", updateDef);
        }
        public static void DeleteOne()
        {
            collection.DeleteOne(e => e.FirstName == "Aboode");
        }
    }
}
