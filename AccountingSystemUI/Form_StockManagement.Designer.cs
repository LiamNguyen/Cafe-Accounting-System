namespace AccountingSystemUI
{
    partial class Form_StockManagement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab_GroupIngredients = new System.Windows.Forms.TabControl();
            this.tabPg_Group = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addNewGroupBtn = new System.Windows.Forms.Button();
            this.grid_Group = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupNameTxtBox = new System.Windows.Forms.TextBox();
            this.groupIdTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPg_Ingredients = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cancelIngBtn = new System.Windows.Forms.Button();
            this.deleteIngBtn = new System.Windows.Forms.Button();
            this.editIngBtn = new System.Windows.Forms.Button();
            this.saveIngBtn = new System.Windows.Forms.Button();
            this.addNewIngBtn = new System.Windows.Forms.Button();
            this.grid_Ingredients = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmb_Unit = new System.Windows.Forms.ComboBox();
            this.cmbBox_Group = new System.Windows.Forms.ComboBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.txt_Vat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.txt_ExpDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_PackageNo = new System.Windows.Forms.TextBox();
            this.txt_IngName = new System.Windows.Forms.TextBox();
            this.txt_IngID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tab_GroupIngredients.SuspendLayout();
            this.tabPg_Group.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Group)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPg_Ingredients.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Ingredients)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_GroupIngredients
            // 
            this.tab_GroupIngredients.Controls.Add(this.tabPg_Group);
            this.tab_GroupIngredients.Controls.Add(this.tabPg_Ingredients);
            this.tab_GroupIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_GroupIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_GroupIngredients.Location = new System.Drawing.Point(0, 0);
            this.tab_GroupIngredients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_GroupIngredients.Name = "tab_GroupIngredients";
            this.tab_GroupIngredients.SelectedIndex = 0;
            this.tab_GroupIngredients.Size = new System.Drawing.Size(1914, 1053);
            this.tab_GroupIngredients.TabIndex = 0;
            this.tab_GroupIngredients.SelectedIndexChanged += new System.EventHandler(this.tab_GroupIngredients_SelectedIndexChanged);
            // 
            // tabPg_Group
            // 
            this.tabPg_Group.Controls.Add(this.panel2);
            this.tabPg_Group.Controls.Add(this.grid_Group);
            this.tabPg_Group.Controls.Add(this.tableLayoutPanel1);
            this.tabPg_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Group.Location = new System.Drawing.Point(4, 33);
            this.tabPg_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPg_Group.Name = "tabPg_Group";
            this.tabPg_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPg_Group.Size = new System.Drawing.Size(1906, 1016);
            this.tabPg_Group.TabIndex = 0;
            this.tabPg_Group.Text = "Ingredients Groups";
            this.tabPg_Group.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cancelBtn);
            this.panel2.Controls.Add(this.deleteBtn);
            this.panel2.Controls.Add(this.editBtn);
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Controls.Add(this.addNewGroupBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 926);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1898, 85);
            this.panel2.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(880, 0);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(220, 85);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            this.cancelBtn.MouseLeave += new System.EventHandler(this.cancelBtn_MouseLeave);
            this.cancelBtn.MouseHover += new System.EventHandler(this.cancelBtn_MouseHover);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(660, 0);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(220, 85);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            this.deleteBtn.MouseLeave += new System.EventHandler(this.deleteBtn_MouseLeave);
            this.deleteBtn.MouseHover += new System.EventHandler(this.deleteBtn_MouseHover);
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(440, 0);
            this.editBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(220, 85);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            this.editBtn.MouseLeave += new System.EventHandler(this.editBtn_MouseLeave);
            this.editBtn.MouseHover += new System.EventHandler(this.editBtn_MouseHover);
            // 
            // saveBtn
            // 
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(220, 0);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(220, 85);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            this.saveBtn.MouseLeave += new System.EventHandler(this.saveBtn_MouseLeave);
            this.saveBtn.MouseHover += new System.EventHandler(this.saveBtn_MouseHover);
            // 
            // addNewGroupBtn
            // 
            this.addNewGroupBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.addNewGroupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewGroupBtn.Location = new System.Drawing.Point(0, 0);
            this.addNewGroupBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewGroupBtn.Name = "addNewGroupBtn";
            this.addNewGroupBtn.Size = new System.Drawing.Size(220, 85);
            this.addNewGroupBtn.TabIndex = 0;
            this.addNewGroupBtn.Text = "Add New";
            this.addNewGroupBtn.UseVisualStyleBackColor = false;
            this.addNewGroupBtn.Click += new System.EventHandler(this.addNewGroupBtn_Click);
            this.addNewGroupBtn.MouseLeave += new System.EventHandler(this.addNewGroupBtn_MouseLeave);
            this.addNewGroupBtn.MouseHover += new System.EventHandler(this.addNewGroupBtn_MouseHover);
            // 
            // grid_Group
            // 
            this.grid_Group.AllowUserToAddRows = false;
            this.grid_Group.AllowUserToDeleteRows = false;
            this.grid_Group.AllowUserToResizeColumns = false;
            this.grid_Group.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_Group.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid_Group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Group.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.grid_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Group.Location = new System.Drawing.Point(4, 170);
            this.grid_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_Group.MultiSelect = false;
            this.grid_Group.Name = "grid_Group";
            this.grid_Group.ReadOnly = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Group.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Group.Size = new System.Drawing.Size(1898, 841);
            this.grid_Group.TabIndex = 1;
            this.grid_Group.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Group_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "GROUP_ID";
            this.Column1.HeaderText = "Group ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "GROUP_NAME";
            this.Column2.HeaderText = "Group Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "DATE";
            this.Column3.HeaderText = "Date Created";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "STAFFID";
            this.Column4.HeaderText = "Staff Creates";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.121688F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.87831F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1898, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupNameTxtBox);
            this.panel1.Controls.Add(this.groupIdTxtBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(77, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1693, 155);
            this.panel1.TabIndex = 0;
            // 
            // groupNameTxtBox
            // 
            this.groupNameTxtBox.Location = new System.Drawing.Point(651, 98);
            this.groupNameTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupNameTxtBox.Name = "groupNameTxtBox";
            this.groupNameTxtBox.Size = new System.Drawing.Size(226, 26);
            this.groupNameTxtBox.TabIndex = 3;
            this.groupNameTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.groupNameTxtBox_KeyDown);
            // 
            // groupIdTxtBox
            // 
            this.groupIdTxtBox.Location = new System.Drawing.Point(262, 98);
            this.groupIdTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupIdTxtBox.Name = "groupIdTxtBox";
            this.groupIdTxtBox.Size = new System.Drawing.Size(148, 26);
            this.groupIdTxtBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group ID";
            // 
            // tabPg_Ingredients
            // 
            this.tabPg_Ingredients.Controls.Add(this.panel3);
            this.tabPg_Ingredients.Controls.Add(this.grid_Ingredients);
            this.tabPg_Ingredients.Controls.Add(this.tableLayoutPanel2);
            this.tabPg_Ingredients.Location = new System.Drawing.Point(4, 33);
            this.tabPg_Ingredients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPg_Ingredients.Name = "tabPg_Ingredients";
            this.tabPg_Ingredients.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPg_Ingredients.Size = new System.Drawing.Size(1906, 1016);
            this.tabPg_Ingredients.TabIndex = 1;
            this.tabPg_Ingredients.Text = "Ingredients";
            this.tabPg_Ingredients.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.cancelIngBtn);
            this.panel3.Controls.Add(this.deleteIngBtn);
            this.panel3.Controls.Add(this.editIngBtn);
            this.panel3.Controls.Add(this.saveIngBtn);
            this.panel3.Controls.Add(this.addNewIngBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(4, 933);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1898, 78);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::AccountingSystemUI.Properties.Resources.excelIcon;
            this.pictureBox2.Location = new System.Drawing.Point(1100, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // cancelIngBtn
            // 
            this.cancelIngBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancelIngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelIngBtn.Location = new System.Drawing.Point(880, 0);
            this.cancelIngBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelIngBtn.Name = "cancelIngBtn";
            this.cancelIngBtn.Size = new System.Drawing.Size(220, 78);
            this.cancelIngBtn.TabIndex = 9;
            this.cancelIngBtn.Text = "Cancel";
            this.cancelIngBtn.UseVisualStyleBackColor = false;
            this.cancelIngBtn.Click += new System.EventHandler(this.cancelIngBtn_Click);
            this.cancelIngBtn.MouseLeave += new System.EventHandler(this.cancelIngBtn_MouseLeave);
            this.cancelIngBtn.MouseHover += new System.EventHandler(this.cancelIngBtn_MouseHover);
            // 
            // deleteIngBtn
            // 
            this.deleteIngBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteIngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteIngBtn.Location = new System.Drawing.Point(660, 0);
            this.deleteIngBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteIngBtn.Name = "deleteIngBtn";
            this.deleteIngBtn.Size = new System.Drawing.Size(220, 78);
            this.deleteIngBtn.TabIndex = 8;
            this.deleteIngBtn.Text = "Delete";
            this.deleteIngBtn.UseVisualStyleBackColor = false;
            this.deleteIngBtn.Click += new System.EventHandler(this.deleteIngBtn_Click);
            this.deleteIngBtn.MouseLeave += new System.EventHandler(this.deleteIngBtn_MouseLeave);
            this.deleteIngBtn.MouseHover += new System.EventHandler(this.deleteIngBtn_MouseHover);
            // 
            // editIngBtn
            // 
            this.editIngBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.editIngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editIngBtn.Location = new System.Drawing.Point(440, 0);
            this.editIngBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editIngBtn.Name = "editIngBtn";
            this.editIngBtn.Size = new System.Drawing.Size(220, 78);
            this.editIngBtn.TabIndex = 7;
            this.editIngBtn.Text = "Edit";
            this.editIngBtn.UseVisualStyleBackColor = false;
            this.editIngBtn.Click += new System.EventHandler(this.editIngBtn_Click);
            this.editIngBtn.MouseLeave += new System.EventHandler(this.editIngBtn_MouseLeave);
            this.editIngBtn.MouseHover += new System.EventHandler(this.editIngBtn_MouseHover);
            // 
            // saveIngBtn
            // 
            this.saveIngBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveIngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveIngBtn.Location = new System.Drawing.Point(220, 0);
            this.saveIngBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveIngBtn.Name = "saveIngBtn";
            this.saveIngBtn.Size = new System.Drawing.Size(220, 78);
            this.saveIngBtn.TabIndex = 6;
            this.saveIngBtn.Text = "Save";
            this.saveIngBtn.UseVisualStyleBackColor = false;
            this.saveIngBtn.Click += new System.EventHandler(this.saveIngBtn_Click);
            this.saveIngBtn.MouseLeave += new System.EventHandler(this.saveIngBtn_MouseLeave);
            this.saveIngBtn.MouseHover += new System.EventHandler(this.saveIngBtn_MouseHover);
            // 
            // addNewIngBtn
            // 
            this.addNewIngBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.addNewIngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewIngBtn.Location = new System.Drawing.Point(0, 0);
            this.addNewIngBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addNewIngBtn.Name = "addNewIngBtn";
            this.addNewIngBtn.Size = new System.Drawing.Size(220, 78);
            this.addNewIngBtn.TabIndex = 5;
            this.addNewIngBtn.Text = "Add New";
            this.addNewIngBtn.UseVisualStyleBackColor = false;
            this.addNewIngBtn.Click += new System.EventHandler(this.addNewIngBtn_Click);
            this.addNewIngBtn.MouseLeave += new System.EventHandler(this.addNewIngBtn_MouseLeave);
            this.addNewIngBtn.MouseHover += new System.EventHandler(this.addNewIngBtn_MouseHover);
            // 
            // grid_Ingredients
            // 
            this.grid_Ingredients.AllowUserToAddRows = false;
            this.grid_Ingredients.AllowUserToDeleteRows = false;
            this.grid_Ingredients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_Ingredients.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid_Ingredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Ingredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Ingredients.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Ingredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Ingredients.Location = new System.Drawing.Point(4, 222);
            this.grid_Ingredients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grid_Ingredients.MultiSelect = false;
            this.grid_Ingredients.Name = "grid_Ingredients";
            this.grid_Ingredients.ReadOnly = true;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Ingredients.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_Ingredients.Size = new System.Drawing.Size(1898, 789);
            this.grid_Ingredients.TabIndex = 1;
            this.grid_Ingredients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Ingredients_CellClick);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "ING_ID";
            this.Column5.HeaderText = "Ingredients ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "ING_NAME";
            this.Column6.HeaderText = "Ingredients Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "PKG_NO";
            this.Column7.HeaderText = "Package No";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "EXPIRED_DATE";
            this.Column8.HeaderText = "Exp. Date";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "QUANTITY";
            this.Column9.HeaderText = "Remain In Stock";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.DataPropertyName = "QUANTITY_INPUT";
            this.Column10.HeaderText = "Quantity ";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.DataPropertyName = "UNIT";
            this.Column11.HeaderText = "Unit";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column12.DataPropertyName = "VAT";
            this.Column12.HeaderText = "VAT";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column13.DataPropertyName = "PRODUCTPRICE";
            this.Column13.HeaderText = "Price";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column14.DataPropertyName = "GROUP_ID";
            this.Column14.HeaderText = "Group ID";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.6339144F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.36609F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1898, 217);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(16, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1878, 207);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmb_Unit);
            this.panel6.Controls.Add(this.cmbBox_Group);
            this.panel6.Controls.Add(this.txt_Price);
            this.panel6.Controls.Add(this.txt_Vat);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txt_Quantity);
            this.panel6.Controls.Add(this.txt_ExpDate);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txt_PackageNo);
            this.panel6.Controls.Add(this.txt_IngName);
            this.panel6.Controls.Add(this.txt_IngID);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1878, 207);
            this.panel6.TabIndex = 20;
            // 
            // cmb_Unit
            // 
            this.cmb_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Unit.FormattingEnabled = true;
            this.cmb_Unit.Items.AddRange(new object[] {
            "kg",
            "g",
            "l",
            "ml"});
            this.cmb_Unit.Location = new System.Drawing.Point(604, 142);
            this.cmb_Unit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Unit.Name = "cmb_Unit";
            this.cmb_Unit.Size = new System.Drawing.Size(180, 28);
            this.cmb_Unit.TabIndex = 36;
            // 
            // cmbBox_Group
            // 
            this.cmbBox_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBox_Group.FormattingEnabled = true;
            this.cmbBox_Group.Location = new System.Drawing.Point(945, 142);
            this.cmbBox_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBox_Group.Name = "cmbBox_Group";
            this.cmbBox_Group.Size = new System.Drawing.Size(180, 28);
            this.cmbBox_Group.TabIndex = 35;
            // 
            // txt_Price
            // 
            this.txt_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Price.Location = new System.Drawing.Point(945, 88);
            this.txt_Price.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(178, 26);
            this.txt_Price.TabIndex = 34;
            // 
            // txt_Vat
            // 
            this.txt_Vat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Vat.Location = new System.Drawing.Point(945, 34);
            this.txt_Vat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Vat.Name = "txt_Vat";
            this.txt_Vat.Size = new System.Drawing.Size(178, 26);
            this.txt_Vat.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(846, 146);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 24);
            this.label9.TabIndex = 32;
            this.label9.Text = "Group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(846, 92);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 24);
            this.label10.TabIndex = 31;
            this.label10.Text = "Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(846, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 30;
            this.label11.Text = "VAT";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(604, 88);
            this.txt_Quantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(181, 26);
            this.txt_Quantity.TabIndex = 29;
            // 
            // txt_ExpDate
            // 
            this.txt_ExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ExpDate.Location = new System.Drawing.Point(604, 34);
            this.txt_ExpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ExpDate.Name = "txt_ExpDate";
            this.txt_ExpDate.Size = new System.Drawing.Size(181, 26);
            this.txt_ExpDate.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(436, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Unit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(436, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "Expiry Date";
            // 
            // txt_PackageNo
            // 
            this.txt_PackageNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PackageNo.Location = new System.Drawing.Point(208, 142);
            this.txt_PackageNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PackageNo.Name = "txt_PackageNo";
            this.txt_PackageNo.Size = new System.Drawing.Size(180, 26);
            this.txt_PackageNo.TabIndex = 24;
            // 
            // txt_IngName
            // 
            this.txt_IngName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IngName.Location = new System.Drawing.Point(208, 88);
            this.txt_IngName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_IngName.Name = "txt_IngName";
            this.txt_IngName.Size = new System.Drawing.Size(180, 26);
            this.txt_IngName.TabIndex = 23;
            // 
            // txt_IngID
            // 
            this.txt_IngID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IngID.Location = new System.Drawing.Point(208, 34);
            this.txt_IngID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_IngID.Name = "txt_IngID";
            this.txt_IngID.Size = new System.Drawing.Size(180, 26);
            this.txt_IngID.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "Package No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "ID";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1053);
            this.Controls.Add(this.tab_GroupIngredients);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_StockManagement";
            this.Text = "Form_StockManagement";
            this.Load += new System.EventHandler(this.Form_StockManagement_Load);
            this.tab_GroupIngredients.ResumeLayout(false);
            this.tabPg_Group.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Group)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPg_Ingredients.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Ingredients)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_GroupIngredients;
        private System.Windows.Forms.TabPage tabPg_Group;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addNewGroupBtn;
        private System.Windows.Forms.DataGridView grid_Group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox groupNameTxtBox;
        private System.Windows.Forms.TextBox groupIdTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPg_Ingredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView grid_Ingredients;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cancelIngBtn;
        private System.Windows.Forms.Button deleteIngBtn;
        private System.Windows.Forms.Button editIngBtn;
        private System.Windows.Forms.Button saveIngBtn;
        private System.Windows.Forms.Button addNewIngBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmb_Unit;
        private System.Windows.Forms.ComboBox cmbBox_Group;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.TextBox txt_Vat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.TextBox txt_ExpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_PackageNo;
        private System.Windows.Forms.TextBox txt_IngName;
        private System.Windows.Forms.TextBox txt_IngID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}