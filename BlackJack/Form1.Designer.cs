namespace BlackJack
{
    partial class MainWindow
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
            this.croupier_score = new System.Windows.Forms.Label();
            this.hit_btn = new System.Windows.Forms.Button();
            this.stand_btn = new System.Windows.Forms.Button();
            this.player_score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // croupier_score
            // 
            this.croupier_score.AutoSize = true;
            this.croupier_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.croupier_score.ForeColor = System.Drawing.Color.Green;
            this.croupier_score.Location = new System.Drawing.Point(770, 50);
            this.croupier_score.Name = "croupier_score";
            this.croupier_score.Size = new System.Drawing.Size(30, 31);
            this.croupier_score.TabIndex = 1;
            this.croupier_score.Text = "0";
            // 
            // hit_btn
            // 
            this.hit_btn.Location = new System.Drawing.Point(272, 411);
            this.hit_btn.Name = "hit_btn";
            this.hit_btn.Size = new System.Drawing.Size(75, 23);
            this.hit_btn.TabIndex = 2;
            this.hit_btn.Text = "Hit";
            this.hit_btn.UseVisualStyleBackColor = true;
            this.hit_btn.Click += new System.EventHandler(this.hit_btn_Click);
            // 
            // stand_btn
            // 
            this.stand_btn.Location = new System.Drawing.Point(458, 411);
            this.stand_btn.Name = "stand_btn";
            this.stand_btn.Size = new System.Drawing.Size(75, 23);
            this.stand_btn.TabIndex = 3;
            this.stand_btn.Text = "Stand";
            this.stand_btn.UseVisualStyleBackColor = true;
            this.stand_btn.Click += new System.EventHandler(this.stand_btn_Click);
            // 
            // player_score
            // 
            this.player_score.AutoSize = true;
            this.player_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player_score.ForeColor = System.Drawing.Color.Green;
            this.player_score.Location = new System.Drawing.Point(770, 256);
            this.player_score.Name = "player_score";
            this.player_score.Size = new System.Drawing.Size(30, 31);
            this.player_score.TabIndex = 5;
            this.player_score.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 462);
            this.Controls.Add(this.player_score);
            this.Controls.Add(this.stand_btn);
            this.Controls.Add(this.hit_btn);
            this.Controls.Add(this.croupier_score);
            this.Name = "MainWindow";
            this.Text = "BlackJack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label croupier_score;
        private System.Windows.Forms.Button hit_btn;
        private System.Windows.Forms.Button stand_btn;
        private System.Windows.Forms.Label player_score;
    }
}

