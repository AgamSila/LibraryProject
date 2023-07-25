using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Model
{
    [Serializable]
    public class Student
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string StudentMongoId { get; set; }

        [BsonElement("student_id"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int StudentId { get; set; }

        [BsonElement("student_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string StudentName { get; set; }


        [BsonElement("student_faculty"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string StudentFaculty { get; set; }


        public Student(int stuId, string studentName, string studentFaculty)
        {
            StudentId = stuId;
            StudentName = studentName;
            StudentFaculty = studentFaculty;
            
        }
        public override string ToString()
        {
            return "Student Id: " + StudentId + "\nStudent Name: " + StudentName + "\nStudent Faculty: " + StudentFaculty;
        }
    }
}
