namespace Hastane_Proje_2
{
    partial class HastaneGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastaneGiris));
            this.btnhasta = new System.Windows.Forms.Button();
            this.btndoktor = new System.Windows.Forms.Button();
            this.btnsekrtr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnhasta
            // 
            this.btnhasta.Location = new System.Drawing.Point(15, 69);
            this.btnhasta.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnhasta.Name = "btnhasta";
            this.btnhasta.Size = new System.Drawing.Size(274, 246);
            this.btnhasta.TabIndex = 0;
            this.btnhasta.Text = "Hasta";
            this.btnhasta.UseVisualStyleBackColor = true;
            this.btnhasta.Click += new System.EventHandler(this.btnhasta_Click);
            // 
            // btndoktor
            // 
            this.btndoktor.Location = new System.Drawing.Point(317, 69);
            this.btndoktor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btndoktor.Name = "btndoktor";
            this.btndoktor.Size = new System.Drawing.Size(277, 246);
            this.btndoktor.TabIndex = 1;
            this.btndoktor.Text = "Doktor";
            this.btndoktor.UseVisualStyleBackColor = true;
            this.btndoktor.Click += new System.EventHandler(this.btndoktor_Click);
            // 
            // btnsekrtr
            // 
            this.btnsekrtr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnsekrtr.Location = new System.Drawing.Point(623, 69);
            this.btnsekrtr.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnsekrtr.Name = "btnsekrtr";
            this.btnsekrtr.Size = new System.Drawing.Size(266, 246);
            this.btnsekrtr.TabIndex = 2;
            this.btnsekrtr.Text = "Sekreter";
            this.btnsekrtr.UseVisualStyleBackColor = true;
            this.btnsekrtr.Click += new System.EventHandler(this.btnsekrtr_Click);
            // 
            // HastaneGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(957, 402);
            this.Controls.Add(this.btnsekrtr);
            this.Controls.Add(this.btndoktor);
            this.Controls.Add(this.btnhasta);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "HastaneGiris";
            this.Text = "Ana Sayfa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnhasta;
        private System.Windows.Forms.Button btndoktor;
        private System.Windows.Forms.Button btnsekrtr;
    }
}

