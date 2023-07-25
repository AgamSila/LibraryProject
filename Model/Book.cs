using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Model
{
    [Serializable]
    public class Book
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BookMongoId { get; set; }

        [BsonElement("book_code"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int BookCode { get; set; }

        [BsonElement("book_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string BookName { get; set; }


        [BsonElement("book_author"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string BookAuthor { get; set; }

        [BsonElement("book_publish_year"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int BookPublishYear { get; set; }

        [BsonElement("book_borrowed"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string BookBorrowed { get; set; }

        public Book(int bookCode, string bookName,string bookAuthor,int bookPublishYear)
        {//Constructor
            BookCode = bookCode;
            BookName = bookName;
            BookAuthor = bookAuthor;
            BookPublishYear = bookPublishYear;
            BookBorrowed = "false";
        }
        public override string ToString()
        {//funtion that describes the object
            return "Book Code: " + BookCode + "\nBook Name: " + BookName + "\nBook Author: " 
                + BookAuthor+ "\nBook Publish year: " + BookPublishYear;
        }
    }

}
