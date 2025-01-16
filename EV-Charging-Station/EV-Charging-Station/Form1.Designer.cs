namespace EV_Charging_Station
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
            label1 = new Label();
            labelFreeStationNumber = new Label();
            buttonAddCar = new Button();
            buttonAddStation = new Button();
            listBoxStation = new ListBox();
            listBoxCars = new ListBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            comboBoxStation = new ComboBox();
            numericSoC = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSoC).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 31);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Colonnine libere:";
            // 
            // labelFreeStationNumber
            // 
            labelFreeStationNumber.AutoSize = true;
            labelFreeStationNumber.Location = new Point(144, 32);
            labelFreeStationNumber.Name = "labelFreeStationNumber";
            labelFreeStationNumber.Size = new Size(12, 15);
            labelFreeStationNumber.TabIndex = 1;
            labelFreeStationNumber.Text = "-";
            // 
            // buttonAddCar
            // 
            buttonAddCar.Location = new Point(627, 27);
            buttonAddCar.Name = "buttonAddCar";
            buttonAddCar.Size = new Size(147, 23);
            buttonAddCar.TabIndex = 2;
            buttonAddCar.Text = "Arriva un'auto";
            buttonAddCar.UseVisualStyleBackColor = true;
            buttonAddCar.Click += buttonAddCar_Click;
            // 
            // buttonAddStation
            // 
            buttonAddStation.Location = new Point(627, 70);
            buttonAddStation.Name = "buttonAddStation";
            buttonAddStation.Size = new Size(147, 23);
            buttonAddStation.TabIndex = 3;
            buttonAddStation.Text = "Aggiungi colonnina";
            buttonAddStation.UseVisualStyleBackColor = true;
            buttonAddStation.Click += buttonAddStation_Click;
            // 
            // listBoxStation
            // 
            listBoxStation.FormattingEnabled = true;
            listBoxStation.ItemHeight = 15;
            listBoxStation.Location = new Point(18, 48);
            listBoxStation.Name = "listBoxStation";
            listBoxStation.Size = new Size(154, 214);
            listBoxStation.TabIndex = 4;
            // 
            // listBoxCars
            // 
            listBoxCars.FormattingEnabled = true;
            listBoxCars.ItemHeight = 15;
            listBoxCars.Location = new Point(210, 48);
            listBoxCars.Name = "listBoxCars";
            listBoxCars.Size = new Size(154, 214);
            listBoxCars.Sorted = true;
            listBoxCars.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(listBoxStation);
            groupBox1.Controls.Add(listBoxCars);
            groupBox1.Location = new Point(552, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 272);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(210, 30);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 7;
            label3.Text = "Auto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 30);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 6;
            label2.Text = "Stazioni";
            // 
            // comboBoxStation
            // 
            comboBoxStation.FormattingEnabled = true;
            comboBoxStation.Items.AddRange(new object[] { "Quick (22 kW)", "Fast (50 kW)", "HPC (150 kW)" });
            comboBoxStation.Location = new Point(796, 70);
            comboBoxStation.Name = "comboBoxStation";
            comboBoxStation.Size = new Size(121, 23);
            comboBoxStation.TabIndex = 7;
            // 
            // numericSoC
            // 
            numericSoC.Location = new Point(796, 29);
            numericSoC.Maximum = new decimal(new int[] { 95, 0, 0, 0 });
            numericSoC.Name = "numericSoC";
            numericSoC.Size = new Size(120, 23);
            numericSoC.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 547);
            Controls.Add(numericSoC);
            Controls.Add(comboBoxStation);
            Controls.Add(groupBox1);
            Controls.Add(buttonAddStation);
            Controls.Add(buttonAddCar);
            Controls.Add(labelFreeStationNumber);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSoC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelFreeStationNumber;
        private Button buttonAddCar;
        private Button buttonAddStation;
        private ListBox listBoxStation;
        private ListBox listBoxCars;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private ComboBox comboBoxStation;
        private NumericUpDown numericSoC;
    }
}
