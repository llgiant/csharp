namespace app055_FormUI_SQLDataAccess
{
    partial class DashBoard
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.peopleFoundListBox = new System.Windows.Forms.ListBox();
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.firstNameInsLabel = new System.Windows.Forms.Label();
            this.firstNameInsText = new System.Windows.Forms.TextBox();
            this.lastNameInsLabel = new System.Windows.Forms.Label();
            this.lastNameInsText = new System.Windows.Forms.TextBox();
            this.secondNameInsLabel = new System.Windows.Forms.Label();
            this.secondNameInsText = new System.Windows.Forms.TextBox();
            this.genderInsLabel = new System.Windows.Forms.Label();
            this.genderInsText = new System.Windows.Forms.TextBox();
            this.phoneNumberInsLabel = new System.Windows.Forms.Label();
            this.phoneNumberInsText = new System.Windows.Forms.TextBox();
            this.insertRecordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // peopleFoundListBox
            // 
            this.peopleFoundListBox.FormattingEnabled = true;
            this.peopleFoundListBox.ItemHeight = 25;
            this.peopleFoundListBox.Location = new System.Drawing.Point(36, 87);
            this.peopleFoundListBox.Name = "peopleFoundListBox";
            this.peopleFoundListBox.Size = new System.Drawing.Size(602, 179);
            this.peopleFoundListBox.TabIndex = 0;
            // 
            // lastNameText
            // 
            this.lastNameText.Location = new System.Drawing.Point(167, 12);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(194, 31);
            this.lastNameText.TabIndex = 1;
            this.lastNameText.TextChanged += new System.EventHandler(this.lastNameText_TextChanged);
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Location = new System.Drawing.Point(31, 12);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(115, 25);
            this.lastName.TabIndex = 2;
            this.lastName.Text = "Last Name";
            this.lastName.Click += new System.EventHandler(this.label1_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(105, 49);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(101, 32);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // firstNameInsLabel
            // 
            this.firstNameInsLabel.AutoSize = true;
            this.firstNameInsLabel.Location = new System.Drawing.Point(31, 322);
            this.firstNameInsLabel.Name = "firstNameInsLabel";
            this.firstNameInsLabel.Size = new System.Drawing.Size(116, 25);
            this.firstNameInsLabel.TabIndex = 5;
            this.firstNameInsLabel.Text = "First Name";
            this.firstNameInsLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // firstNameInsText
            // 
            this.firstNameInsText.Location = new System.Drawing.Point(192, 319);
            this.firstNameInsText.Name = "firstNameInsText";
            this.firstNameInsText.Size = new System.Drawing.Size(249, 31);
            this.firstNameInsText.TabIndex = 4;
            // 
            // lastNameInsLabel
            // 
            this.lastNameInsLabel.AutoSize = true;
            this.lastNameInsLabel.Location = new System.Drawing.Point(32, 288);
            this.lastNameInsLabel.Name = "lastNameInsLabel";
            this.lastNameInsLabel.Size = new System.Drawing.Size(115, 25);
            this.lastNameInsLabel.TabIndex = 7;
            this.lastNameInsLabel.Text = "Last Name";
            // 
            // lastNameInsText
            // 
            this.lastNameInsText.Location = new System.Drawing.Point(192, 285);
            this.lastNameInsText.Name = "lastNameInsText";
            this.lastNameInsText.Size = new System.Drawing.Size(249, 31);
            this.lastNameInsText.TabIndex = 6;
            // 
            // secondNameInsLabel
            // 
            this.secondNameInsLabel.AutoSize = true;
            this.secondNameInsLabel.Location = new System.Drawing.Point(30, 356);
            this.secondNameInsLabel.Name = "secondNameInsLabel";
            this.secondNameInsLabel.Size = new System.Drawing.Size(147, 25);
            this.secondNameInsLabel.TabIndex = 9;
            this.secondNameInsLabel.Text = "Second Name";
            // 
            // secondNameInsText
            // 
            this.secondNameInsText.Location = new System.Drawing.Point(192, 353);
            this.secondNameInsText.Name = "secondNameInsText";
            this.secondNameInsText.Size = new System.Drawing.Size(249, 31);
            this.secondNameInsText.TabIndex = 8;
            // 
            // genderInsLabel
            // 
            this.genderInsLabel.AutoSize = true;
            this.genderInsLabel.Location = new System.Drawing.Point(32, 390);
            this.genderInsLabel.Name = "genderInsLabel";
            this.genderInsLabel.Size = new System.Drawing.Size(83, 25);
            this.genderInsLabel.TabIndex = 11;
            this.genderInsLabel.Text = "Gender";
            this.genderInsLabel.Click += new System.EventHandler(this.phoneNumberInsLabel_Click);
            // 
            // genderInsText
            // 
            this.genderInsText.Location = new System.Drawing.Point(192, 387);
            this.genderInsText.Name = "genderInsText";
            this.genderInsText.Size = new System.Drawing.Size(249, 31);
            this.genderInsText.TabIndex = 10;
            // 
            // phoneNumberInsLabel
            // 
            this.phoneNumberInsLabel.AutoSize = true;
            this.phoneNumberInsLabel.Location = new System.Drawing.Point(32, 425);
            this.phoneNumberInsLabel.Name = "phoneNumberInsLabel";
            this.phoneNumberInsLabel.Size = new System.Drawing.Size(155, 25);
            this.phoneNumberInsLabel.TabIndex = 13;
            this.phoneNumberInsLabel.Text = "Phone Number";
            // 
            // phoneNumberInsText
            // 
            this.phoneNumberInsText.Location = new System.Drawing.Point(192, 422);
            this.phoneNumberInsText.Name = "phoneNumberInsText";
            this.phoneNumberInsText.Size = new System.Drawing.Size(249, 31);
            this.phoneNumberInsText.TabIndex = 12;
            this.phoneNumberInsText.TextChanged += new System.EventHandler(this.phoneNumberInsText_TextChanged);
            // 
            // insertRecordButton
            // 
            this.insertRecordButton.Location = new System.Drawing.Point(166, 480);
            this.insertRecordButton.Name = "insertRecordButton";
            this.insertRecordButton.Size = new System.Drawing.Size(101, 32);
            this.insertRecordButton.TabIndex = 14;
            this.insertRecordButton.Text = "Insert";
            this.insertRecordButton.UseVisualStyleBackColor = true;
            this.insertRecordButton.Click += new System.EventHandler(this.insertRecordButton_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 550);
            this.Controls.Add(this.insertRecordButton);
            this.Controls.Add(this.phoneNumberInsLabel);
            this.Controls.Add(this.phoneNumberInsText);
            this.Controls.Add(this.genderInsLabel);
            this.Controls.Add(this.genderInsText);
            this.Controls.Add(this.secondNameInsLabel);
            this.Controls.Add(this.secondNameInsText);
            this.Controls.Add(this.lastNameInsLabel);
            this.Controls.Add(this.lastNameInsText);
            this.Controls.Add(this.firstNameInsLabel);
            this.Controls.Add(this.firstNameInsText);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.lastNameText);
            this.Controls.Add(this.peopleFoundListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DashBoard";
            this.Text = "SQL Data Access";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox peopleFoundListBox;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label firstNameInsLabel;
        private System.Windows.Forms.TextBox firstNameInsText;
        private System.Windows.Forms.Label lastNameInsLabel;
        private System.Windows.Forms.TextBox lastNameInsText;
        private System.Windows.Forms.Label secondNameInsLabel;
        private System.Windows.Forms.TextBox secondNameInsText;
        private System.Windows.Forms.Label genderInsLabel;
        private System.Windows.Forms.TextBox genderInsText;
        private System.Windows.Forms.Label phoneNumberInsLabel;
        private System.Windows.Forms.TextBox phoneNumberInsText;
        private System.Windows.Forms.Button insertRecordButton;
    }
}

