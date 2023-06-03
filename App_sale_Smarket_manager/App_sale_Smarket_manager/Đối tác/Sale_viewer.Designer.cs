
namespace App_sale_manager
{
    partial class Sale_viewer
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
            this.button_quit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_NOR_end = new System.Windows.Forms.Label();
            this.listBox_NOR_ended = new System.Windows.Forms.ListBox();
            this.label_NOR_waiting = new System.Windows.Forms.Label();
            this.listBox_NOR_waiting = new System.Windows.Forms.ListBox();
            this.label_NOR_ongoing = new System.Windows.Forms.Label();
            this.listBox_NOR_ongoing = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_VIP_ongoing = new System.Windows.Forms.ListBox();
            this.listBox_VIP_ended = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_VIP_waiting = new System.Windows.Forms.ListBox();
            this.button_saleDelete = new System.Windows.Forms.Button();
            this.dataGridView_sale = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sale)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_quit
            // 
            this.button_quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button_quit.FlatAppearance.BorderSize = 0;
            this.button_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quit.ForeColor = System.Drawing.Color.White;
            this.button_quit.Location = new System.Drawing.Point(758, 565);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(145, 33);
            this.button_quit.TabIndex = 4;
            this.button_quit.Text = "Thoát";
            this.button_quit.UseVisualStyleBackColor = false;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(652, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thêm ưu đãi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_NOR_end
            // 
            this.label_NOR_end.AutoSize = true;
            this.label_NOR_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_NOR_end.ForeColor = System.Drawing.Color.White;
            this.label_NOR_end.Location = new System.Drawing.Point(14, 6);
            this.label_NOR_end.Name = "label_NOR_end";
            this.label_NOR_end.Size = new System.Drawing.Size(127, 17);
            this.label_NOR_end.TabIndex = 6;
            this.label_NOR_end.Text = "Ưu đãi đã kết thúc:";
            // 
            // listBox_NOR_ended
            // 
            this.listBox_NOR_ended.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_NOR_ended.FormattingEnabled = true;
            this.listBox_NOR_ended.ItemHeight = 16;
            this.listBox_NOR_ended.Location = new System.Drawing.Point(21, 364);
            this.listBox_NOR_ended.Name = "listBox_NOR_ended";
            this.listBox_NOR_ended.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_NOR_ended.Size = new System.Drawing.Size(398, 68);
            this.listBox_NOR_ended.TabIndex = 5;
            this.listBox_NOR_ended.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_NOR_ended_MouseClick);
            this.listBox_NOR_ended.DoubleClick += new System.EventHandler(this.listBox_NOR_ended_DoubleClick);
            this.listBox_NOR_ended.Leave += new System.EventHandler(this.listBox_NOR_ended_Leave);
            // 
            // label_NOR_waiting
            // 
            this.label_NOR_waiting.AutoSize = true;
            this.label_NOR_waiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_NOR_waiting.ForeColor = System.Drawing.Color.White;
            this.label_NOR_waiting.Location = new System.Drawing.Point(14, 6);
            this.label_NOR_waiting.Name = "label_NOR_waiting";
            this.label_NOR_waiting.Size = new System.Drawing.Size(99, 17);
            this.label_NOR_waiting.TabIndex = 4;
            this.label_NOR_waiting.Text = "Ưu đãi sắp tới:";
            // 
            // listBox_NOR_waiting
            // 
            this.listBox_NOR_waiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_NOR_waiting.FormattingEnabled = true;
            this.listBox_NOR_waiting.ItemHeight = 16;
            this.listBox_NOR_waiting.Location = new System.Drawing.Point(21, 213);
            this.listBox_NOR_waiting.Name = "listBox_NOR_waiting";
            this.listBox_NOR_waiting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_NOR_waiting.Size = new System.Drawing.Size(398, 68);
            this.listBox_NOR_waiting.TabIndex = 3;
            this.listBox_NOR_waiting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_NOR_waiting_MouseClick);
            this.listBox_NOR_waiting.DoubleClick += new System.EventHandler(this.listBox_NOR_waiting_DoubleClick);
            this.listBox_NOR_waiting.Leave += new System.EventHandler(this.listBox_NOR_waiting_Leave);
            // 
            // label_NOR_ongoing
            // 
            this.label_NOR_ongoing.AutoSize = true;
            this.label_NOR_ongoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_NOR_ongoing.ForeColor = System.Drawing.Color.White;
            this.label_NOR_ongoing.Location = new System.Drawing.Point(14, 6);
            this.label_NOR_ongoing.Name = "label_NOR_ongoing";
            this.label_NOR_ongoing.Size = new System.Drawing.Size(145, 17);
            this.label_NOR_ongoing.TabIndex = 2;
            this.label_NOR_ongoing.Text = "Ưu đãi đang áp dụng:";
            // 
            // listBox_NOR_ongoing
            // 
            this.listBox_NOR_ongoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_NOR_ongoing.FormattingEnabled = true;
            this.listBox_NOR_ongoing.ItemHeight = 16;
            this.listBox_NOR_ongoing.Location = new System.Drawing.Point(21, 57);
            this.listBox_NOR_ongoing.Name = "listBox_NOR_ongoing";
            this.listBox_NOR_ongoing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_NOR_ongoing.Size = new System.Drawing.Size(398, 68);
            this.listBox_NOR_ongoing.TabIndex = 1;
            this.listBox_NOR_ongoing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_NOR_ongoing_MouseClick);
            this.listBox_NOR_ongoing.DoubleClick += new System.EventHandler(this.listBox_NOR_ongoing_DoubleClick);
            this.listBox_NOR_ongoing.Leave += new System.EventHandler(this.listBox_NOR_ongoing_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ưu đãi đã kết thúc:";
            // 
            // listBox_VIP_ongoing
            // 
            this.listBox_VIP_ongoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_VIP_ongoing.FormattingEnabled = true;
            this.listBox_VIP_ongoing.ItemHeight = 16;
            this.listBox_VIP_ongoing.Location = new System.Drawing.Point(20, 57);
            this.listBox_VIP_ongoing.Name = "listBox_VIP_ongoing";
            this.listBox_VIP_ongoing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_VIP_ongoing.Size = new System.Drawing.Size(398, 68);
            this.listBox_VIP_ongoing.TabIndex = 7;
            this.listBox_VIP_ongoing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_VIP_ongoing_MouseClick);
            this.listBox_VIP_ongoing.DoubleClick += new System.EventHandler(this.listBox_VIP_ongoing_DoubleClick);
            this.listBox_VIP_ongoing.Leave += new System.EventHandler(this.listBox_NOR_waiting_Leave);
            // 
            // listBox_VIP_ended
            // 
            this.listBox_VIP_ended.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_VIP_ended.FormattingEnabled = true;
            this.listBox_VIP_ended.ItemHeight = 16;
            this.listBox_VIP_ended.Location = new System.Drawing.Point(20, 364);
            this.listBox_VIP_ended.Name = "listBox_VIP_ended";
            this.listBox_VIP_ended.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_VIP_ended.Size = new System.Drawing.Size(398, 68);
            this.listBox_VIP_ended.TabIndex = 11;
            this.listBox_VIP_ended.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_VIP_ended_MouseClick);
            this.listBox_VIP_ended.DoubleClick += new System.EventHandler(this.listBox_VIP_ended_DoubleClick);
            this.listBox_VIP_ended.Leave += new System.EventHandler(this.listBox_VIP_ended_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ưu đãi đang áp dụng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ưu đãi sắp tới:";
            // 
            // listBox_VIP_waiting
            // 
            this.listBox_VIP_waiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_VIP_waiting.FormattingEnabled = true;
            this.listBox_VIP_waiting.ItemHeight = 16;
            this.listBox_VIP_waiting.Location = new System.Drawing.Point(20, 213);
            this.listBox_VIP_waiting.Name = "listBox_VIP_waiting";
            this.listBox_VIP_waiting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_VIP_waiting.Size = new System.Drawing.Size(398, 68);
            this.listBox_VIP_waiting.TabIndex = 9;
            this.listBox_VIP_waiting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_VIP_waiting_MouseClick);
            this.listBox_VIP_waiting.DoubleClick += new System.EventHandler(this.listBox_VIP_waiting_DoubleClick);
            this.listBox_VIP_waiting.Leave += new System.EventHandler(this.listBox_VIP_waiting_Leave);
            // 
            // button_saleDelete
            // 
            this.button_saleDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(156)))), ((int)(((byte)(85)))));
            this.button_saleDelete.FlatAppearance.BorderSize = 0;
            this.button_saleDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_saleDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_saleDelete.ForeColor = System.Drawing.Color.White;
            this.button_saleDelete.Location = new System.Drawing.Point(792, 11);
            this.button_saleDelete.Name = "button_saleDelete";
            this.button_saleDelete.Size = new System.Drawing.Size(110, 29);
            this.button_saleDelete.TabIndex = 8;
            this.button_saleDelete.Text = "Xóa ưu đãi";
            this.button_saleDelete.UseVisualStyleBackColor = false;
            this.button_saleDelete.Click += new System.EventHandler(this.button_saleDelete_Click);
            // 
            // dataGridView_sale
            // 
            this.dataGridView_sale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_sale.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_sale.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_sale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_sale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sale.Location = new System.Drawing.Point(1, 615);
            this.dataGridView_sale.Name = "dataGridView_sale";
            this.dataGridView_sale.ReadOnly = true;
            this.dataGridView_sale.RowHeadersWidth = 51;
            this.dataGridView_sale.Size = new System.Drawing.Size(15, 20);
            this.dataGridView_sale.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listBox_NOR_ended);
            this.panel1.Controls.Add(this.listBox_NOR_ongoing);
            this.panel1.Controls.Add(this.listBox_NOR_waiting);
            this.panel1.Location = new System.Drawing.Point(9, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 514);
            this.panel1.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.label_NOR_end);
            this.panel5.Location = new System.Drawing.Point(4, 332);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(195, 27);
            this.panel5.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.label_NOR_waiting);
            this.panel4.Location = new System.Drawing.Point(4, 184);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(195, 27);
            this.panel4.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label_NOR_ongoing);
            this.panel3.Location = new System.Drawing.Point(4, 28);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 27);
            this.panel3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(2, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "KHÁCH HÀNG THƯỜNG";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.listBox_VIP_ongoing);
            this.panel2.Controls.Add(this.listBox_VIP_waiting);
            this.panel2.Controls.Add(this.listBox_VIP_ended);
            this.panel2.Location = new System.Drawing.Point(459, 46);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 514);
            this.panel2.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.label1);
            this.panel8.Location = new System.Drawing.Point(4, 332);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(195, 27);
            this.panel8.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(4, 184);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(195, 27);
            this.panel7.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(4, 28);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(195, 27);
            this.panel6.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(2, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "KHÁCH HÀNG VIP";
            // 
            // Sale_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(912, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_sale);
            this.Controls.Add(this.button_saleDelete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_quit);
            this.Name = "Sale_viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách ưu đãi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sale)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_NOR_ongoing;
        private System.Windows.Forms.ListBox listBox_NOR_ongoing;
        private System.Windows.Forms.Label label_NOR_end;
        private System.Windows.Forms.ListBox listBox_NOR_ended;
        private System.Windows.Forms.Label label_NOR_waiting;
        private System.Windows.Forms.ListBox listBox_NOR_waiting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_VIP_ongoing;
        private System.Windows.Forms.ListBox listBox_VIP_ended;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_VIP_waiting;
        private System.Windows.Forms.Button button_saleDelete;
        private System.Windows.Forms.DataGridView dataGridView_sale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
    }
}