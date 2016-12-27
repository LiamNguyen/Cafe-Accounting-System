namespace AccountingSystemUI
{
    partial class Form_OrderMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OrderMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupE = new System.Windows.Forms.Button();
            this.GroupF = new System.Windows.Forms.Button();
            this.GroupT = new System.Windows.Forms.Button();
            this.GroupSM = new System.Windows.Forms.Button();
            this.GroupSO = new System.Windows.Forms.Button();
            this.GroupD = new System.Windows.Forms.Button();
            this.GroupB = new System.Windows.Forms.Button();
            this.GroupO = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(220, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 33);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dessert-icon.png");
            this.imageList1.Images.SetKeyName(1, "Breakfast-icon.png");
            this.imageList1.Images.SetKeyName(2, "espresso-icon.jpeg");
            this.imageList1.Images.SetKeyName(3, "frappuchino-icon.jpg");
            this.imageList1.Images.SetKeyName(4, "smoothies-icon.jpg");
            this.imageList1.Images.SetKeyName(5, "soda-icon.jpg");
            this.imageList1.Images.SetKeyName(6, "tea-icon.png");
            this.imageList1.Images.SetKeyName(7, "others-icon.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.94384F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.59598F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.423208F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1193, 654);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.GroupE);
            this.flowLayoutPanel1.Controls.Add(this.GroupF);
            this.flowLayoutPanel1.Controls.Add(this.GroupT);
            this.flowLayoutPanel1.Controls.Add(this.GroupSM);
            this.flowLayoutPanel1.Controls.Add(this.GroupSO);
            this.flowLayoutPanel1.Controls.Add(this.GroupD);
            this.flowLayoutPanel1.Controls.Add(this.GroupB);
            this.flowLayoutPanel1.Controls.Add(this.GroupO);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(226, 169);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(878, 485);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // GroupE
            // 
            this.GroupE.ImageIndex = 2;
            this.GroupE.ImageList = this.imageList1;
            this.GroupE.Location = new System.Drawing.Point(3, 3);
            this.GroupE.Name = "GroupE";
            this.GroupE.Size = new System.Drawing.Size(202, 200);
            this.GroupE.TabIndex = 0;
            this.GroupE.UseVisualStyleBackColor = true;
            this.GroupE.Click += new System.EventHandler(this.GroupE_Click);
            // 
            // GroupF
            // 
            this.GroupF.ImageIndex = 3;
            this.GroupF.ImageList = this.imageList1;
            this.GroupF.Location = new System.Drawing.Point(211, 3);
            this.GroupF.Name = "GroupF";
            this.GroupF.Size = new System.Drawing.Size(200, 200);
            this.GroupF.TabIndex = 1;
            this.GroupF.UseVisualStyleBackColor = true;
            // 
            // GroupT
            // 
            this.GroupT.ImageIndex = 6;
            this.GroupT.ImageList = this.imageList1;
            this.GroupT.Location = new System.Drawing.Point(417, 3);
            this.GroupT.Name = "GroupT";
            this.GroupT.Size = new System.Drawing.Size(200, 200);
            this.GroupT.TabIndex = 2;
            this.GroupT.UseVisualStyleBackColor = true;
            // 
            // GroupSM
            // 
            this.GroupSM.ImageIndex = 4;
            this.GroupSM.ImageList = this.imageList1;
            this.GroupSM.Location = new System.Drawing.Point(623, 3);
            this.GroupSM.Name = "GroupSM";
            this.GroupSM.Size = new System.Drawing.Size(200, 200);
            this.GroupSM.TabIndex = 3;
            this.GroupSM.UseVisualStyleBackColor = true;
            this.GroupSM.Click += new System.EventHandler(this.GroupSM_Click);
            // 
            // GroupSO
            // 
            this.GroupSO.ImageIndex = 5;
            this.GroupSO.ImageList = this.imageList1;
            this.GroupSO.Location = new System.Drawing.Point(3, 209);
            this.GroupSO.Name = "GroupSO";
            this.GroupSO.Size = new System.Drawing.Size(202, 200);
            this.GroupSO.TabIndex = 3;
            this.GroupSO.UseVisualStyleBackColor = true;
            // 
            // GroupD
            // 
            this.GroupD.ImageIndex = 0;
            this.GroupD.ImageList = this.imageList1;
            this.GroupD.Location = new System.Drawing.Point(211, 209);
            this.GroupD.Name = "GroupD";
            this.GroupD.Size = new System.Drawing.Size(200, 200);
            this.GroupD.TabIndex = 4;
            this.GroupD.UseVisualStyleBackColor = true;
            // 
            // GroupB
            // 
            this.GroupB.ImageIndex = 1;
            this.GroupB.ImageList = this.imageList1;
            this.GroupB.Location = new System.Drawing.Point(417, 209);
            this.GroupB.Name = "GroupB";
            this.GroupB.Size = new System.Drawing.Size(200, 200);
            this.GroupB.TabIndex = 5;
            this.GroupB.UseVisualStyleBackColor = true;
            // 
            // GroupO
            // 
            this.GroupO.ImageIndex = 7;
            this.GroupO.ImageList = this.imageList1;
            this.GroupO.Location = new System.Drawing.Point(623, 209);
            this.GroupO.Name = "GroupO";
            this.GroupO.Size = new System.Drawing.Size(200, 200);
            this.GroupO.TabIndex = 6;
            this.GroupO.UseVisualStyleBackColor = true;
            this.GroupO.Click += new System.EventHandler(this.GroupO_Click);
            // 
            // OrderMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "OrderMenu";
            this.Text = "Order Menu By Group";
            this.Load += new System.EventHandler(this.OrderMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button GroupE;
        private System.Windows.Forms.Button GroupF;
        private System.Windows.Forms.Button GroupT;
        private System.Windows.Forms.Button GroupSM;
        private System.Windows.Forms.Button GroupSO;
        private System.Windows.Forms.Button GroupD;
        private System.Windows.Forms.Button GroupB;
        private System.Windows.Forms.Button GroupO;
    }
}