
namespace Finalproject
{
    partial class UpdateOrDeleteStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateOrDeleteStudent));
            this.btn_UpdateStudent = new System.Windows.Forms.Button();
            this.btn_DeleteStudent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_studentName = new System.Windows.Forms.TextBox();
            this.textBox_StudentId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_mongoId = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox_student_faculty = new System.Windows.Forms.ComboBox();
            this.errorProvider_studentFaculty = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_StudentId = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_studentFaculty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_StudentId)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_UpdateStudent
            // 
            this.btn_UpdateStudent.BackColor = System.Drawing.Color.Snow;
            this.btn_UpdateStudent.Location = new System.Drawing.Point(90, 251);
            this.btn_UpdateStudent.Name = "btn_UpdateStudent";
            this.btn_UpdateStudent.Size = new System.Drawing.Size(75, 35);
            this.btn_UpdateStudent.TabIndex = 19;
            this.btn_UpdateStudent.Text = "Update";
            this.btn_UpdateStudent.UseVisualStyleBackColor = false;
            this.btn_UpdateStudent.Click += new System.EventHandler(this.btn_UpdateStudent_Click);
            // 
            // btn_DeleteStudent
            // 
            this.btn_DeleteStudent.BackColor = System.Drawing.Color.Snow;
            this.btn_DeleteStudent.Location = new System.Drawing.Point(280, 251);
            this.btn_DeleteStudent.Name = "btn_DeleteStudent";
            this.btn_DeleteStudent.Size = new System.Drawing.Size(86, 35);
            this.btn_DeleteStudent.TabIndex = 18;
            this.btn_DeleteStudent.Text = "Delete";
            this.btn_DeleteStudent.UseVisualStyleBackColor = false;
            this.btn_DeleteStudent.Click += new System.EventHandler(this.btn_DeleteStudent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Student Faculty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 14;
            // 
            // textBox_studentName
            // 
            this.textBox_studentName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_studentName.Location = new System.Drawing.Point(247, 90);
            this.textBox_studentName.Name = "textBox_studentName";
            this.textBox_studentName.Size = new System.Drawing.Size(188, 22);
            this.textBox_studentName.TabIndex = 13;
            this.textBox_studentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_studentName_KeyPress);
            // 
            // textBox_StudentId
            // 
            this.textBox_StudentId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_StudentId.Location = new System.Drawing.Point(247, 35);
            this.textBox_StudentId.Name = "textBox_StudentId";
            this.textBox_StudentId.Size = new System.Drawing.Size(188, 22);
            this.textBox_StudentId.TabIndex = 12;
            this.textBox_StudentId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_StudentId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Student Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Student id";
            // 
            // textBox_mongoId
            // 
            this.textBox_mongoId.Location = new System.Drawing.Point(247, 339);
            this.textBox_mongoId.Name = "textBox_mongoId";
            this.textBox_mongoId.Size = new System.Drawing.Size(72, 22);
            this.textBox_mongoId.TabIndex = 20;
            this.textBox_mongoId.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox_student_faculty
            // 
            this.comboBox_student_faculty.BackColor = System.Drawing.Color.Snow;
            this.comboBox_student_faculty.FormattingEnabled = true;
            this.comboBox_student_faculty.Location = new System.Drawing.Point(245, 158);
            this.comboBox_student_faculty.Name = "comboBox_student_faculty";
            this.comboBox_student_faculty.Size = new System.Drawing.Size(190, 24);
            this.comboBox_student_faculty.TabIndex = 22;
            this.comboBox_student_faculty.SelectedIndexChanged += new System.EventHandler(this.comboBox_student_faculty_SelectedIndexChanged);
            // 
            // errorProvider_studentFaculty
            // 
            this.errorProvider_studentFaculty.ContainerControl = this;
            // 
            // errorProvider_StudentId
            // 
            this.errorProvider_StudentId.ContainerControl = this;
            // 
            // UpdateOrDeleteStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(490, 432);
            this.Controls.Add(this.comboBox_student_faculty);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_mongoId);
            this.Controls.Add(this.btn_UpdateStudent);
            this.Controls.Add(this.btn_DeleteStudent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_studentName);
            this.Controls.Add(this.textBox_StudentId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateOrDeleteStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateOrDeleteStudent";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_studentFaculty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_StudentId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_UpdateStudent;
        private System.Windows.Forms.Button btn_DeleteStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_studentName;
        public System.Windows.Forms.TextBox textBox_StudentId;
        public System.Windows.Forms.TextBox textBox_mongoId;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox comboBox_student_faculty;
        private System.Windows.Forms.ErrorProvider errorProvider_studentFaculty;
        private System.Windows.Forms.ErrorProvider errorProvider_StudentId;
    }
}