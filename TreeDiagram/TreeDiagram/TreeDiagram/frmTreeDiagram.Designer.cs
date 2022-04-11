namespace TreeDiagram
{
    partial class frmTreeDiagram
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
            this.groupContent = new System.Windows.Forms.GroupBox();
            this.pnlDiagram = new System.Windows.Forms.Panel();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.btnPJS4 = new System.Windows.Forms.Button();
            this.pbDiagram = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGen_PJS_S1 = new System.Windows.Forms.Button();
            this.groupContent.SuspendLayout();
            this.pnlDiagram.SuspendLayout();
            this.groupParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // groupContent
            // 
            this.groupContent.Controls.Add(this.pnlDiagram);
            this.groupContent.Location = new System.Drawing.Point(12, 213);
            this.groupContent.Name = "groupContent";
            this.groupContent.Size = new System.Drawing.Size(909, 278);
            this.groupContent.TabIndex = 0;
            this.groupContent.TabStop = false;
            this.groupContent.Text = "Diagram";
            // 
            // pnlDiagram
            // 
            this.pnlDiagram.AutoScroll = true;
            this.pnlDiagram.AutoSize = true;
            this.pnlDiagram.Controls.Add(this.pbDiagram);
            this.pnlDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiagram.Location = new System.Drawing.Point(3, 18);
            this.pnlDiagram.Name = "pnlDiagram";
            this.pnlDiagram.Size = new System.Drawing.Size(903, 257);
            this.pnlDiagram.TabIndex = 0;
            // 
            // groupParameters
            // 
            this.groupParameters.AutoSize = true;
            this.groupParameters.Controls.Add(this.btnGen_PJS_S1);
            this.groupParameters.Controls.Add(this.btnTest);
            this.groupParameters.Controls.Add(this.btnPJS4);
            this.groupParameters.Location = new System.Drawing.Point(12, 12);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(909, 195);
            this.groupParameters.TabIndex = 1;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Parameters";
            // 
            // btnPJS4
            // 
            this.btnPJS4.Location = new System.Drawing.Point(17, 31);
            this.btnPJS4.Name = "btnPJS4";
            this.btnPJS4.Size = new System.Drawing.Size(131, 23);
            this.btnPJS4.TabIndex = 0;
            this.btnPJS4.Text = "Recreate PJ-S4";
            this.btnPJS4.UseVisualStyleBackColor = true;
            this.btnPJS4.Click += new System.EventHandler(this.btnPJS4_Click);
            // 
            // pbDiagram
            // 
            this.pbDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDiagram.Location = new System.Drawing.Point(0, 0);
            this.pbDiagram.Name = "pbDiagram";
            this.pbDiagram.Size = new System.Drawing.Size(903, 257);
            this.pbDiagram.TabIndex = 0;
            this.pbDiagram.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(805, 31);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(74, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGen_PJS_S1
            // 
            this.btnGen_PJS_S1.Location = new System.Drawing.Point(154, 31);
            this.btnGen_PJS_S1.Name = "btnGen_PJS_S1";
            this.btnGen_PJS_S1.Size = new System.Drawing.Size(112, 23);
            this.btnGen_PJS_S1.TabIndex = 2;
            this.btnGen_PJS_S1.Text = "PJ-S6|PJ-S1";
            this.btnGen_PJS_S1.UseVisualStyleBackColor = true;
            this.btnGen_PJS_S1.Click += new System.EventHandler(this.btnGen_PJS_S1_Click);
            // 
            // frmTreeDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 503);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.groupContent);
            this.Name = "frmTreeDiagram";
            this.Text = "Tree Diagram";
            this.groupContent.ResumeLayout(false);
            this.groupContent.PerformLayout();
            this.pnlDiagram.ResumeLayout(false);
            this.groupParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDiagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupContent;
        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.Panel pnlDiagram;
        private System.Windows.Forms.Button btnPJS4;
        private System.Windows.Forms.PictureBox pbDiagram;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGen_PJS_S1;
    }
}

