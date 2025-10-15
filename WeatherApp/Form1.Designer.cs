namespace WeatherApp
{
    partial class MattsWeatherApp
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnGetWeather = new Button();
            lblTemp = new Label();
            lblDesc = new Label();
            lblHumidity = new Label();
            forecastGrid = new DataGridView();
            lblHeader = new Label();
            button2 = new Button();
            NameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)forecastGrid).BeginInit();
            SuspendLayout();
            // 
            // btnGetWeather
            // 
            btnGetWeather.BackColor = Color.SteelBlue;
            btnGetWeather.FlatStyle = FlatStyle.Flat;
            btnGetWeather.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGetWeather.ForeColor = Color.White;
            btnGetWeather.Location = new Point(30, 70);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(180, 40);
            btnGetWeather.TabIndex = 0;
            btnGetWeather.Text = "Get Weather";
            btnGetWeather.UseVisualStyleBackColor = false;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTemp.ForeColor = Color.OrangeRed;
            lblTemp.Location = new Point(250, 70);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(159, 32);
            lblTemp.TabIndex = 1;
            lblTemp.Text = "Temperature";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 11F);
            lblDesc.ForeColor = Color.WhiteSmoke;
            lblDesc.Location = new Point(250, 110);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(107, 30);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "Condition";
            // 
            // lblHumidity
            // 
            lblHumidity.AutoSize = true;
            lblHumidity.Font = new Font("Segoe UI", 11F);
            lblHumidity.ForeColor = Color.WhiteSmoke;
            lblHumidity.Location = new Point(250, 150);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new Size(101, 30);
            lblHumidity.TabIndex = 3;
            lblHumidity.Text = "Humidity";
            // 
            // forecastGrid
            // 
            forecastGrid.BackgroundColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.SteelBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            forecastGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            forecastGrid.ColumnHeadersHeight = 34;
            forecastGrid.EnableHeadersVisualStyles = false;
            forecastGrid.GridColor = Color.Gray;
            forecastGrid.Location = new Point(39, 206);
            forecastGrid.Name = "forecastGrid";
            forecastGrid.RowHeadersVisible = false;
            forecastGrid.RowHeadersWidth = 62;
            forecastGrid.RowTemplate.Height = 28;
            forecastGrid.Size = new Size(640, 250);
            forecastGrid.TabIndex = 4;
            forecastGrid.CellContentClick += forecastGrid_CellContentClick;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Aquamarine;
            lblHeader.Location = new Point(25, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(289, 45);
            lblHeader.TabIndex = 5;
            lblHeader.Text = "My Local Weather";
            // 
            // button2
            // 
            button2.BackColor = Color.SteelBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(510, 70);
            button2.Name = "button2";
            button2.Size = new Size(180, 40);
            button2.TabIndex = 6;
            button2.Text = "New City";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            NameLabel.ForeColor = Color.Aquamarine;
            NameLabel.Location = new Point(321, 459);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(399, 45);
            NameLabel.TabIndex = 7;
            NameLabel.Text = "Matthew Wood 10/14/25";
            NameLabel.TextAlign = ContentAlignment.BottomRight;
            NameLabel.Click += label1_Click;
            // 
            // MattsWeatherApp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(720, 500);
            Controls.Add(NameLabel);
            Controls.Add(button2);
            Controls.Add(lblHeader);
            Controls.Add(forecastGrid);
            Controls.Add(lblHumidity);
            Controls.Add(lblDesc);
            Controls.Add(lblTemp);
            Controls.Add(btnGetWeather);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MattsWeatherApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Weather App - Hanover, PA";
            Load += MattsWeatherApp_Load;
            ((System.ComponentModel.ISupportInitialize)forecastGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGetWeather;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.DataGridView forecastGrid;
        private System.Windows.Forms.Label lblHeader;
        private Button button2;
        private Label NameLabel;
    }
}