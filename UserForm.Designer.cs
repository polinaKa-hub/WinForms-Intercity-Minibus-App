namespace WindowsFormsApp2
{
    partial class UserForm
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
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxFromWhere = new System.Windows.Forms.TextBox();
            this.textBoxToWhere = new System.Windows.Forms.TextBox();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tydasuda = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReservedSeats = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPicker
            // 
            this.dtPicker.CalendarFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtPicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtPicker.Location = new System.Drawing.Point(64, 236);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(270, 22);
            this.dtPicker.TabIndex = 1;
            // 
            // textBoxFromWhere
            // 
            this.textBoxFromWhere.Location = new System.Drawing.Point(66, 121);
            this.textBoxFromWhere.Multiline = true;
            this.textBoxFromWhere.Name = "textBoxFromWhere";
            this.textBoxFromWhere.Size = new System.Drawing.Size(100, 25);
            this.textBoxFromWhere.TabIndex = 2;
            // 
            // textBoxToWhere
            // 
            this.textBoxToWhere.BackColor = System.Drawing.Color.White;
            this.textBoxToWhere.Location = new System.Drawing.Point(66, 199);
            this.textBoxToWhere.Multiline = true;
            this.textBoxToWhere.Name = "textBoxToWhere";
            this.textBoxToWhere.Size = new System.Drawing.Size(100, 25);
            this.textBoxToWhere.TabIndex = 3;
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(294, 124);
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(40, 22);
            this.numUpDown.TabIndex = 4;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonFind.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFind.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.Location = new System.Drawing.Point(158, 282);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 30);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(52, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Откуда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(52, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Куда";
            // 
            // tydasuda
            // 
            this.tydasuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tydasuda.Location = new System.Drawing.Point(158, 152);
            this.tydasuda.Name = "tydasuda";
            this.tydasuda.Size = new System.Drawing.Size(39, 37);
            this.tydasuda.TabIndex = 8;
            this.tydasuda.Text = "⇵";
            this.tydasuda.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tydasuda.UseVisualStyleBackColor = true;
            this.tydasuda.Click += new System.EventHandler(this.tydasuda_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(214, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Количество мест";
            // 
            // btnReservedSeats
            // 
            this.btnReservedSeats.BackColor = System.Drawing.Color.Gray;
            this.btnReservedSeats.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReservedSeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservedSeats.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReservedSeats.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnReservedSeats.Location = new System.Drawing.Point(139, 389);
            this.btnReservedSeats.Name = "btnReservedSeats";
            this.btnReservedSeats.Size = new System.Drawing.Size(121, 35);
            this.btnReservedSeats.TabIndex = 10;
            this.btnReservedSeats.Text = "Мои заказы";
            this.btnReservedSeats.UseVisualStyleBackColor = false;
            this.btnReservedSeats.Click += new System.EventHandler(this.btnReservedSeats_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(238, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Имя Фамилия";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(312, 31);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(68, 29);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label5.Location = new System.Drawing.Point(218, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 38);
            this.label5.TabIndex = 13;
            this.label5.Text = "Сумма поездки: \r\n      23 BYN";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.sprinter_fotor_2__1___3_;
            this.ClientSize = new System.Drawing.Size(392, 436);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReservedSeats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tydasuda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.textBoxToWhere);
            this.Controls.Add(this.textBoxFromWhere);
            this.Controls.Add(this.dtPicker);
            this.Name = "UserForm";
            this.Text = "Поиск маршрута";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPicker;
        private System.Windows.Forms.TextBox textBoxToWhere;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tydasuda;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxFromWhere;
        private System.Windows.Forms.Button btnReservedSeats;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label5;
    }
}