namespace ListingSoftware
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxSoftwares = new System.Windows.Forms.ListBox();
            this.checkedListBoxKeys = new System.Windows.Forms.CheckedListBox();
            this.listBoxWantedSoft = new System.Windows.Forms.ListBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCreateList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxSoftwares);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCreateList);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSubmit);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxWantedSoft);
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBoxKeys);
            this.splitContainer1.Size = new System.Drawing.Size(774, 400);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBoxSoftwares
            // 
            this.listBoxSoftwares.FormattingEnabled = true;
            this.listBoxSoftwares.Location = new System.Drawing.Point(3, 5);
            this.listBoxSoftwares.Name = "listBoxSoftwares";
            this.listBoxSoftwares.Size = new System.Drawing.Size(340, 394);
            this.listBoxSoftwares.TabIndex = 0;
            // 
            // checkedListBoxKeys
            // 
            this.checkedListBoxKeys.FormattingEnabled = true;
            this.checkedListBoxKeys.Location = new System.Drawing.Point(0, 5);
            this.checkedListBoxKeys.Name = "checkedListBoxKeys";
            this.checkedListBoxKeys.Size = new System.Drawing.Size(309, 244);
            this.checkedListBoxKeys.TabIndex = 0;
            // 
            // listBoxWantedSoft
            // 
            this.listBoxWantedSoft.FormattingEnabled = true;
            this.listBoxWantedSoft.Location = new System.Drawing.Point(0, 252);
            this.listBoxWantedSoft.Name = "listBoxWantedSoft";
            this.listBoxWantedSoft.Size = new System.Drawing.Size(309, 147);
            this.listBoxWantedSoft.TabIndex = 1;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(315, 360);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(107, 37);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Soumettre";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // buttonCreateList
            // 
            this.buttonCreateList.Location = new System.Drawing.Point(315, 317);
            this.buttonCreateList.Name = "buttonCreateList";
            this.buttonCreateList.Size = new System.Drawing.Size(107, 37);
            this.buttonCreateList.TabIndex = 3;
            this.buttonCreateList.Text = "Générer la liste";
            this.buttonCreateList.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 400);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Lynxia";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxSoftwares;
        private System.Windows.Forms.Button buttonCreateList;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.ListBox listBoxWantedSoft;
        private System.Windows.Forms.CheckedListBox checkedListBoxKeys;
    }
}