namespace Chia_Coin_Inspector
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            walletList = new ListBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            XCHlbl = new Label();
            Coinslbl = new Label();
            chiarecords = new DataGridView();
            blockstatuslbl = new Label();
            Refreshbtn = new Button();
            nftImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chiarecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nftImage).BeginInit();
            SuspendLayout();
            // 
            // walletList
            // 
            walletList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            walletList.FormattingEnabled = true;
            walletList.ItemHeight = 15;
            walletList.Location = new Point(100, 747);
            walletList.Name = "walletList";
            walletList.Size = new Size(218, 94);
            walletList.TabIndex = 1;
            walletList.SelectedIndexChanged += walletList_SelectedIndexChanged;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(418, 747);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Fragmentation";
            chart1.Series.Add(series1);
            chart1.Size = new Size(490, 252);
            chart1.TabIndex = 2;
            chart1.Text = "Coin Fragmentation";
            // 
            // XCHlbl
            // 
            XCHlbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            XCHlbl.AutoSize = true;
            XCHlbl.Location = new Point(972, 747);
            XCHlbl.Name = "XCHlbl";
            XCHlbl.Size = new Size(0, 15);
            XCHlbl.TabIndex = 3;
            // 
            // Coinslbl
            // 
            Coinslbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Coinslbl.AutoSize = true;
            Coinslbl.Location = new Point(972, 780);
            Coinslbl.Name = "Coinslbl";
            Coinslbl.Size = new Size(0, 15);
            Coinslbl.TabIndex = 4;
            // 
            // chiarecords
            // 
            chiarecords.AllowUserToAddRows = false;
            chiarecords.AllowUserToDeleteRows = false;
            chiarecords.AllowUserToOrderColumns = true;
            chiarecords.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chiarecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            chiarecords.EditMode = DataGridViewEditMode.EditProgrammatically;
            chiarecords.Location = new Point(3, 36);
            chiarecords.MultiSelect = false;
            chiarecords.Name = "chiarecords";
            chiarecords.ReadOnly = true;
            chiarecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            chiarecords.Size = new Size(1294, 258);
            chiarecords.TabIndex = 6;
            chiarecords.TabStop = false;
            chiarecords.MouseDown += chiarecords_MouseDown;
            // 
            // blockstatuslbl
            // 
            blockstatuslbl.Anchor = AnchorStyles.Top;
            blockstatuslbl.AutoSize = true;
            blockstatuslbl.Location = new Point(631, 7);
            blockstatuslbl.Name = "blockstatuslbl";
            blockstatuslbl.Size = new Size(38, 15);
            blockstatuslbl.TabIndex = 8;
            blockstatuslbl.Text = "label1";
            // 
            // Refreshbtn
            // 
            Refreshbtn.Location = new Point(3, 7);
            Refreshbtn.Name = "Refreshbtn";
            Refreshbtn.Size = new Size(75, 23);
            Refreshbtn.TabIndex = 10;
            Refreshbtn.Text = "Refresh";
            Refreshbtn.UseVisualStyleBackColor = true;
            Refreshbtn.Click += Refreshbtn_Click;
            // 
            // nftImage
            // 
            nftImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nftImage.Location = new Point(313, 300);
            nftImage.Name = "nftImage";
            nftImage.Size = new Size(659, 435);
            nftImage.SizeMode = PictureBoxSizeMode.StretchImage;
            nftImage.TabIndex = 11;
            nftImage.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 1008);
            Controls.Add(nftImage);
            Controls.Add(Refreshbtn);
            Controls.Add(blockstatuslbl);
            Controls.Add(chiarecords);
            Controls.Add(chart1);
            Controls.Add(Coinslbl);
            Controls.Add(XCHlbl);
            Controls.Add(walletList);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chiarecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)nftImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox walletList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label XCHlbl;
        private Label Coinslbl;
        private Button button1;
        private DataGridView chiarecords;
        private Label blockstatuslbl;
        private Button Refreshbtn;
        private PictureBox nftImage;
    }
}
