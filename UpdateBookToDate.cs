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
using MongoDB.Driver;

namespace Finalproject
{
    public partial class UpdateBookToDate : Form
    {
        IMongoCollection<Borrow> borrowsCollection;
        public UpdateBookToDate(IMongoCollection<Borrow> borrows)
        {
            InitializeComponent();
            this.borrowsCollection = borrows;
        }

        private void textBox_BookToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != ':')
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits,slash or colon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_BookToDate.Clear();
        }

        private void btn_updateToDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_BookToDate.Text))
                {
                    MessageBox.Show("It is not possible to update the borrow's details without entering the borrow's to date\n",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else if ((Convert.ToDateTime(textBox_BookToDate.Text) <= Convert.ToDateTime(textBox_FromDate.Text))
                        || Convert.ToDateTime(textBox_BookToDate.Text) > DateTime.Now.Date.AddMonths(1))

                {
                    errorProvider_BookToDate.SetError(textBox_BookToDate,
                        "The range in which the book return date can be updated, is between the current" +
                        " date and up to one month from the current date");
                }
                else
                {

                    var filterBorrowID = Builders<Borrow>.Filter.Eq(borrow => borrow.BorrowedMongoId,
                                                                    taxtBox_BorrowMongoID.Text);

                    UpdateDefinition<Borrow> updateDefintion = Builders<Borrow>.Update
                        .Set(borrow => borrow.ToDate, textBox_BookToDate.Text);

                    borrowsCollection.UpdateOne(filterBorrowID, updateDefintion);
                    MessageBox.Show("Update succeeded, click Ok to close this window", "update",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

       
    }
}
