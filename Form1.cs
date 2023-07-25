using System;
using MongoDB.Driver;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject.Model;
using MongoDB.Bson;

namespace Finalproject
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyMongo"].ConnectionString;
        IMongoCollection<Book> books;
        IMongoCollection<Student> students;
        IMongoCollection<Borrow> borrows;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {//the function loads all the relevant data to the form
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);
            string dbName = mongoUrl.DatabaseName;

            try
            {
                MongoClient mongoClient = new MongoClient(connectionString);

                IMongoDatabase db = mongoClient.GetDatabase(dbName);

                books = db.GetCollection<Book>("Books");
                students = db.GetCollection<Student>("Students");
                borrows = db.GetCollection<Borrow>("Borrows");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem accessing DataBase\n\n" + ex.Message,
                                "connection failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            
            loadBooks();
            loadStudents();
            loadBorrowsFullDetails();

            comboBox_StudentFaculty.Text = "Select Faculty";
            comboBox_FilterStudentFaculty.Text = "Select Faculty";
            comboBox_Operator1.Text = "And";
            comboBox_Operator2.Text = "And";
        }
        
        // Insert new Student keyPressed events
        private void insert_student_id_keyPressed(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_textBox_stuId.Clear();
        }
        private void insert_student_name_keyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_StudentFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider_StudentFaculty.Clear();
        }
        private void btn_insertStudent_Click(object sender, EventArgs e)
        {//The function inserts new student's details to the students table
           
            if (comboBox_StudentFaculty.SelectedItem.Equals("Select Faculty")
                || comboBox_StudentFaculty.Text.Equals("Select Faculty"))
            {
                errorProvider_StudentFaculty.SetError(comboBox_StudentFaculty, "Please Select Some Faculty");
            }

            else  if (string.IsNullOrEmpty(textBox_StuName.Text))
            {
                
                MessageBox.Show("It is not possible to create a new student without entering the student's name\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox_stuId.Text))
            {
                MessageBox.Show("It is not possible to create a new student without entering the student's id\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var filter = Builders<Student>.Filter.Eq(student => student.StudentId, Convert.ToInt32(textBox_stuId.Text));
                    List<Student> results = students.Find(filter).ToList();

                    if(results.Count>0)
                    {
                        errorProvider_textBox_stuId.SetError(textBox_stuId,
                            "Please enter another id,the id you enterded exists in the system");
                    }
                    
                    else
                    {
                            Student studentDetails = new Student(Convert.ToInt32(textBox_stuId.Text),
                                        textBox_StuName.Text, comboBox_StudentFaculty.Text.ToString());

                            students.InsertOne(studentDetails);
                            MessageBox.Show("The following student was inserted :\n" + studentDetails.ToString(),
                                "New Student Criation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            loadStudents(); //refresh the screen after a successful insert
                    }   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("There was a problem to insert a student details :\n" + ex.Message,
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
        // Insert new Book keyPressed events
        private void insert_book_code_keyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProviderBookCode.Clear();
        }

        private void textBox_bookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter letters or digits only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insert_book_Author_keyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter letters only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_bookPublishYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_BookPublishYear.Clear();
        }
        private void btn_insertBook_Click(object sender, EventArgs e)
        {//the function inserts new book details to the books table
            try
            {
                 if (string.IsNullOrEmpty(textBox_bookCode .Text))
                {
                    MessageBox.Show("It is not possible to create a new book without entering the book's code\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookName.Text))
                {
                    MessageBox.Show("It is not possible to create a new book without entering the book's name\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookAuthor.Text))
                {
                    MessageBox.Show("It is not possible to create a new book without entering the book's author name\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookPublishYear.Text))
                {
                    MessageBox.Show("It is not possible to create a new book without entering the book's publish year\n",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
                else if (!((Convert.ToInt32(textBox_bookPublishYear.Text) >= 1900)
                    && (Convert.ToInt32(textBox_bookPublishYear.Text) <= DateTime.Now.Year)))
                {
                    errorProvider_BookPublishYear.SetError(textBox_bookPublishYear,
                        "The range that is allowed to enter is between 1900 and current year");
                }
                else
                {
                    var filter = Builders<Book>.Filter.Eq(book => book.BookCode, Convert.ToInt32(textBox_bookCode.Text));
                    List<Book> results = books.Find(filter).ToList();
                    if (results.Count > 0)
                    {
                     errorProviderBookCode.SetError(textBox_bookCode,
                            "Please enter another code,the code you enterded exists in the library");
                    }
                    else
                    {
                       
                        Model.Book bookDetails = new Model.Book(Convert.ToInt32(textBox_bookCode.Text),
                        textBox_bookName.Text, textBox_bookAuthor.Text, Convert.ToInt32(textBox_bookPublishYear.Text));

                        books.InsertOne(bookDetails);
                        MessageBox.Show("The following book was inserted :\n" + bookDetails.ToString(),
                            "New Book Criation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        loadBooks(); //refresh the screen after a successful insert
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to insert a book details :\n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        public void loadBooks()
        {//the function initialize relevant datagrids with books details
            dataGridView_Books.DataSource = books.Aggregate().ToList();
            dataGridView_Books.Columns["BookMongoId"].Visible = false;
            dataGridView_booksFilter.DataSource = books.Aggregate().ToList();
            dataGridView_booksFilter.Columns["BookMongoId"].Visible = false;
           
        }
        public void loadStudents()
        {//the function initialize relevant datagrids with students details
            dataGridView_Students.DataSource = students.Aggregate().ToList();
            dataGridView_Students.Columns["StudentMongoId"].Visible = false;
            dataGridView_StudentsFilter.DataSource = students.Aggregate().ToList();
            dataGridView_StudentsFilter.Columns["StudentMongoId"].Visible = false;

        }
        public void loadBorrowsFullDetails()
        {//the function initialize relevant datagrids with boorows full details
            dataGridView_Borrow.DataSource = loadDetailsBorrows();
            dataGridView_Borrow.Columns["StudentMongoId"].Visible = false;
            dataGridView_Borrow.Columns["BookMongoId"].Visible = false;
            dataGridView_Borrow.Columns["BorrowedMongoId"].Visible = false;
        }
        private void btn_refreshListOfBooks_Click(object sender, EventArgs e)
        {//the function refresh the original books details
            loadBooks();
        }
        private void dataGridView_Books_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //the function lets the user double click on desire cell data 
            //and opens up new window in witch the user can update the book details
            UpdateOrDeleteBook detailswin = new UpdateOrDeleteBook(books);
            detailswin.textBox_bookId.Text = dataGridView_Books.CurrentRow.Cells[0].Value.ToString();
            detailswin.textBox_bookCode.Text = dataGridView_Books.CurrentRow.Cells[1].Value.ToString();
            detailswin.textBox_bookName.Text = dataGridView_Books.CurrentRow.Cells[2].Value.ToString();
            detailswin.textBox_bookAuthor.Text = dataGridView_Books.CurrentRow.Cells[3].Value.ToString();
            detailswin.textBox_bookPublishYear.Text = dataGridView_Books.CurrentRow.Cells[4].Value.ToString();
            detailswin.textBox_BookStatus.Text = dataGridView_Books.CurrentRow.Cells[5].Value.ToString();
            detailswin.ShowDialog();

            //after we are coming back from the update/delete win we need to refresh the screen 
            loadBooks();
        }
        private void dataGridView_Students_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //the function lets the user double click on desire cell data 
            //and opens up new window in witch the user can delete the book details
            
            UpdateOrDeleteStudent detailswin = new UpdateOrDeleteStudent(students, borrows);
            detailswin.textBox_mongoId.Text = dataGridView_Students.CurrentRow.Cells[0].Value.ToString();
            detailswin.textBox_StudentId.Text = dataGridView_Students.CurrentRow.Cells[1].Value.ToString();
            detailswin.textBox_studentName.Text = dataGridView_Students.CurrentRow.Cells[2].Value.ToString();
            
            foreach (var item in comboBox_StudentFaculty.Items)
                detailswin.comboBox_student_faculty.Items.Add(item);
            detailswin.comboBox_student_faculty.Text = dataGridView_Students.CurrentRow.Cells[3].Value.ToString();
            detailswin.ShowDialog();

            //after we are coming back from the update/delete win we need to refresh the screen 
            loadStudents();
        }

        private void btn_createBorrow_Click_1(object sender, EventArgs e)
        {//the function allows to create new borrow
          //and insert new borrow details in borrows table

            string studentId = dataGridView_Students.SelectedRows[0].Cells[0].Value.ToString();
            string bookId = dataGridView_Books.SelectedRows[0].Cells[0].Value.ToString();

            try
            {
                var filterBuilder = Builders<Book>.Filter;
                var filterBookStatus = filterBuilder.Empty;

                filterBookStatus = filterBuilder.And(
                    filterBuilder.Eq(book => book.BookMongoId, bookId),
                    filterBuilder.Eq(book => book.BookBorrowed, "true"));
                List<Book> result = books.Find(filterBookStatus).ToList();
                if (result.Count > 0)
                {
                    MessageBox.Show("The book you selected is currently borrowed,it cannot be borrowed again", "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
                else
                {
                    
                    var filter = Builders<Book>.Filter.Eq(book => book.BookMongoId, bookId);

                    Borrow borrowedDetails = new Borrow(bookId,studentId, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"));

                    borrows.InsertOne(borrowedDetails);

                    //switch book mood to borrowed 

                    UpdateDefinition<Book> updateDefintion = Builders<Book>.Update
                        .Set(book => book.BookBorrowed, "true");

                    books.UpdateOne(filter, updateDefintion);

                    MessageBox.Show("Borrow created", "New Borrow Criation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    loadBorrowsFullDetails();
                    loadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to create a borrow \n" + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }
        public List<BorrowDetails> loadDetailsBorrows()
        {//the function load full details of the boorow
         //all details of the students and the books that they choose to borrow
              List<Borrow> borrow = new List<Borrow>();
                borrow = borrows.Aggregate().ToList();

                List<BorrowDetails> borrowWithFullDetails = new List<BorrowDetails>();

                foreach (Borrow br in borrow)
                {
                    BorrowDetails details = new BorrowDetails();
                    details.StudentMongoId = br.StudentId;
                    details.BookMongoId = br.BookId;
                    details.BorrowedMongoId = br.BorrowedMongoId;
                    details.FromDate = br.FromDate;
                    details.ToDate = br.ToDate;

                    string studentId = br.StudentId;
                    // Get the details of student:
                    FilterDefinition<Student> studentFilter = Builders<Student>.Filter.Eq(s => s.StudentMongoId, studentId);
                    List<Student> studentsList = students.Find(studentFilter).ToList();
                    details.StudentId = studentsList[0].StudentId;
                    details.StudentName = studentsList[0].StudentName;
                    details.StudentFaculty = studentsList[0].StudentFaculty;

                    string bookId = br.BookId;
                    FilterDefinition<Book> bookFilter = Builders<Book>.Filter.Eq(b => b.BookMongoId, bookId);
                    List<Book> booksList = books.Find(bookFilter).ToList();
                    details.BookCode = booksList[0].BookCode;
                    details.BookName = booksList[0].BookName;
                    details.BookAuthor = booksList[0].BookAuthor;
                    details.BookPublishYear = booksList[0].BookPublishYear;
                    borrowWithFullDetails.Add(details);
                }
                return borrowWithFullDetails;
            
        }
        //Books filters  keyPressed events
        private void textBox_filterByCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_filterByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter letters or digits only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_filterByAuthor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter letters only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_filterByPublishYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_BookPublishYear.Clear();
        }
        private void textBox_filterByPublishYearInFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits or comma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_filterByPublishYearInFilter.Clear();
        }
        //Books filters
        private void btn_filterByCode_Click(object sender, EventArgs e)
        {//The function shows the user the results that match his search by book code filter
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            try
            {
                //define the where criteria:
                if (!string.IsNullOrEmpty(textBox_filterByCode.Text))
                {
                    filter = filterBuilder.Eq(book => book.BookCode, Convert.ToInt32(textBox_filterByCode.Text));
                }
                    

                //get the result according to the filter
               
                List<Book> results = books.Find(filter).ToList();
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_booksFilter.DataSource = null;
                }
                else
                    //present thr result on the screen :
                    dataGridView_booksFilter.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book code details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void btn_filterByName_Click(object sender, EventArgs e)
        {//The function shows to the user, results that match to the filter he selected,by book name
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            try
            {
                //define the where criteria:
                if (!string.IsNullOrEmpty(textBox_filterByName.Text))
                    filter = Builders<Book>.Filter.Eq(book => book.BookName, textBox_filterByName.Text);

                List<Book> results = books.Find(filter).ToList();
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_booksFilter.DataSource = null;
                }
                //present thr result on the screen :
                else
                    dataGridView_booksFilter.DataSource = results;
            }
           
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book name details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void btn_filterByAuthor_Click(object sender, EventArgs e)
        {//The function shows the user results that match the filter he selected,by book author
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            try
            {
                //define the where criteria:
                if (!string.IsNullOrEmpty(textBox_filterByAuthor.Text))
                    filter = Builders<Book>.Filter.Eq(book => book.BookAuthor, textBox_filterByAuthor.Text);

                List<Book> results = books.Find(filter).ToList();
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_booksFilter.DataSource = null;
                }
                //present thr result on the screen :
                else
                    dataGridView_booksFilter.DataSource = results;
            }

            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book author details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
       
        private void btn_filterByPublishYear_GTE_Click(object sender, EventArgs e)
        {//The function shows the user results that match the filter he selected
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            try
            {
                
                if (!string.IsNullOrEmpty(textBox_filterByPublishYear.Text))
                    filter = Builders<Book>.Filter.Gte(book => book.BookPublishYear, 
                        Convert.ToInt32(textBox_filterByPublishYear.Text));

                if(!(string.IsNullOrEmpty(textBox_filterByPublishYear.Text)) &&
                    !((Convert.ToInt32(textBox_filterByPublishYear.Text) >= 1900)
                        && (Convert.ToInt32(textBox_filterByPublishYear.Text) <= DateTime.Now.Year)))
                {
                    errorProvider_BookPublishYear.SetError(textBox_filterByPublishYear,
                        "The range that is allowed to enter is between 1900 and current year");
                }
                List<Book> results = books.Find(filter).ToList();
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_booksFilter.DataSource = null;
                }
                //present thr result on the screen :
                else
                    dataGridView_booksFilter.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book publish year details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
      
        private void btn_filterByPublishYear_LT_Click(object sender, EventArgs e)
        {//The function shows the user results that match the filter he selected
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            
           
            try
            {
                if (!string.IsNullOrEmpty(textBox_filterByPublishYear.Text))
                    filter = Builders<Book>.Filter.Lt(book => book.BookPublishYear,
                        Convert.ToInt32(textBox_filterByPublishYear.Text));
                if (!(string.IsNullOrEmpty(textBox_filterByPublishYear.Text)) && 
                        !((Convert.ToInt32(textBox_filterByPublishYear.Text) >= 1900)
                            && (Convert.ToInt32(textBox_filterByPublishYear.Text) <= DateTime.Now.Year)))
                {
                    errorProvider_BookPublishYear.SetError(textBox_filterByPublishYear,
                        "The range that is allowed to enter is between 1900 and current year");
                }
                
                
                List<Book> results = books.Find(filter).ToList();
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_booksFilter.DataSource = null;
                }
                //present thr result on the screen :
                else
                    dataGridView_booksFilter.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book publish year details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            
        }
        private void bth_filterByPublishYear_In_Click(object sender, EventArgs e)
        {//The function shows the user results that match the filter he selected
            string allYearsAsStr = textBox_filterByPublishYearInFilter.Text;
            string[] yearsStrArr = allYearsAsStr.Split(',');
            bool flag = false;
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Empty;
            try
            {
                if (!string.IsNullOrEmpty(textBox_filterByPublishYearInFilter.Text))
                {
                    foreach (string str in yearsStrArr)
                        if (!(Convert.ToInt32(str) >= 1900 && Convert.ToInt32(str) <= DateTime.Now.Year))
                            flag = true;
                }

                if (flag)
                {
                    errorProvider_filterByPublishYearInFilter.SetError(textBox_filterByPublishYearInFilter,
                    "The range that is allowed to enter is between 1900 and current year");
                }

                else
                {


                    List<int> years = new List<int>();
                    if (!string.IsNullOrEmpty(textBox_filterByPublishYearInFilter.Text))
                    {
                        //convet the string arr into list of int
                        foreach (string currnet in yearsStrArr)
                            years.Add(Convert.ToInt32(currnet));


                        filter = Builders<Book>.Filter.In(book => book.BookPublishYear, years);

                    }
                    List<Book> results = books.Find(filter).ToList();
                    if (results.Count == 0 || filter == filterBuilder.Empty)
                    {
                        MessageBox.Show("No matching records found", "Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    if (filter == filterBuilder.Empty)
                    {
                        dataGridView_booksFilter.DataSource = null;
                    }
                    //present thr result on the screen :
                    else
                        dataGridView_booksFilter.DataSource = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a book publish year details \n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        
        //Student Filters
        private void btn_RefreshStudentsList_Click(object sender, EventArgs e)
        {//the function refresh student detail before filters
            loadStudents();
        }
        private void textBox_FilterStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_FilterStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_StudentDetailsFilter_Click(object sender, EventArgs e)
        {//The function checks that the details entered by the user are correct
         //and if so shows the user the relevant data he has selected to search for student details
           
            try
            {
                SearchAndDisplayData(textBox_FilterStudentId.Text, textBox_FilterStudentName.Text,
                    comboBox_FilterStudentFaculty.Text.ToString(),
                            comboBox_Operator1.Text, comboBox_Operator2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to display a students details :\n" + ex.Message,
                        "try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            
        }
            public void SearchAndDisplayData(string studentID, string studentName, 
                                        string faculty, string logicalOperator1, string logicalOperator2)
            {//The function receives student datails, and two logical conditions,
             //checks whether the logical conditions are met in the student database,
             //and displays the relevant data to the user

                var filterBuilder = Builders<Student>.Filter;
                var filter = filterBuilder.Empty;
            
                if (logicalOperator1 == "And")
                {
                    if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                    {
                        filter = filterBuilder.And(
                           filterBuilder.Eq(s => s.StudentId, Convert.ToInt32(studentID)),
                           filterBuilder.Eq(s => s.StudentName, studentName));
                    }
                    else if (!string.IsNullOrEmpty(studentID) && string.IsNullOrEmpty(studentName))
                    {
                        filter = filterBuilder.Eq(s => s.StudentId, Convert.ToInt32(studentID));
                    }
                    else if(!string.IsNullOrEmpty(studentName) && string.IsNullOrEmpty(studentID))
                    {
                        filter = filterBuilder.Eq(s => s.StudentName, studentName);
                    }
                }
                else if (logicalOperator1 == "Or")
                {

                    if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                    {
                        filter = filterBuilder.Or(
                         filterBuilder.Eq(s => s.StudentId, Convert.ToInt32(studentID)),
                         filterBuilder.Eq(s => s.StudentName, studentName));
                    }
                    else if (!string.IsNullOrEmpty(studentID) && string.IsNullOrEmpty(studentName))
                    {
                        filter = filterBuilder.Eq(s => s.StudentId, Convert.ToInt32(studentID));
                    }
                    else if (!string.IsNullOrEmpty(studentName) && string.IsNullOrEmpty(studentID))
                    {
                        filter = filterBuilder.Eq(s => s.StudentName, studentName);
                    }

                }
           
                if (logicalOperator2 == "And")
                {

                    if(! faculty.Equals("Select Faculty"))
                    {
                        filter = filterBuilder.And(filter, filterBuilder.Eq(s => s.StudentFaculty, faculty));
                    }
                }

                else if (logicalOperator2 == "Or")
                {
                    if (!faculty.Equals("Select Faculty"))
                    {
                        filter = filterBuilder.Or(filter, filterBuilder.Eq(s => s.StudentFaculty, faculty));
                    }
                }

                // Execute the query and retrieve the matching documents
                List<Student> result = students.Find(filter).ToList();

                if (result.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found ", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                }
                if(filter == filterBuilder.Empty)
                {
                    dataGridView_StudentsFilter.DataSource = null;
                }
                else
                    dataGridView_StudentsFilter.DataSource = result;
         }

        //Update,Delete Borrows
        
        private void btn_deleteBorrow_Click(object sender, EventArgs e)
        {//The function deletes selected borrow

            string BorrowedMongoId = dataGridView_Borrow.SelectedRows[0].Cells[9].Value.ToString();
            string bookMongoId = dataGridView_Borrow.SelectedRows[0].Cells[0].Value.ToString();
            
            try
            {
                var filter = Builders<Borrow>.Filter.Eq(p => p.BorrowedMongoId, BorrowedMongoId);
                
                DeleteResult res = borrows.DeleteOne(filter);
                
                if (res.DeletedCount == 1)
                    MessageBox.Show("The Borrow has been successfully deleted", "The deletion of the borrow", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //represent the new data in data grid
                loadBorrowsFullDetails();

                //switch book mood to avilable 
                var bookFilter = Builders<Book>.Filter.Eq(book => book.BookMongoId, bookMongoId);
                UpdateDefinition<Book> updateDefintion = Builders<Book>.Update
                    .Set(book => book.BookBorrowed, "false");
              

                books.UpdateOne(bookFilter, updateDefintion);
                loadBooks();
                
        }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to delete a borrow \n" + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
}

        private void dataGridView_Borrow_DoubleClick(object sender, EventArgs e)
        {
            // the function lets the user double click on desire cell data
            //and opens up new window in witch the user can update the borrow to date 
            UpdateBookToDate detailswin = new UpdateBookToDate(borrows);
            detailswin.textBox_studentBrMongoID.Text = dataGridView_Borrow.CurrentRow.Cells[0].Value.ToString();
            detailswin.textBox_BookCode.Text = dataGridView_Borrow.CurrentRow.Cells[1].Value.ToString();
            detailswin.textBox_BookName.Text = dataGridView_Borrow.CurrentRow.Cells[2].Value.ToString();
            detailswin.textBox_BookAuthor.Text = dataGridView_Borrow.CurrentRow.Cells[3].Value.ToString();
            detailswin.textBox_BookPublishYear.Text = dataGridView_Borrow.CurrentRow.Cells[4].Value.ToString();
            detailswin.textBox_bookBrMongoID.Text = dataGridView_Borrow.CurrentRow.Cells[5].Value.ToString();
            detailswin.textBox_StudentId.Text = dataGridView_Borrow.CurrentRow.Cells[6].Value.ToString();
            detailswin.textBox_StudentName.Text = dataGridView_Borrow.CurrentRow.Cells[7].Value.ToString();
            detailswin.textBox_StudentFaculty.Text = dataGridView_Borrow.CurrentRow.Cells[8].Value.ToString();
            detailswin.taxtBox_BorrowMongoID.Text = dataGridView_Borrow.CurrentRow.Cells[9].Value.ToString();
            detailswin.textBox_FromDate.Text = dataGridView_Borrow.CurrentRow.Cells[10].Value.ToString();
            detailswin.textBox_BookToDate.Text = dataGridView_Borrow.CurrentRow.Cells[11].Value.ToString();
            
            detailswin.ShowDialog();

            //after we are coming back from the update/delete win we need to refresh the screen 
            loadBorrowsFullDetails();
        }
        private void textBox_BorrowFilterStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_BorrowFilterStudentId_Click(object sender, EventArgs e)
        {
            var filterBuilder = Builders<Borrow>.Filter;
            var filter = filterBuilder.Empty;
            var filterBuilder1 = Builders<Student>.Filter;
            var filter1 = filterBuilder1.Empty;
            string StudentMongoId = "";
           
            try
            {
                if (!string.IsNullOrEmpty(textBox_BorrowFilterStudentID.Text))
                {
                    filter1 = filterBuilder1.Eq(student => student.StudentId, Convert.ToInt32(textBox_BorrowFilterStudentID.Text));
                }
                List<Student> StudentsResults = students.Find(filter1).ToList();
                foreach (Student br in StudentsResults)
                {
                    StudentMongoId = br.StudentMongoId;
                }
                //define the where criteria:
                if (!string.IsNullOrEmpty(StudentMongoId))
                {
                    filter = filterBuilder.Eq(borrow => borrow.StudentId, StudentMongoId);
                }

                
                //Get the result according to the filter

                List<Borrow> results = borrows.Find(filter).ToList();
                
                List<BorrowDetails> borrowWithFullDetails = new List<BorrowDetails>();
               

                foreach (Borrow br in results)
                {
                    BorrowDetails details = new BorrowDetails();
                    details.StudentMongoId = br.StudentId;
                    details.BookMongoId = br.BookId;
                    details.BorrowedMongoId = br.BorrowedMongoId;
                    details.FromDate = br.FromDate;
                    details.ToDate = br.ToDate;

                    string studentId = br.StudentId;
                    // Get the details of student:
                    FilterDefinition<Student> studentFilter = Builders<Student>.Filter.Eq(s => s.StudentMongoId, studentId);
                    List<Student> studentsList = students.Find(studentFilter).ToList();
                    details.StudentId = studentsList[0].StudentId;
                    details.StudentName = studentsList[0].StudentName;
                    details.StudentFaculty = studentsList[0].StudentFaculty;

                    string bookId = br.BookId;
                    FilterDefinition<Book> bookFilter = Builders<Book>.Filter.Eq(b => b.BookMongoId, bookId);
                    List<Book> booksList = books.Find(bookFilter).ToList();
                    details.BookCode = booksList[0].BookCode;
                    details.BookName = booksList[0].BookName;
                    details.BookAuthor = booksList[0].BookAuthor;
                    details.BookPublishYear = booksList[0].BookPublishYear;
                    borrowWithFullDetails.Add(details);
                }
                if (results.Count == 0 || filter == filterBuilder.Empty)
                {
                    MessageBox.Show("No matching records found", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (filter == filterBuilder.Empty)
                {
                    dataGridView_Borrow.DataSource = null;
                }
                else
                    //present thr result on the screen :
                    dataGridView_Borrow.DataSource = borrowWithFullDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem to make a filter with a student id \n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btn_RefreshListOfBorrows_Click(object sender, EventArgs e)
        {
            loadBorrowsFullDetails();
        }
        
    }
}
