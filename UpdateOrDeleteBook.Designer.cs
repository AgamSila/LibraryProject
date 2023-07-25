
namespace Finalproject
{
    partial class UpdateOrDeleteBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateOrDeleteBook));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bookCode = new System.Windows.Forms.TextBox();
            this.textBox_bookName = new System.Windows.Forms.TextBox();
            this.textBox_bookPublishYear = new System.Windows.Forms.TextBox();
            this.textBox_bookAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_DeleteBook = new System.Windows.Forms.Button();
            this.btn_UpdateBook = new System.Windows.Forms.Button();
            this.textBox_bookId = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider_BookPublishYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_BookCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_BookStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookPublishYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book Name:";
            // 
            // textBox_bookCode
            // 
            this.textBox_bookCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_bookCode.Location = new System.Drawing.Point(255, 30);
            this.textBox_bookCode.Name = "textBox_bookCode";
            this.textBox_bookCode.Size = new System.Drawing.Size(156, 22);
            this.textBox_bookCode.TabIndex = 2;
            this.textBox_bookCode.TextChanged += new System.EventHandler(this.textBox_bookCode_TextChanged);
            this.textBox_bookCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_bookCode_KeyPress);
            // 
            // textBox_bookName
            // 
            this.textBox_bookName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_bookName.Location = new System.Drawing.Point(255, 85);
            this.textBox_bookName.Name = "textBox_bookName";
            this.textBox_bookName.Size = new System.Drawing.Size(156, 22);
            this.textBox_bookName.TabIndex = 3;
            this.textBox_bookName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_bookName_KeyPress);
            // 
            // textBox_bookPublishYear
            // 
            this.textBox_bookPublishYear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_bookPublishYear.Location = new System.Drawing.Point(255, 208);
            this.textBox_bookPublishYear.Name = "textBox_bookPublishYear";
            this.textBox_bookPublishYear.Size = new System.Drawing.Size(156, 22);
            this.textBox_bookPublishYear.TabIndex = 7;
            this.textBox_bookPublishYear.TextChanged += new System.EventHandler(this.textBox_bookPublishYear_TextChanged);
            this.textBox_bookPublishYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_bookPublishYear_KeyPress);
            // 
            // textBox_bookAuthor
            // 
            this.textBox_bookAuthor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_bookAuthor.Location = new System.Drawing.Point(255, 153);
            this.textBox_bookAuthor.Name = "textBox_bookAuthor";
            this.textBox_bookAuthor.Size = new System.Drawing.Size(156, 22);
            this.textBox_bookAuthor.TabIndex = 6;
            this.textBox_bookAuthor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_bookAuthor_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Book publish year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Book Author:";
            // 
            // btn_DeleteBook
            // 
            this.btn_DeleteBook.BackColor = System.Drawing.Color.Snow;
            this.btn_DeleteBook.Location = new System.Drawing.Point(255, 312);
            this.btn_DeleteBook.Name = "btn_DeleteBook";
            this.btn_DeleteBook.Size = new System.Drawing.Size(82, 35);
            this.btn_DeleteBook.TabIndex = 8;
            this.btn_DeleteBook.Text = "Delete";
            this.btn_DeleteBook.UseVisualStyleBackColor = false;
            this.btn_DeleteBook.Click += new System.EventHandler(this.btn_DeleteBook_Click);
            // 
            // btn_UpdateBook
            // 
            this.btn_UpdateBook.BackColor = System.Drawing.Color.Snow;
            this.btn_UpdateBook.Location = new System.Drawing.Point(112, 312);
            this.btn_UpdateBook.Name = "btn_UpdateBook";
            this.btn_UpdateBook.Size = new System.Drawing.Size(75, 35);
            this.btn_UpdateBook.TabIndex = 9;
            this.btn_UpdateBook.Text = "Update";
            this.btn_UpdateBook.UseVisualStyleBackColor = false;
            this.btn_UpdateBook.Click += new System.EventHandler(this.btn_UpdateBook_Click);
            // 
            // textBox_bookId
            // 
            this.textBox_bookId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_bookId.Location = new System.Drawing.Point(255, 377);
            this.textBox_bookId.Name = "textBox_bookId";
            this.textBox_bookId.Size = new System.Drawing.Size(119, 22);
            this.textBox_bookId.TabIndex = 10;
            this.textBox_bookId.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 348);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider_BookPublishYear
            // 
            this.errorProvider_BookPublishYear.ContainerControl = this;
            // 
            // errorProvider_BookCode
            // 
            this.errorProvider_BookCode.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Book Borrowed:";
            // 
            // textBox_BookStatus
            // 
            this.textBox_BookStatus.Location = new System.Drawing.Point(255, 264);
            this.textBox_BookStatus.Name = "textBox_BookStatus";
            this.textBox_BookStatus.ReadOnly = true;
            this.textBox_BookStatus.Size = new System.Drawing.Size(156, 22);
            this.textBox_BookStatus.TabIndex = 13;
            // 
            // UpdateOrDeleteBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 420);
            this.Controls.Add(this.textBox_BookStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_bookId);
            this.Controls.Add(this.btn_UpdateBook);
            this.Controls.Add(this.btn_DeleteBook);
            this.Controls.Add(this.textBox_bookPublishYear);
            this.Controls.Add(this.textBox_bookAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_bookName);
            this.Controls.Add(this.textBox_bookCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateOrDeleteBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateOrDeleteBook";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookPublishYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_BookCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_DeleteBook;
        private System.Windows.Forms.Button btn_UpdateBook;
        public System.Windows.Forms.TextBox textBox_bookCode;
        public System.Windows.Forms.TextBox textBox_bookName;
        public System.Windows.Forms.TextBox textBox_bookPublishYear;
        public System.Windows.Forms.TextBox textBox_bookAuthor;
        public System.Windows.Forms.TextBox textBox_bookId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider_BookPublishYear;
        private System.Windows.Forms.ErrorProvider errorProvider_BookCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox_BookStatus;
    }
}