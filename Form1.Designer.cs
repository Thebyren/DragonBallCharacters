namespace DragonBallCharacters
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            GridCharacters = new DataGridView();
            buttonCargaData = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            id_ch = new TextBox();
            name_ch = new TextBox();
            power_ch = new NumericUpDown();
            raza_ch = new ComboBox();
            buttonInsertar = new Button();
            buttonBuscar = new Button();
            fecha_ch = new DateTimePicker();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            history = new RichTextBox();
            search_params = new TextBox();
            filter = new ComboBox();
            DeleteB = new Button();
            ((System.ComponentModel.ISupportInitialize)GridCharacters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)power_ch).BeginInit();
            SuspendLayout();
            // 
            // GridCharacters
            // 
            GridCharacters.BackgroundColor = Color.FromArgb(47, 179, 202);
            GridCharacters.BorderStyle = BorderStyle.None;
            GridCharacters.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            GridCharacters.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            GridCharacters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCharacters.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.PaleTurquoise;
            dataGridViewCellStyle1.Font = new Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "vacio";
            dataGridViewCellStyle1.SelectionBackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridCharacters.DefaultCellStyle = dataGridViewCellStyle1;
            GridCharacters.GridColor = SystemColors.Info;
            GridCharacters.Location = new Point(26, 290);
            GridCharacters.Name = "GridCharacters";
            GridCharacters.RowHeadersWidth = 51;
            GridCharacters.RowTemplate.Height = 24;
            GridCharacters.Size = new Size(792, 271);
            GridCharacters.TabIndex = 0;
            // 
            // buttonCargaData
            // 
            buttonCargaData.Location = new Point(841, 519);
            buttonCargaData.Name = "buttonCargaData";
            buttonCargaData.Size = new Size(346, 42);
            buttonCargaData.TabIndex = 1;
            buttonCargaData.Text = "Cargar";
            buttonCargaData.UseVisualStyleBackColor = true;
            buttonCargaData.Click += ButtonCargaData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sitka Small", 12F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(75, 22);
            label1.Name = "label1";
            label1.Size = new Size(29, 24);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sitka Small", 12F);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(35, 69);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sitka Small", 12F);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(62, 163);
            label3.Name = "label3";
            label3.Size = new Size(48, 24);
            label3.TabIndex = 4;
            label3.Text = "Raza";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Sitka Small", 12F);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(9, 210);
            label4.Name = "label4";
            label4.Size = new Size(129, 24);
            label4.TabIndex = 5;
            label4.Text = "Nivel de Poder";
            // 
            // id_ch
            // 
            id_ch.BackColor = Color.Azure;
            id_ch.Location = new Point(144, 24);
            id_ch.Name = "id_ch";
            id_ch.ReadOnly = true;
            id_ch.Size = new Size(152, 23);
            id_ch.TabIndex = 1;
            // 
            // name_ch
            // 
            name_ch.BackColor = Color.Azure;
            name_ch.Location = new Point(144, 71);
            name_ch.Name = "name_ch";
            name_ch.Size = new Size(152, 23);
            name_ch.TabIndex = 2;
            // 
            // power_ch
            // 
            power_ch.BackColor = Color.Azure;
            power_ch.Location = new Point(144, 212);
            power_ch.Maximum = new decimal(new int[] { 1241513983, 370409800, 542101, 0 });
            power_ch.Name = "power_ch";
            power_ch.Size = new Size(152, 23);
            power_ch.TabIndex = 5;
            // 
            // raza_ch
            // 
            raza_ch.BackColor = Color.Azure;
            raza_ch.FormattingEnabled = true;
            raza_ch.Location = new Point(144, 165);
            raza_ch.Name = "raza_ch";
            raza_ch.Size = new Size(152, 23);
            raza_ch.TabIndex = 4;
            // 
            // buttonInsertar
            // 
            buttonInsertar.Location = new Point(26, 248);
            buttonInsertar.Name = "buttonInsertar";
            buttonInsertar.Size = new Size(270, 36);
            buttonInsertar.TabIndex = 11;
            buttonInsertar.Text = "Insertar/editar";
            buttonInsertar.UseVisualStyleBackColor = true;
            buttonInsertar.Click += ButtonInsertar_Click;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(1124, 22);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(63, 26);
            buttonBuscar.TabIndex = 12;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += ButtonBuscar_Click;
            // 
            // fecha_ch
            // 
            fecha_ch.CalendarMonthBackground = Color.Azure;
            fecha_ch.CalendarTitleBackColor = Color.Aquamarine;
            fecha_ch.Format = DateTimePickerFormat.Short;
            fecha_ch.Location = new Point(144, 118);
            fecha_ch.Name = "fecha_ch";
            fecha_ch.ShowUpDown = true;
            fecha_ch.Size = new Size(152, 23);
            fecha_ch.TabIndex = 3;
            fecha_ch.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Sitka Small", 12F);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(56, 116);
            label5.Name = "label5";
            label5.Size = new Size(53, 24);
            label5.TabIndex = 15;
            label5.Text = "fecha";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "OpenFile";
            openFileDialog1.Title = "selecione imagen de perfil";
            // 
            // history
            // 
            history.BackColor = Color.LightCyan;
            history.BorderStyle = BorderStyle.None;
            history.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            history.ForeColor = Color.Black;
            history.Location = new Point(302, 22);
            history.Name = "history";
            history.Size = new Size(516, 262);
            history.TabIndex = 17;
            history.Text = "";
            // 
            // search_params
            // 
            search_params.Location = new Point(841, 24);
            search_params.Name = "search_params";
            search_params.Size = new Size(277, 23);
            search_params.TabIndex = 18;
            search_params.TextChanged += TextBox1_TextChanged;
            // 
            // filter
            // 
            filter.FormattingEnabled = true;
            filter.Location = new Point(841, 55);
            filter.Name = "filter";
            filter.Size = new Size(346, 23);
            filter.TabIndex = 19;
            // 
            // DeleteB
            // 
            DeleteB.Location = new Point(841, 458);
            DeleteB.Name = "DeleteB";
            DeleteB.Size = new Size(346, 42);
            DeleteB.TabIndex = 20;
            DeleteB.Text = "Borrar";
            DeleteB.UseVisualStyleBackColor = true;
            DeleteB.Click += DeleteB_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            BackgroundImage = Properties.Resources._7cebf5d0f6b0fb6beb008c14b182af3b;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1199, 585);
            Controls.Add(DeleteB);
            Controls.Add(filter);
            Controls.Add(search_params);
            Controls.Add(history);
            Controls.Add(label5);
            Controls.Add(fecha_ch);
            Controls.Add(buttonBuscar);
            Controls.Add(buttonInsertar);
            Controls.Add(raza_ch);
            Controls.Add(power_ch);
            Controls.Add(name_ch);
            Controls.Add(id_ch);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonCargaData);
            Controls.Add(GridCharacters);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GridCharacters).EndInit();
            ((System.ComponentModel.ISupportInitialize)power_ch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView GridCharacters;
        private System.Windows.Forms.Button buttonCargaData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id_ch;
        private System.Windows.Forms.TextBox name_ch;
        private System.Windows.Forms.NumericUpDown power_ch;
        private System.Windows.Forms.ComboBox raza_ch;
        private System.Windows.Forms.Button buttonInsertar;
        private System.Windows.Forms.Button buttonBuscar;
        private DateTimePicker fecha_ch;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private RichTextBox history;
        private TextBox search_params;
        private ComboBox filter;
        private Button DeleteB;
    }
}

