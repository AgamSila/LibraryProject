
namespace Finalproject
{
    partial class UpdateBookToDate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateBookToDate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_updateToDate = new System.Windows.Forms.Button();
            this.textBox_BookCode = new System.Windows.Forms.TextBox();
            this.textBox_StudentName = new System.Windows.Forms.TextBox();
            this.textBox_StudentFaculty = new System.Windows.Forms.TextBox();
            this.textBox_FromDate = new System.Windows.Forms.TextBox();
            this.textBox_BookToDate = new System.Windows.Forms.TextBox();
            this.textBox_StudentId = new System.Windows.Forms.TextBox();
            this.textBox_BookPublishYear = new System.Windows.Forms.TextBox();
            this.textBox_BookAuthor = new System.Windows.Forms.TextBox();
            this.textBox_BookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.taxtBox_BorrowMongoID = new System.Windows.Forms.TextBox();
            this.errorProvider_BookToDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBox_bookBrMongoID = new System.Windows.Forms.TextBox();
            this.textBox_studentBrMongoID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookToDate)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 484);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btn_updateToDate
            // 
            this.btn_updateToDate.BackColor = System.Drawing.Color.Snow;
            this.btn_updateToDate.Location = new System.Drawing.Point(114, 464);
            this.btn_updateToDate.Name = "btn_updateToDate";
            this.btn_updateToDate.Size = new System.Drawing.Size(107, 38);
            this.btn_updateToDate.TabIndex = 13;
            this.btn_updateToDate.Text = "update";
            this.btn_updateToDate.UseVisualStyleBackColor = false;
            this.btn_updateToDate.Click += new System.EventHandler(this.btn_updateToDate_Click);
            // 
            // textBox_BookCode
            // 
            this.textBox_BookCode.Location = new System.Drawing.Point(176, 40);
            this.textBox_BookCode.Name = "textBox_BookCode";
            this.textBox_BookCode.ReadOnly = true;
            this.textBox_BookCode.Size = new System.Drawing.Size(167, 22);
            this.textBox_BookCode.TabIndex = 14;
            // 
            // textBox_StudentName
            // 
            this.textBox_StudentName.Location = new System.Drawing.Point(176, 263);
            this.textBox_StudentName.Name = "textBox_StudentName";
            this.textBox_StudentName.ReadOnly = true;
            this.textBox_StudentName.Size = new System.Drawing.Size(167, 22);
            this.textBox_StudentName.TabIndex = 15;
            // 
            // textBox_StudentFaculty
            // 
            this.textBox_StudentFaculty.Location = new System.Drawing.Point(176, 301);
            this.textBox_StudentFaculty.Name = "textBox_StudentFaculty";
            this.textBox_StudentFaculty.ReadOnly = true;
            this.textBox_StudentFaculty.Size = new System.Drawing.Size(167, 22);
            this.textBox_StudentFaculty.TabIndex = 16;
            // 
            // textBox_FromDate
            // 
            this.textBox_FromDate.Location = new System.Drawing.Point(176, 344);
            this.textBox_FromDate.Name = "textBox_FromDate";
            this.textBox_FromDate.ReadOnly = true;
            this.textBox_FromDate.Size = new System.Drawing.Size(167, 22);
            this.textBox_FromDate.TabIndex = 17;
            // 
            // textBox_BookToDate
            // 
            this.textBox_BookToDate.Location = new System.Drawing.Point(176, 389);
            this.textBox_BookToDate.Name = "textBox_BookToDate";
            this.textBox_BookToDate.Size = new System.Drawing.Size(167, 22);
            this.textBox_BookToDate.TabIndex = 18;
            
            this.textBox_BookToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_BookToDate_KeyPress);
            // 
            // textBox_StudentId
            // 
            this.textBox_StudentId.Location = new System.Drawing.Point(176, 220);
            this.textBox_StudentId.Name = "textBox_StudentId";
            this.textBox_StudentId.ReadOnly = true;
            this.textBox_StudentId.Size = new System.Drawing.Size(167, 22);
            this.textBox_StudentId.TabIndex = 19;
            // 
            // textBox_BookPublishYear
            // 
            this.textBox_BookPublishYear.Location = new System.Drawing.Point(176, 175);
            this.textBox_BookPublishYear.Name = "textBox_BookPublishYear";
            this.textBox_BookPublishYear.ReadOnly = true;
            this.textBox_BookPublishYear.Size = new System.Drawing.Size(167, 22);
            this.textBox_BookPublishYear.TabIndex = 20;
            // 
            // textBox_BookAuthor
            // 
            this.textBox_BookAuthor.Location = new System.Drawing.Point(176, 128);
            this.textBox_BookAuthor.Name = "textBox_BookAuthor";
            this.textBox_BookAuthor.ReadOnly = true;
            this.textBox_BookAuthor.Size = new System.Drawing.Size(167, 22);
            this.textBox_BookAuthor.TabIndex = 21;
            // 
            // textBox_BookName
            // 
            this.textBox_BookName.Location = new System.Drawing.Point(176, 81);
            this.textBox_BookName.Name = "textBox_BookName";
            this.textBox_BookName.ReadOnly = true;
            this.textBox_BookName.Size = new System.Drawing.Size(167, 22);
            this.textBox_BookName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Book Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "From Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Student Faculty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Student Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Student Id:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(42, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Book Publish Year:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Book Author:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Book Name:";
            // 
            // taxtBox_BorrowMongoID
            // 
            this.taxtBox_BorrowMongoID.Location = new System.Drawing.Point(176, 436);
            this.taxtBox_BorrowMongoID.Name = "taxtBox_BorrowMongoID";
            this.taxtBox_BorrowMongoID.Size = new System.Drawing.Size(167, 22);
            this.taxtBox_BorrowMongoID.TabIndex = 32;
            this.taxtBox_BorrowMongoID.Visible = false;
            // 
            // errorProvider_BookToDate
            // 
            this.errorProvider_BookToDate.ContainerControl = this;
            // 
            // textBox_bookBrMongoID
            // 
            this.textBox_bookBrMongoID.Location = new System.Drawing.Point(176, 508);
            this.textBox_bookBrMongoID.Name = "textBox_bookBrMongoID";
            this.textBox_bookBrMongoID.Size = new System.Drawing.Size(167, 22);
            this.textBox_bookBrMongoID.TabIndex = 33;
            this.textBox_bookBrMongoID.Visible = false;
            // 
            // textBox_studentBrMongoID
            // 
            this.textBox_studentBrMongoID.Location = new System.Drawing.Point(176, 536);
            this.textBox_studentBrMongoID.Name = "textBox_studentBrMongoID";
            this.textBox_studentBrMongoID.Size = new System.Drawing.Size(167, 22);
            this.textBox_studentBrMongoID.TabIndex = 34;
            this.textBox_studentBrMongoID.Visible = false;
            // 
            // UpdateBookToDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(395, 556);
            this.Controls.Add(this.textBox_studentBrMongoID);
            this.Controls.Add(this.textBox_bookBrMongoID);
            this.Controls.Add(this.taxtBox_BorrowMongoID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_BookName);
            this.Controls.Add(this.textBox_BookAuthor);
            this.Controls.Add(this.textBox_BookPublishYear);
            this.Controls.Add(this.textBox_StudentId);
            this.Controls.Add(this.textBox_BookToDate);
            this.Controls.Add(this.textBox_FromDate);
            this.Controls.Add(this.textBox_StudentFaculty);
            this.Controls.Add(this.textBox_StudentName);
            this.Controls.Add(this.textBox_BookCode);
            this.Controls.Add(this.btn_updateToDate);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateBookToDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateBookToDate";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookToDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_updateToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox_BookToDate;
        private System.Windows.Forms.ErrorProvider errorProvider_BookToDate;
        public System.Windows.Forms.TextBox textBox_BookCode;
        public System.Windows.Forms.TextBox textBox_StudentName;
        public System.Windows.Forms.TextBox textBox_StudentFaculty;
        public System.Windows.Forms.TextBox textBox_FromDate;
        public System.Windows.Forms.TextBox textBox_StudentId;
        public System.Windows.Forms.TextBox textBox_BookPublishYear;
        public System.Windows.Forms.TextBox textBox_BookAuthor;
        public System.Windows.Forms.TextBox textBox_BookName;
        public System.Windows.Forms.TextBox taxtBox_BorrowMongoID;
        public System.Windows.Forms.TextBox textBox_studentBrMongoID;
        public System.Windows.Forms.TextBox textBox_bookBrMongoID;
    }
}