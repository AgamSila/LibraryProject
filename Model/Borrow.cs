using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Model
{
    [Serializable]
    public class Borrow
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BorrowedMongoId { get; set; }

        [BsonElement("book_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string BookId { get; set; }

        [BsonElement("student_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string StudentId { get; set; }

        [BsonElement("fromDate"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public String FromDate { get; set; }

        [BsonElement("toDate"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public String ToDate { get; set; }


        public Borrow(string bookId, string studentId, String fromDate, String toDate)
        {
            BookId = bookId;
            StudentId = studentId;
            FromDate = fromDate;
            ToDate = toDate;
        }
        public override string ToString()
        {
            return "Book Id: " + BookId + "\nStudent id: " + StudentId + "\nFrom Date: " + FromDate + "\nToDate: " + ToDate;
        }
    }
}
