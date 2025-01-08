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
            listBoxStation.Location = new Point(37, 97);
            listBoxStation.Name = "listBoxStation";
            listBoxStation.Size = new Size(244, 169);
            listBoxStation.TabIndex = 4;
            // 
            // listBoxCars
            // 
            listBoxCars.FormattingEnabled = true;
            listBoxCars.ItemHeight = 15;
            listBoxCars.Location = new Point(353, 97);
            listBoxCars.Name = "listBoxCars";
            listBoxCars.Size = new Size(234, 169);
            listBoxCars.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxCars);
            Controls.Add(listBoxStation);
            Controls.Add(buttonAddStation);
            Controls.Add(buttonAddCar);
            Controls.Add(labelFreeStationNumber);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
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
    }
}
