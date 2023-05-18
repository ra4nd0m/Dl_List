namespace Dl_List
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.addPathButton = new System.Windows.Forms.Button();
            this.removePathButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonHideFiles = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonHideFolders = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSelectSize = new System.Windows.Forms.Button();
            this.buttonPathHide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(936, 518);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(963, 60);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // addPathButton
            // 
            this.addPathButton.Location = new System.Drawing.Point(963, 216);
            this.addPathButton.Name = "addPathButton";
            this.addPathButton.Size = new System.Drawing.Size(114, 39);
            this.addPathButton.TabIndex = 2;
            this.addPathButton.Text = "Add Path";
            this.addPathButton.UseVisualStyleBackColor = true;
            this.addPathButton.Click += new System.EventHandler(this.addPathButton_Click);
            // 
            // removePathButton
            // 
            this.removePathButton.Location = new System.Drawing.Point(1083, 216);
            this.removePathButton.Name = "removePathButton";
            this.removePathButton.Size = new System.Drawing.Size(114, 39);
            this.removePathButton.TabIndex = 3;
            this.removePathButton.Text = "Remove Paths";
            this.removePathButton.UseVisualStyleBackColor = true;
            this.removePathButton.Click += new System.EventHandler(this.removePathButton_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(963, 539);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(114, 39);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonHideFiles
            // 
            this.buttonHideFiles.Location = new System.Drawing.Point(963, 494);
            this.buttonHideFiles.Name = "buttonHideFiles";
            this.buttonHideFiles.Size = new System.Drawing.Size(114, 39);
            this.buttonHideFiles.TabIndex = 5;
            this.buttonHideFiles.Text = "Hide Files";
            this.buttonHideFiles.UseVisualStyleBackColor = true;
            this.buttonHideFiles.Click += new System.EventHandler(this.buttonHideFiles_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(932, 23);
            this.textBox1.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(963, 31);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(114, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonHideFolders
            // 
            this.buttonHideFolders.Location = new System.Drawing.Point(1089, 494);
            this.buttonHideFolders.Name = "buttonHideFolders";
            this.buttonHideFolders.Size = new System.Drawing.Size(114, 39);
            this.buttonHideFolders.TabIndex = 8;
            this.buttonHideFolders.Text = "Hide Folders";
            this.buttonHideFolders.UseVisualStyleBackColor = true;
            this.buttonHideFolders.Click += new System.EventHandler(this.buttonHideFolders_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(1089, 539);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(114, 39);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete Selected";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSelectSize
            // 
            this.buttonSelectSize.Location = new System.Drawing.Point(963, 449);
            this.buttonSelectSize.Name = "buttonSelectSize";
            this.buttonSelectSize.Size = new System.Drawing.Size(114, 39);
            this.buttonSelectSize.TabIndex = 10;
            this.buttonSelectSize.Text = "KB";
            this.buttonSelectSize.UseVisualStyleBackColor = true;
            this.buttonSelectSize.Click += new System.EventHandler(this.buttonSelectSize_Click);
            // 
            // buttonPathHide
            // 
            this.buttonPathHide.Location = new System.Drawing.Point(1089, 449);
            this.buttonPathHide.Name = "buttonPathHide";
            this.buttonPathHide.Size = new System.Drawing.Size(114, 39);
            this.buttonPathHide.TabIndex = 11;
            this.buttonPathHide.Text = "Hide Selected Path";
            this.buttonPathHide.UseVisualStyleBackColor = true;
            this.buttonPathHide.Click += new System.EventHandler(this.buttonPathHide_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(1215, 602);
            this.Controls.Add(this.buttonPathHide);
            this.Controls.Add(this.buttonSelectSize);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonHideFolders);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonHideFiles);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.removePathButton);
            this.Controls.Add(this.addPathButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1231, 641);
            this.MinimumSize = new System.Drawing.Size(1231, 641);
            this.Name = "Main";
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button addPathButton;
        private Button removePathButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonUpdate;
        private Button buttonHideFiles;
        private TextBox textBox1;
        private Button buttonSearch;
        private Button buttonHideFolders;
        private Button buttonDelete;
        private Button buttonSelectSize;
        private Button buttonPathHide;
    }
}