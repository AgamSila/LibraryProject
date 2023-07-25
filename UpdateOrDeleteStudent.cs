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
    public partial class UpdateOrDeleteStudent : Form
    {
        IMongoCollection<Student> studentsCollection;
        IMongoCollection<Borrow> borrowsCollection;
        public UpdateOrDeleteStudent(IMongoCollection<Student> students, IMongoCollection<Borrow> borrows)
        {
            InitializeComponent();
            this.studentsCollection = students;
            this.borrowsCollection = borrows;
        }

        private void btn_UpdateStudent_Click(object sender, EventArgs e)
        {
            
            string id = textBox_mongoId.Text;
            string studentFaculty = comboBox_student_faculty.SelectedItem.ToString();
            var filterStudentId = Builders<Borrow>.Filter.Eq(borrow => borrow.StudentId,id);
            List<Borrow> res = borrowsCollection.Find(filterStudentId).ToList();
            if (res.Count > 0)
            {
                MessageBox.Show("The student's information cannot be updated because he borrowed a book\n",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                if (studentFaculty.Equals("Select Faculty"))
                {
                    errorProvider_studentFaculty.SetError(comboBox_student_faculty, "Please Select Some Faculty");

                }

                else if (string.IsNullOrEmpty(textBox_studentName.Text))
                {
                    MessageBox.Show("It is not possible to update the student's details without entering the student's name\n",
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(textBox_StudentId.Text))
                {
                    MessageBox.Show("It is not possible to update the student's details without entering the student's id\n",
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var filterStudentID = Builders<Student>.Filter.Eq(student => student.StudentId,
                                                                            Convert.ToInt32(textBox_StudentId.Text));
                        List<Student> results = studentsCollection.Find(filterStudentID).ToList();
                        if (results.Count > 0)
                        {
                            errorProvider_StudentId.SetError(textBox_StudentId,
                                 "Please enter another id,the id you enterded exists in the library");
                        }

                        else
                        {
                            var filter = Builders<Student>.Filter.Eq(p => p.StudentMongoId, id);

                            UpdateDefinition<Student> updateDefintion = Builders<Student>.Update.Set(p => p.StudentId,
                                                                            Convert.ToInt32(textBox_StudentId.Text))
                                                                            .Set(p => p.StudentName, textBox_studentName.Text)
                                                                            .Set(p => p.StudentFaculty,
                                                                            comboBox_student_faculty.SelectedItem.ToString());
                            this.Close();
                            studentsCollection.UpdateOne(filter, updateDefintion);
                            MessageBox.Show("Update succeeded,Click Ok to close this window", "Update Student",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The Update failed :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_DeleteStudent_Click(object sender, EventArgs e)
        {
            string id = textBox_mongoId.Text;

            var filterStudentId = Builders<Borrow>.Filter.Eq(borrow => borrow.StudentId,id);
            List<Borrow> result = borrowsCollection.Find(filterStudentId).ToList();
            if (result.Count > 0)
            {
                MessageBox.Show("The student cannot be deleted because he borrows a book\n",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                try
                {
                    var filter = Builders<Student>.Filter.Eq(p => p.StudentMongoId, textBox_mongoId.Text);

                    DeleteResult res = studentsCollection.DeleteOne(filter);

                    if (res.DeletedCount == 1)
                        MessageBox.Show("Delete succeeded,Click Ok to close this window", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("The Delete failed :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
        //Student keyPressed events
        private void textBox_StudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            errorProvider_StudentId.Clear();
        }

        private void textBox_studentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_student_faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider_studentFaculty.Clear();

        }
    }
}
