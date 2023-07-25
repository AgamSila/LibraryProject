using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Model
{
    public class BorrowDetails
    {
        public string BookMongoId { get; set; }
        public int BookCode { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookPublishYear { get; set; }
        public string StudentMongoId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentFaculty { get; set; }
        public string BorrowedMongoId { get; set; }
        public String FromDate { get; set; }
        public String ToDate { get; set; }


    }
}
