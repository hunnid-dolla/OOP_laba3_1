namespace OOP_laba3_1
{
    partial class CirclesForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMouseCoordinates = new System.Windows.Forms.Label();
            this.panelCircleCoordinates = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelMouseCoordinates
            // 
            this.labelMouseCoordinates.AutoSize = true;
            this.labelMouseCoordinates.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelMouseCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelMouseCoordinates.Location = new System.Drawing.Point(42, 47);
            this.labelMouseCoordinates.Name = "labelMouseCoordinates";
            this.labelMouseCoordinates.Size = new System.Drawing.Size(58, 22);
            this.labelMouseCoordinates.TabIndex = 0;
            this.labelMouseCoordinates.Text = "label1";
            // 
            // panelCircleCoordinates
            // 
            this.panelCircleCoordinates.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelCircleCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.panelCircleCoordinates.Location = new System.Drawing.Point(37, 92);
            this.panelCircleCoordinates.Name = "panelCircleCoordinates";
            this.panelCircleCoordinates.Size = new System.Drawing.Size(182, 328);
            this.panelCircleCoordinates.TabIndex = 1;
            // 
            // CirclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelCircleCoordinates);
            this.Controls.Add(this.labelMouseCoordinates);
            this.Name = "CirclesForm";
            this.Text = "CirclesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMouseCoordinates;
        private System.Windows.Forms.Panel panelCircleCoordinates;
    }
}

