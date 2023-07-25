using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject.Model;
namespace Finalproject
{
    public partial class UpdateOrDeleteBook : Form
    {
        IMongoCollection<Book> booksCollection;
       

        public UpdateOrDeleteBook(IMongoCollection<Book> books )
        {
            InitializeComponent();
            this.booksCollection = books;
        }
        //KeyPressed events
        private void textBox_bookCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_bookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter letters or digits only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_bookAuthor_KeyPress(object sender, KeyPressEventArgs e)
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
        }
        private void btn_UpdateBook_Click(object sender, EventArgs e)
        {
            if (textBox_BookStatus.Text == "true")
            {
                MessageBox.Show("It is not possible to update the book because it is borrowed ",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                if (string.IsNullOrEmpty(textBox_bookCode.Text))
                {
                    MessageBox.Show("It is not possible to update the book's details without entering the book's code\n",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookName.Text))
                {
                    MessageBox.Show("It is not possible to update the book's details without entering the book's name\n",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookAuthor.Text))
                {
                    MessageBox.Show("It is not possible to update the book's details without entering the book's author name\n",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_bookPublishYear.Text))
                {
                    MessageBox.Show("It is not possible to update the book's details without entering the book's publish year\n",
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
                    try
                    {
                        var filterBookID = Builders<Book>.Filter.Eq(book => book.BookCode,
                                                                            Convert.ToInt32(textBox_bookCode.Text));
                        List<Book> results = booksCollection.Find(filterBookID).ToList();
                        if (results.Count > 0)
                        {
                            errorProvider_BookCode.SetError(textBox_bookCode,
                                    "Please enter another book code,the code you enterded exists in the librery");
                        }
                        else
                        {
                            var filter = Builders<Book>.Filter.Eq(p => p.BookMongoId, textBox_bookId.Text);
                            UpdateDefinition<Book> updateDefintion = Builders<Book>.Update
                                .Set(p => p.BookCode, Convert.ToInt32(textBox_bookCode.Text))
                                .Set(p => p.BookName, textBox_bookName.Text)
                                .Set(p => p.BookAuthor, textBox_bookAuthor.Text)
                                .Set(p => p.BookPublishYear, Convert.ToInt32(textBox_bookPublishYear.Text));

                            booksCollection.UpdateOne(filter, updateDefintion);
                            MessageBox.Show("Update succeeded, click Ok to close this window", "update",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The Update failed ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
       

        private void btn_DeleteBook_Click(object sender, EventArgs e)
        {
            
            if(textBox_BookStatus.Text== "true")
                MessageBox.Show("It is not possible to delete the book because it is borrowed ",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var filter = Builders<Book>.Filter.Eq(p => p.BookMongoId, textBox_bookId.Text);

                DeleteResult res = booksCollection.DeleteOne(filter);

                if (res.DeletedCount == 1)
                    MessageBox.Show("Delete succeeded,click Ok to close this window", "Deletion of the book",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void textBox_bookPublishYear_TextChanged(object sender, EventArgs e)
        {
            errorProvider_BookPublishYear.Clear();
        }

        private void textBox_bookCode_TextChanged(object sender, EventArgs e)
        {
            errorProvider_BookCode.Clear();

        }
    }
}
