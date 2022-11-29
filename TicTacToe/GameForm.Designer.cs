namespace TicTacToe
{
    partial class GameForm
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
            this.g1_btn = new System.Windows.Forms.Button();
            this.g2_btn = new System.Windows.Forms.Button();
            this.g3_btn = new System.Windows.Forms.Button();
            this.g4_btn = new System.Windows.Forms.Button();
            this.g5_btn = new System.Windows.Forms.Button();
            this.g6_btn = new System.Windows.Forms.Button();
            this.g7_btn = new System.Windows.Forms.Button();
            this.g8_btn = new System.Windows.Forms.Button();
            this.g9_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // g1_btn
            // 
            this.g1_btn.Location = new System.Drawing.Point(161, 95);
            this.g1_btn.Name = "g1_btn";
            this.g1_btn.Size = new System.Drawing.Size(80, 80);
            this.g1_btn.TabIndex = 0;
            this.g1_btn.UseVisualStyleBackColor = true;
            this.g1_btn.Click += new System.EventHandler(this.g1_btn_Click);
            // 
            // g2_btn
            // 
            this.g2_btn.Location = new System.Drawing.Point(247, 95);
            this.g2_btn.Name = "g2_btn";
            this.g2_btn.Size = new System.Drawing.Size(80, 80);
            this.g2_btn.TabIndex = 1;
            this.g2_btn.UseVisualStyleBackColor = true;
            this.g2_btn.Click += new System.EventHandler(this.g2_btn_Click);
            // 
            // g3_btn
            // 
            this.g3_btn.Location = new System.Drawing.Point(333, 95);
            this.g3_btn.Name = "g3_btn";
            this.g3_btn.Size = new System.Drawing.Size(80, 80);
            this.g3_btn.TabIndex = 2;
            this.g3_btn.UseVisualStyleBackColor = true;
            this.g3_btn.Click += new System.EventHandler(this.g3_btn_Click);
            // 
            // g4_btn
            // 
            this.g4_btn.Location = new System.Drawing.Point(161, 181);
            this.g4_btn.Name = "g4_btn";
            this.g4_btn.Size = new System.Drawing.Size(80, 80);
            this.g4_btn.TabIndex = 3;
            this.g4_btn.UseVisualStyleBackColor = true;
            this.g4_btn.Click += new System.EventHandler(this.g4_btn_Click);
            // 
            // g5_btn
            // 
            this.g5_btn.Location = new System.Drawing.Point(247, 181);
            this.g5_btn.Name = "g5_btn";
            this.g5_btn.Size = new System.Drawing.Size(80, 80);
            this.g5_btn.TabIndex = 4;
            this.g5_btn.UseVisualStyleBackColor = true;
            this.g5_btn.Click += new System.EventHandler(this.g5_btn_Click);
            // 
            // g6_btn
            // 
            this.g6_btn.Location = new System.Drawing.Point(333, 181);
            this.g6_btn.Name = "g6_btn";
            this.g6_btn.Size = new System.Drawing.Size(80, 80);
            this.g6_btn.TabIndex = 5;
            this.g6_btn.UseVisualStyleBackColor = true;
            this.g6_btn.Click += new System.EventHandler(this.g6_btn_Click);
            // 
            // g7_btn
            // 
            this.g7_btn.Location = new System.Drawing.Point(161, 267);
            this.g7_btn.Name = "g7_btn";
            this.g7_btn.Size = new System.Drawing.Size(80, 80);
            this.g7_btn.TabIndex = 6;
            this.g7_btn.UseVisualStyleBackColor = true;
            this.g7_btn.Click += new System.EventHandler(this.g7_btn_Click);
            // 
            // g8_btn
            // 
            this.g8_btn.Location = new System.Drawing.Point(247, 267);
            this.g8_btn.Name = "g8_btn";
            this.g8_btn.Size = new System.Drawing.Size(80, 80);
            this.g8_btn.TabIndex = 7;
            this.g8_btn.UseVisualStyleBackColor = true;
            this.g8_btn.Click += new System.EventHandler(this.g8_btn_Click);
            // 
            // g9_btn
            // 
            this.g9_btn.Location = new System.Drawing.Point(333, 267);
            this.g9_btn.Name = "g9_btn";
            this.g9_btn.Size = new System.Drawing.Size(80, 80);
            this.g9_btn.TabIndex = 8;
            this.g9_btn.UseVisualStyleBackColor = true;
            this.g9_btn.Click += new System.EventHandler(this.g9_btn_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.g9_btn);
            this.Controls.Add(this.g8_btn);
            this.Controls.Add(this.g7_btn);
            this.Controls.Add(this.g6_btn);
            this.Controls.Add(this.g5_btn);
            this.Controls.Add(this.g4_btn);
            this.Controls.Add(this.g3_btn);
            this.Controls.Add(this.g2_btn);
            this.Controls.Add(this.g1_btn);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button g1_btn;
        private System.Windows.Forms.Button g2_btn;
        private System.Windows.Forms.Button g3_btn;
        private System.Windows.Forms.Button g4_btn;
        private System.Windows.Forms.Button g5_btn;
        private System.Windows.Forms.Button g6_btn;
        private System.Windows.Forms.Button g7_btn;
        private System.Windows.Forms.Button g8_btn;
        private System.Windows.Forms.Button g9_btn;
    }
}