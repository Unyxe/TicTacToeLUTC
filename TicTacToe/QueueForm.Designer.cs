namespace TicTacToe
{
    partial class QueueForm
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
            this.enter_queue_btn = new System.Windows.Forms.Button();
            this.opponent_id_lbl = new System.Windows.Forms.Label();
            this.app_id_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enter_queue_btn
            // 
            this.enter_queue_btn.Location = new System.Drawing.Point(140, 98);
            this.enter_queue_btn.Name = "enter_queue_btn";
            this.enter_queue_btn.Size = new System.Drawing.Size(75, 23);
            this.enter_queue_btn.TabIndex = 0;
            this.enter_queue_btn.Text = "Queue";
            this.enter_queue_btn.UseVisualStyleBackColor = true;
            this.enter_queue_btn.Click += new System.EventHandler(this.enter_queue_btn_Click);
            // 
            // opponent_id_lbl
            // 
            this.opponent_id_lbl.AutoSize = true;
            this.opponent_id_lbl.Location = new System.Drawing.Point(158, 191);
            this.opponent_id_lbl.Name = "opponent_id_lbl";
            this.opponent_id_lbl.Size = new System.Drawing.Size(35, 13);
            this.opponent_id_lbl.TabIndex = 1;
            this.opponent_id_lbl.Text = "label1";
            // 
            // app_id_lbl
            // 
            this.app_id_lbl.AutoSize = true;
            this.app_id_lbl.Location = new System.Drawing.Point(158, 154);
            this.app_id_lbl.Name = "app_id_lbl";
            this.app_id_lbl.Size = new System.Drawing.Size(35, 13);
            this.app_id_lbl.TabIndex = 2;
            this.app_id_lbl.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 450);
            this.Controls.Add(this.app_id_lbl);
            this.Controls.Add(this.opponent_id_lbl);
            this.Controls.Add(this.enter_queue_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enter_queue_btn;
        private System.Windows.Forms.Label opponent_id_lbl;
        private System.Windows.Forms.Label app_id_lbl;
    }
}

