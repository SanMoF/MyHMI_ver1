namespace MyHMI_ver1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(23, 25);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(146, 26);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(41, 94);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(710, 139);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(41, 275);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(157, 120);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "RT2";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(348, 275);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(157, 120);
            richTextBox3.TabIndex = 4;
            richTextBox3.Text = "RT3";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(594, 275);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(157, 120);
            richTextBox4.TabIndex = 5;
            richTextBox4.Text = "RT4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 252);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 6;
            label1.Text = "Temperature";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(388, 252);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Pressure";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(648, 252);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 8;
            label3.Text = "Flow";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
