namespace Im2Loader
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_TemnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_temnFile = new System.Windows.Forms.TextBox();
            this.tbx_xmlFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_xmlSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_svetSelect = new System.Windows.Forms.Button();
            this.lbx_files = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.снятьВыделениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_run = new System.Windows.Forms.Button();
            this.opfDialog_im2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.opfDialogXML = new System.Windows.Forms.OpenFileDialog();
            this.tbx_defektFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_defektSelect = new System.Windows.Forms.Button();
            this.RB_temn_show = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.RB_Svet_Clear_show = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxKadr = new System.Windows.Forms.PictureBox();
            this.chartStb = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Tbx_report = new System.Windows.Forms.TextBox();
            this.opfDialogTxt = new System.Windows.Forms.OpenFileDialog();
            this.rb_svet_def_show = new System.Windows.Forms.RadioButton();
            this.rb_svet_temn_show = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_delKadr = new System.Windows.Forms.Button();
            this.lbx_delKadr = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKadr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TemnSelect
            // 
            this.btn_TemnSelect.BackColor = System.Drawing.Color.Gold;
            this.btn_TemnSelect.Location = new System.Drawing.Point(270, -1);
            this.btn_TemnSelect.Name = "btn_TemnSelect";
            this.btn_TemnSelect.Size = new System.Drawing.Size(123, 23);
            this.btn_TemnSelect.TabIndex = 0;
            this.btn_TemnSelect.Text = "Выбрать";
            this.btn_TemnSelect.UseVisualStyleBackColor = false;
            this.btn_TemnSelect.Click += new System.EventHandler(this.btn_TemnSelect_Click);
            this.btn_TemnSelect.MouseLeave += new System.EventHandler(this.btn_TemnSelect_MouseLeave);
            this.btn_TemnSelect.MouseHover += new System.EventHandler(this.btn_TemnSelect_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Темновой файл";
            // 
            // tbx_temnFile
            // 
            this.tbx_temnFile.Location = new System.Drawing.Point(15, 25);
            this.tbx_temnFile.Name = "tbx_temnFile";
            this.tbx_temnFile.ReadOnly = true;
            this.tbx_temnFile.Size = new System.Drawing.Size(378, 20);
            this.tbx_temnFile.TabIndex = 2;
            // 
            // tbx_xmlFile
            // 
            this.tbx_xmlFile.Location = new System.Drawing.Point(15, 70);
            this.tbx_xmlFile.Name = "tbx_xmlFile";
            this.tbx_xmlFile.ReadOnly = true;
            this.tbx_xmlFile.Size = new System.Drawing.Size(378, 20);
            this.tbx_xmlFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Xml файл";
            // 
            // btn_xmlSelect
            // 
            this.btn_xmlSelect.BackColor = System.Drawing.Color.Gold;
            this.btn_xmlSelect.Location = new System.Drawing.Point(270, 49);
            this.btn_xmlSelect.Name = "btn_xmlSelect";
            this.btn_xmlSelect.Size = new System.Drawing.Size(123, 23);
            this.btn_xmlSelect.TabIndex = 3;
            this.btn_xmlSelect.Text = "Выбрать";
            this.btn_xmlSelect.UseVisualStyleBackColor = false;
            this.btn_xmlSelect.Click += new System.EventHandler(this.btn_xmlSelect_Click);
            this.btn_xmlSelect.MouseLeave += new System.EventHandler(this.btn_TemnSelect_MouseLeave);
            this.btn_xmlSelect.MouseHover += new System.EventHandler(this.btn_TemnSelect_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Световые файлы";
            // 
            // btn_svetSelect
            // 
            this.btn_svetSelect.BackColor = System.Drawing.Color.Gold;
            this.btn_svetSelect.Location = new System.Drawing.Point(138, 179);
            this.btn_svetSelect.Name = "btn_svetSelect";
            this.btn_svetSelect.Size = new System.Drawing.Size(123, 23);
            this.btn_svetSelect.TabIndex = 6;
            this.btn_svetSelect.Text = "Выбрать";
            this.btn_svetSelect.UseVisualStyleBackColor = false;
            this.btn_svetSelect.Click += new System.EventHandler(this.btn_svetSelect_Click);
            this.btn_svetSelect.MouseLeave += new System.EventHandler(this.btn_TemnSelect_MouseLeave);
            this.btn_svetSelect.MouseHover += new System.EventHandler(this.btn_TemnSelect_MouseHover);
            // 
            // lbx_files
            // 
            this.lbx_files.ContextMenuStrip = this.contextMenuStrip1;
            this.lbx_files.FormattingEnabled = true;
            this.lbx_files.HorizontalScrollbar = true;
            this.lbx_files.Location = new System.Drawing.Point(15, 203);
            this.lbx_files.Name = "lbx_files";
            this.lbx_files.Size = new System.Drawing.Size(246, 212);
            this.lbx_files.TabIndex = 8;
            this.lbx_files.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbx_files_MouseClick);
            this.lbx_files.SelectedIndexChanged += new System.EventHandler(this.RB_temn_show_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снятьВыделениеToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            this.contextMenuStrip1.Text = "Удалить файл";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // снятьВыделениеToolStripMenuItem
            // 
            this.снятьВыделениеToolStripMenuItem.Name = "снятьВыделениеToolStripMenuItem";
            this.снятьВыделениеToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.снятьВыделениеToolStripMenuItem.Text = "Снять выделение";
            this.снятьВыделениеToolStripMenuItem.Click += new System.EventHandler(this.снятьВыделениеToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.Color.Gold;
            this.btn_run.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btn_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_run.Location = new System.Drawing.Point(12, 421);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(211, 33);
            this.btn_run.TabIndex = 9;
            this.btn_run.TabStop = false;
            this.btn_run.Text = "Обработать";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            this.btn_run.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btn_run.MouseLeave += new System.EventHandler(this.btn_TemnSelect_MouseLeave);
            this.btn_run.MouseHover += new System.EventHandler(this.btn_TemnSelect_MouseHover);
            // 
            // opfDialog_im2
            // 
            this.opfDialog_im2.Filter = "im2 files|*.im2";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "im2 File|*.im2";
            // 
            // opfDialogXML
            // 
            this.opfDialogXML.Filter = "XML Files|*.xml";
            // 
            // tbx_defektFile
            // 
            this.tbx_defektFile.Location = new System.Drawing.Point(15, 153);
            this.tbx_defektFile.Name = "tbx_defektFile";
            this.tbx_defektFile.ReadOnly = true;
            this.tbx_defektFile.Size = new System.Drawing.Size(378, 20);
            this.tbx_defektFile.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 45);
            this.label4.TabIndex = 11;
            this.label4.Text = "Файл дефектных элементов";
            // 
            // btn_defektSelect
            // 
            this.btn_defektSelect.BackColor = System.Drawing.Color.Gold;
            this.btn_defektSelect.Location = new System.Drawing.Point(270, 124);
            this.btn_defektSelect.Name = "btn_defektSelect";
            this.btn_defektSelect.Size = new System.Drawing.Size(123, 23);
            this.btn_defektSelect.TabIndex = 10;
            this.btn_defektSelect.Text = "Выбрать";
            this.btn_defektSelect.UseVisualStyleBackColor = false;
            this.btn_defektSelect.Click += new System.EventHandler(this.btn_defektSelect_Click);
            this.btn_defektSelect.MouseLeave += new System.EventHandler(this.btn_TemnSelect_MouseLeave);
            this.btn_defektSelect.MouseHover += new System.EventHandler(this.btn_TemnSelect_MouseHover);
            // 
            // RB_temn_show
            // 
            this.RB_temn_show.AutoSize = true;
            this.RB_temn_show.Location = new System.Drawing.Point(247, 449);
            this.RB_temn_show.Name = "RB_temn_show";
            this.RB_temn_show.Size = new System.Drawing.Size(76, 17);
            this.RB_temn_show.TabIndex = 14;
            this.RB_temn_show.TabStop = true;
            this.RB_temn_show.Text = "Темновой";
            this.RB_temn_show.UseVisualStyleBackColor = true;
            this.RB_temn_show.CheckedChanged += new System.EventHandler(this.RB_temn_show_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Отображение";
            // 
            // RB_Svet_Clear_show
            // 
            this.RB_Svet_Clear_show.AutoSize = true;
            this.RB_Svet_Clear_show.Location = new System.Drawing.Point(247, 472);
            this.RB_Svet_Clear_show.Name = "RB_Svet_Clear_show";
            this.RB_Svet_Clear_show.Size = new System.Drawing.Size(112, 17);
            this.RB_Svet_Clear_show.TabIndex = 17;
            this.RB_Svet_Clear_show.TabStop = true;
            this.RB_Svet_Clear_show.Text = "Световой чистый";
            this.RB_Svet_Clear_show.UseVisualStyleBackColor = true;
            this.RB_Svet_Clear_show.CheckedChanged += new System.EventHandler(this.RB_temn_show_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(399, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 661);
            this.panel1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxKadr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartStb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartStr, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 661);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // pictureBoxKadr
            // 
            this.pictureBoxKadr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pictureBoxKadr.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxKadr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxKadr.Image = global::Im2Loader.Properties.Resources.BackImage;
            this.pictureBoxKadr.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxKadr.Name = "pictureBoxKadr";
            this.pictureBoxKadr.Size = new System.Drawing.Size(800, 600);
            this.pictureBoxKadr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxKadr.TabIndex = 0;
            this.pictureBoxKadr.TabStop = false;
            this.pictureBoxKadr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxKadr_MouseClick);
            this.pictureBoxKadr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxKadr_MouseDown);
            this.pictureBoxKadr.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxKadr_MouseMove);
            this.pictureBoxKadr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxKadr_MouseUp);
            // 
            // chartStb
            // 
            chartArea1.AlignmentStyle = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.Position | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.PlotPosition)));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartStb.ChartAreas.Add(chartArea1);
            this.chartStb.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartStb.Legends.Add(legend1);
            this.chartStb.Location = new System.Drawing.Point(809, 3);
            this.chartStb.Name = "chartStb";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "ChartTemnStb";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "ChartSvetStb";
            this.chartStb.Series.Add(series1);
            this.chartStb.Series.Add(series2);
            this.chartStb.Size = new System.Drawing.Size(144, 600);
            this.chartStb.TabIndex = 4;
            this.chartStb.Text = "chartStb";
            // 
            // chartStr
            // 
            chartArea2.AlignmentStyle = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.Position | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.PlotPosition)));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 100F;
            chartArea2.InnerPlotPosition.Width = 100F;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartStr.ChartAreas.Add(chartArea2);
            this.chartStr.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartStr.Legends.Add(legend2);
            this.chartStr.Location = new System.Drawing.Point(3, 609);
            this.chartStr.Name = "chartStr";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "ChartTemnStr";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "ChartSvetStr";
            this.chartStr.Series.Add(series3);
            this.chartStr.Series.Add(series4);
            this.chartStr.Size = new System.Drawing.Size(800, 144);
            this.chartStr.TabIndex = 1;
            this.chartStr.Text = "chartStr";
            // 
            // Tbx_report
            // 
            this.Tbx_report.Location = new System.Drawing.Point(12, 537);
            this.Tbx_report.Multiline = true;
            this.Tbx_report.Name = "Tbx_report";
            this.Tbx_report.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Tbx_report.Size = new System.Drawing.Size(211, 124);
            this.Tbx_report.TabIndex = 19;
            // 
            // opfDialogTxt
            // 
            this.opfDialogTxt.Filter = "txt Files|*.txt";
            // 
            // rb_svet_def_show
            // 
            this.rb_svet_def_show.AutoSize = true;
            this.rb_svet_def_show.Location = new System.Drawing.Point(247, 495);
            this.rb_svet_def_show.Name = "rb_svet_def_show";
            this.rb_svet_def_show.Size = new System.Drawing.Size(146, 17);
            this.rb_svet_def_show.TabIndex = 20;
            this.rb_svet_def_show.TabStop = true;
            this.rb_svet_def_show.Text = "Световой без дефектов";
            this.rb_svet_def_show.UseVisualStyleBackColor = true;
            this.rb_svet_def_show.CheckedChanged += new System.EventHandler(this.RB_temn_show_CheckedChanged);
            // 
            // rb_svet_temn_show
            // 
            this.rb_svet_temn_show.AutoSize = true;
            this.rb_svet_temn_show.Location = new System.Drawing.Point(247, 518);
            this.rb_svet_temn_show.Name = "rb_svet_temn_show";
            this.rb_svet_temn_show.Size = new System.Drawing.Size(151, 17);
            this.rb_svet_temn_show.TabIndex = 21;
            this.rb_svet_temn_show.TabStop = true;
            this.rb_svet_temn_show.Text = "Световой без темнового";
            this.rb_svet_temn_show.UseVisualStyleBackColor = true;
            this.rb_svet_temn_show.CheckedChanged += new System.EventHandler(this.RB_temn_show_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 588);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Кадр";
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(229, 604);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(164, 45);
            this.trackBar1.TabIndex = 23;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 33);
            this.button1.TabIndex = 24;
            this.button1.TabStop = false;
            this.button1.Text = "Обработать с темновым";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gold;
            this.button2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 495);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 33);
            this.button2.TabIndex = 25;
            this.button2.TabStop = false;
            this.button2.Text = "Обработать с дефектным";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_delKadr
            // 
            this.btn_delKadr.Location = new System.Drawing.Point(232, 562);
            this.btn_delKadr.Name = "btn_delKadr";
            this.btn_delKadr.Size = new System.Drawing.Size(161, 23);
            this.btn_delKadr.TabIndex = 26;
            this.btn_delKadr.Text = "Удалить кадр";
            this.btn_delKadr.UseVisualStyleBackColor = true;
            this.btn_delKadr.Click += new System.EventHandler(this.btn_delKadr_Click);
            // 
            // lbx_delKadr
            // 
            this.lbx_delKadr.ContextMenuStrip = this.contextMenuStrip2;
            this.lbx_delKadr.FormattingEnabled = true;
            this.lbx_delKadr.Location = new System.Drawing.Point(267, 203);
            this.lbx_delKadr.Name = "lbx_delKadr";
            this.lbx_delKadr.Size = new System.Drawing.Size(126, 212);
            this.lbx_delKadr.TabIndex = 27;
            this.lbx_delKadr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbx_delKadr_MouseClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 638);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(181, 70);
            this.contextMenuStrip2.Text = "Удалить файл";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Снять выделение";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Удалить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbx_delKadr);
            this.Controls.Add(this.btn_delKadr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rb_svet_temn_show);
            this.Controls.Add(this.rb_svet_def_show);
            this.Controls.Add(this.Tbx_report);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.RB_Svet_Clear_show);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RB_temn_show);
            this.Controls.Add(this.tbx_defektFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_defektSelect);
            this.Controls.Add(this.lbx_files);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_svetSelect);
            this.Controls.Add(this.tbx_xmlFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_xmlSelect);
            this.Controls.Add(this.tbx_temnFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_TemnSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка файлов";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKadr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TemnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_temnFile;
        private System.Windows.Forms.TextBox tbx_xmlFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_xmlSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_svetSelect;
        private System.Windows.Forms.ListBox lbx_files;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.OpenFileDialog opfDialog_im2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog opfDialogXML;
        private System.Windows.Forms.TextBox tbx_defektFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_defektSelect;
        private System.Windows.Forms.RadioButton RB_temn_show;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RB_Svet_Clear_show;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem снятьВыделениеToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxKadr;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStb;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStr;
        private System.Windows.Forms.TextBox Tbx_report;
        private System.Windows.Forms.OpenFileDialog opfDialogTxt;
        private System.Windows.Forms.RadioButton rb_svet_def_show;
        private System.Windows.Forms.RadioButton rb_svet_temn_show;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_delKadr;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ListBox lbx_delKadr;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

