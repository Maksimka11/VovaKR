namespace Forester
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTaskAdd = new System.Windows.Forms.Button();
            this.btnTaskChange = new System.Windows.Forms.Button();
            this.btnTaskDel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCareDel = new System.Windows.Forms.Button();
            this.btnCareChange = new System.Windows.Forms.Button();
            this.btnCareAdd = new System.Windows.Forms.Button();
            this.dgvCare = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegionDel = new System.Windows.Forms.Button();
            this.btnRegionChange = new System.Windows.Forms.Button();
            this.btnRegionAdd = new System.Windows.Forms.Button();
            this.dgvRegion = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCare)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Запланированные задачи";
            // 
            // dgvTask
            // 
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Location = new System.Drawing.Point(15, 25);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.Size = new System.Drawing.Size(773, 115);
            this.dgvTask.TabIndex = 1;
            this.dgvTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTask_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTaskDel);
            this.panel1.Controls.Add(this.btnTaskChange);
            this.panel1.Controls.Add(this.btnTaskAdd);
            this.panel1.Location = new System.Drawing.Point(15, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 42);
            this.panel1.TabIndex = 2;
            // 
            // btnTaskAdd
            // 
            this.btnTaskAdd.Location = new System.Drawing.Point(15, 9);
            this.btnTaskAdd.Name = "btnTaskAdd";
            this.btnTaskAdd.Size = new System.Drawing.Size(75, 23);
            this.btnTaskAdd.TabIndex = 0;
            this.btnTaskAdd.Text = "Добавить";
            this.btnTaskAdd.UseVisualStyleBackColor = true;
            this.btnTaskAdd.Click += new System.EventHandler(this.BtnTaskAdd_Click);
            // 
            // btnTaskChange
            // 
            this.btnTaskChange.Location = new System.Drawing.Point(135, 9);
            this.btnTaskChange.Name = "btnTaskChange";
            this.btnTaskChange.Size = new System.Drawing.Size(75, 23);
            this.btnTaskChange.TabIndex = 1;
            this.btnTaskChange.Text = "Изменить";
            this.btnTaskChange.UseVisualStyleBackColor = true;
            this.btnTaskChange.Click += new System.EventHandler(this.BtnTaskChange_Click);
            // 
            // btnTaskDel
            // 
            this.btnTaskDel.Location = new System.Drawing.Point(255, 9);
            this.btnTaskDel.Name = "btnTaskDel";
            this.btnTaskDel.Size = new System.Drawing.Size(75, 23);
            this.btnTaskDel.TabIndex = 2;
            this.btnTaskDel.Text = "Удалить";
            this.btnTaskDel.UseVisualStyleBackColor = true;
            this.btnTaskDel.Click += new System.EventHandler(this.BtnTaskDel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCareDel);
            this.panel2.Controls.Add(this.btnCareChange);
            this.panel2.Controls.Add(this.btnCareAdd);
            this.panel2.Location = new System.Drawing.Point(15, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 42);
            this.panel2.TabIndex = 5;
            // 
            // btnCareDel
            // 
            this.btnCareDel.Location = new System.Drawing.Point(255, 9);
            this.btnCareDel.Name = "btnCareDel";
            this.btnCareDel.Size = new System.Drawing.Size(75, 23);
            this.btnCareDel.TabIndex = 2;
            this.btnCareDel.Text = "Удалить";
            this.btnCareDel.UseVisualStyleBackColor = true;
            this.btnCareDel.Click += new System.EventHandler(this.BtnCareDel_Click);
            // 
            // btnCareChange
            // 
            this.btnCareChange.Location = new System.Drawing.Point(135, 9);
            this.btnCareChange.Name = "btnCareChange";
            this.btnCareChange.Size = new System.Drawing.Size(75, 23);
            this.btnCareChange.TabIndex = 1;
            this.btnCareChange.Text = "Изменить";
            this.btnCareChange.UseVisualStyleBackColor = true;
            this.btnCareChange.Click += new System.EventHandler(this.BtnCareChange_Click);
            // 
            // btnCareAdd
            // 
            this.btnCareAdd.Location = new System.Drawing.Point(15, 9);
            this.btnCareAdd.Name = "btnCareAdd";
            this.btnCareAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCareAdd.TabIndex = 0;
            this.btnCareAdd.Text = "Добавить";
            this.btnCareAdd.UseVisualStyleBackColor = true;
            this.btnCareAdd.Click += new System.EventHandler(this.BtnCareAdd_Click);
            // 
            // dgvCare
            // 
            this.dgvCare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCare.Location = new System.Drawing.Point(15, 203);
            this.dgvCare.Name = "dgvCare";
            this.dgvCare.Size = new System.Drawing.Size(773, 115);
            this.dgvCare.TabIndex = 4;
            this.dgvCare.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCare_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Виды ухода";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRegionDel);
            this.panel3.Controls.Add(this.btnRegionChange);
            this.panel3.Controls.Add(this.btnRegionAdd);
            this.panel3.Location = new System.Drawing.Point(15, 496);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 42);
            this.panel3.TabIndex = 8;
            // 
            // btnRegionDel
            // 
            this.btnRegionDel.Location = new System.Drawing.Point(255, 9);
            this.btnRegionDel.Name = "btnRegionDel";
            this.btnRegionDel.Size = new System.Drawing.Size(75, 23);
            this.btnRegionDel.TabIndex = 2;
            this.btnRegionDel.Text = "Удалить";
            this.btnRegionDel.UseVisualStyleBackColor = true;
            this.btnRegionDel.Click += new System.EventHandler(this.BtnRegionDel_Click);
            // 
            // btnRegionChange
            // 
            this.btnRegionChange.Location = new System.Drawing.Point(135, 9);
            this.btnRegionChange.Name = "btnRegionChange";
            this.btnRegionChange.Size = new System.Drawing.Size(75, 23);
            this.btnRegionChange.TabIndex = 1;
            this.btnRegionChange.Text = "Изменить";
            this.btnRegionChange.UseVisualStyleBackColor = true;
            this.btnRegionChange.Click += new System.EventHandler(this.BtnRegionChange_Click);
            // 
            // btnRegionAdd
            // 
            this.btnRegionAdd.Location = new System.Drawing.Point(15, 9);
            this.btnRegionAdd.Name = "btnRegionAdd";
            this.btnRegionAdd.Size = new System.Drawing.Size(75, 23);
            this.btnRegionAdd.TabIndex = 0;
            this.btnRegionAdd.Text = "Добавить";
            this.btnRegionAdd.UseVisualStyleBackColor = true;
            this.btnRegionAdd.Click += new System.EventHandler(this.BtnRegionAdd_Click);
            // 
            // dgvRegion
            // 
            this.dgvRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegion.Location = new System.Drawing.Point(15, 384);
            this.dgvRegion.Name = "dgvRegion";
            this.dgvRegion.Size = new System.Drawing.Size(773, 115);
            this.dgvRegion.TabIndex = 7;
            this.dgvRegion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRegion_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Области леса";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvRegion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Справочник лесника";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCare)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTaskDel;
        private System.Windows.Forms.Button btnTaskChange;
        private System.Windows.Forms.Button btnTaskAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCareDel;
        private System.Windows.Forms.Button btnCareChange;
        private System.Windows.Forms.Button btnCareAdd;
        private System.Windows.Forms.DataGridView dgvCare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegionDel;
        private System.Windows.Forms.Button btnRegionChange;
        private System.Windows.Forms.Button btnRegionAdd;
        private System.Windows.Forms.DataGridView dgvRegion;
        private System.Windows.Forms.Label label3;
    }
}

