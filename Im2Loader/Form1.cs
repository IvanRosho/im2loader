using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Im2Loader
{
    public partial class Form1 : Form
    {
        string temnFile;
        string xmlFile;
        string defectFile;
        string[] files;
        int[,] temnKadr;
        int[,] kadrSvet;
        /// <summary>
        /// [0][x,y] - пиксель    
        /// [1][x,-1] - столбец, вторая точка - границы
        /// [2][-1,y] - строка, вторая точка - границы
        /// </summary>
        List<List<Point[]>> defect;
        List<List<int>> deleteKadr; //список на световые файлы, которые удаляем
        List<int> deleteTemnKadr; //список удалемых кадров из темнового
        int w,h;
        string lbx;
        Pen zoomBorder;
        ForZoom zoom;
        public Form1()
        {
            InitializeComponent();
            zoomBorder = new Pen(Color.Green);
            deleteKadr = new List<List<int>>();
            zoom = new ForZoom();
            zoom.zoom = false;
        }
        public int[,] LoadFile(string _file, bool temn = false, bool dfk = false) {
            int[,] kadr;
            using (BinaryReader reader = new BinaryReader(File.Open(_file, FileMode.Open))) {
                reader.BaseStream.Position = 500;
                int ww = reader.ReadUInt16(); int hh = reader.ReadUInt16(); //читаем размеры
                if (w == 0 || h == 0) { //Если размеры еще не распарсены, то парсим их
                    w = ww;
                    h = hh;
                }
                //проверочки
                //if (defektKadr == null) defektKadr = new int[w, h];
                if (ww != w || hh != h) throw new FileLoadException("Размер кадра в файле \""+_file+"\" отличается от иных файлов");
                if (((reader.BaseStream.Length - 512.0) / (w * h * 2.0) % 1)!=0.0) throw new FileLoadException("Файл \"" + _file + "\" поврежден!");
                kadr = new int[w, h];
                int kadri = (int)((reader.BaseStream.Length-512)/(w*h*2)); //сколько кадров
                reader.BaseStream.Position = 512; //приступаем к чтению
                for (int k = 0; k < kadri; k++)
                {
                    if (temnKadr!=null && _file == temnFile && deleteTemnKadr.Contains(kadri + 1)) continue; //пропускаем если темновой и есть удаляемый кадр
                    byte[] arr = reader.ReadBytes(w * h * 2); //читаем сразу весь кусок
                    for (int j = 0; j < w; j++)
                        for (int i = 0; i < h; i++)
                        {
                            int p = BitConverter.ToUInt16(arr, (i * h + j) * 2);//парсим массив в памяти, суммируем кадры
                            if (temn && temnKadr != null)
                            {
                                p -= temnKadr[j, i];
                                p = p < 0 ? 0 : p;
                            }
                            kadr[j, i] += p;
                        }
                }
                if (!string.IsNullOrEmpty(temnFile) && deleteTemnKadr!=null && _file == temnFile) kadri -= deleteTemnKadr.Count(); //если темновой, вычитаем из кадров количество удаляемых кадров, мы же их пропустили
                if (files!=null && files.Contains(_file)) kadri -= deleteKadr[Array.IndexOf(files,_file)].Count(); //если файл содержится в световых, то же самое
                for (int j = 0; j < w; j++)
                    for (int i = 0; i < h; i++) kadr[j, i] /= kadri; //вычисляем средний кадр
            }
            if (dfk && defect != null)
            {
                foreach (Point[] p in defect[0])
                { //корректируем пиксели
                    int pix = 0; int col = 0;
                    if (p[0].X != 0) { pix += kadr[p[0].X - 1, p[0].Y]; col++; }     //тут, если пиксел на краю кадра, то вычисляем среднее от реальных соседей
                    if (p[0].X != w - 1) { pix += kadr[p[0].X + 1, p[0].Y]; col++; }
                    if (p[0].Y != 0) { pix += kadr[p[0].X, p[0].Y - 1]; col++; }
                    if (p[0].Y != h - 1) { pix += kadr[p[0].X, p[0].Y + 1]; col++; }
                    kadr[p[0].X, p[0].Y] = pix / col;
                }
                foreach (Point[] p in defect[1])
                { //корректируем столбцы
                    for (int i = p[1].X; i <= p[1].Y; i++) kadr[p[0].X, i] = (kadr[p[0].X + 1, i] + kadr[p[0].X - 1, i]) / 2;
                }
                foreach (Point[] p in defect[2])
                { //корректируем строки
                    for (int j = p[1].X; j <= p[1].Y; j++) kadr[j, p[0].Y] = (kadr[j, p[0].Y + 1] + kadr[j, p[0].Y - 1]) / 2;
                }
            }
            return kadr; 
        }
        public int[,] LoadKadr(string _file, int k=1, bool temn = false, bool dfk = false)
        {
            int[,] kadr;
            using (BinaryReader reader = new BinaryReader(File.Open(_file, FileMode.Open)))
            {
                reader.BaseStream.Position = 500;
                int ww = reader.ReadUInt16(); int hh = reader.ReadUInt16(); //читаем размеры
                if (w == 0 || h == 0)
                { //Если размеры еще не распарсены, то парсим их
                    w = ww;
                    h = hh;
                }
                //проверочки
                if (ww != w || hh != h) throw new FileLoadException("Размер кадра в файле \"" + _file + "\" отличается от иных файлов");
                if (((reader.BaseStream.Length - 512.0) / (w * h * 2.0) % 1) != 0.0) throw new FileLoadException("Файл \"" + _file + "\" поврежден!");
                kadr = new int[w, h];
                int kadri = (int)((reader.BaseStream.Length - 512) / (w * h * 2)); //сколько кадров
                reader.BaseStream.Position = 512+(w*h*2*(k-1)); //приступаем к чтению
                byte[] arr = reader.ReadBytes(w * h * 2); //читаем сразу весь кусок
                for (int j = 0; j < w; j++)
                    for (int i = 0; i < h; i++)
                    {
                        int p = BitConverter.ToUInt16(arr, (i * h + j) * 2);//парсим массив в памяти, суммируем кадры
                        if (temn && temnKadr != null)
                        {
                            p -= temnKadr[j, i];
                            p = p < 0 ? 0 : p;
                        }
                        kadr[j, i] += p;
                    }
            }
            if (dfk && defect != null)
            {
                foreach (Point[] p in defect[0])
                { //корректируем пиксели
                    int pix = 0; int col = 0;
                    if (p[0].X != 0) { pix += kadr[p[0].X - 1, p[0].Y]; col++; }     //тут, если пиксел на краю кадра, то вычисляем среднее от реальных соседей
                    if (p[0].X != w - 1) { pix += kadr[p[0].X + 1, p[0].Y]; col++; }
                    if (p[0].Y != 0) { pix += kadr[p[0].X, p[0].Y - 1]; col++; }
                    if (p[0].Y != h - 1) { pix += kadr[p[0].X, p[0].Y + 1]; col++; }
                    kadr[p[0].X, p[0].Y] = pix / col;
                }
                foreach (Point[] p in defect[1])
                { //корректируем столбцы
                    for (int i = p[1].X; i <= p[1].Y; i++) kadr[p[0].X, i] = (kadr[p[0].X + 1, i] + kadr[p[0].X - 1, i]) / 2;
                }
                foreach (Point[] p in defect[2])
                { //корректируем строки
                    for (int j = p[1].X; j <= p[1].Y; j++) kadr[j, p[0].Y] = (kadr[j, p[0].Y + 1] + kadr[j, p[0].Y - 1]) / 2;
                }
            }
            return kadr;
        }
        public int GetKadrCol(string _file) {
            int kadri = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(_file, FileMode.Open)))
            {
                kadri = (int)((reader.BaseStream.Length - 512) / (w * h * 2)); //сколько кадров
            }
            return kadri;
        }
        private void run(bool _def = false)
        {
            try
            {
                progressBar1.Maximum = lbx_files.Items.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Visible = true;
                //проверочка
                if (string.IsNullOrEmpty(temnFile) || string.IsNullOrEmpty(xmlFile) || files == null || files.Count() == 0)
                    throw new ArgumentException("Не выбраны файлы!");
                w = 0; h = 0; //обнуляем
                              //if (!string.IsNullOrEmpty(defectFile)) defektKadr = LoadFile(defectFile); //грузим файлы
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(xmlFile); //грузим иксэмэльку(зачем?)

                string newFile = Path.GetFileNameWithoutExtension(temnFile) + "_sr.im2";
                newFile = Path.Combine(Path.GetDirectoryName(temnFile), newFile); //путь до нового файла
                SaveFile(newFile, LoadFile(temnFile));
                SaveFile(newFile, LoadFile(temnFile, false, true));
                foreach (string file in files)
                { //по каждому файлу
                    newFile = Path.GetFileNameWithoutExtension(file) + "_sr.im2";
                    newFile = Path.Combine(Path.GetDirectoryName(file), newFile); //путь до нового файла
                    progressBar1.PerformStep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка обработки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //defektKadr = null;
                progressBar1.Visible = false;
                
            }
        }
        private void SaveFile(string newFile,int[,] kadr)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(newFile)))
            {
                byte[] head = new byte[512];
                for (int i = 0; i < 512; i++)
                { //пишем данные
                    if (i == 500)
                    {
                        byte[] W = BitConverter.GetBytes((short)w);
                        //Array.Reverse(W);
                        byte[] H = BitConverter.GetBytes((short)h);
                        //Array.Reverse(H);
                        head[i] = W[0]; head[i + 1] = W[1]; head[i + 2] = H[0]; head[i + 3] = H[1];
                        i += 4; //записали же 4 байтика
                    }
                    else head[i] = (byte)32;
                }
                writer.Write(head); //пишем шапку
                head = new byte[w * h * 2]; //готовим кадр
                using (MemoryStream stream = new MemoryStream(head))
                {
                    for (int j = 0; j < w; j++)
                        for (int i = 0; i < h; i++) stream.Write(BitConverter.GetBytes((ushort)kadr[j, i]), 0, 2);
                }
                writer.Write(head); //пишем кадр одним куском
            }
        }
        private void RB_temn_show_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = true;
            trackBar1.Value = 1;
            trackBar1_Scroll(sender, e);
            zoom.zoom = false;
            foreach (var chart in chartStr.Series) chart.Points.Clear();
            foreach (var chart in chartStb.Series) chart.Points.Clear(); //очистили графики
            if (RB_temn_show.Checked)
            {           //Учил ли ты тернарный оператор на ночь, Дездемона?
                trackBar1.Maximum=GetKadrCol(temnFile);
                lbx_delKadr.Items.Clear();
                foreach (var item in deleteTemnKadr)
                {
                    lbx_delKadr.Items.Add(item); 
                }
                zoom.picture = temnKadr;
                return;
            }
            if (RB_Svet_Clear_show.Checked || rb_svet_def_show.Checked || rb_svet_temn_show.Checked)
            {
                if (lbx_files.SelectedIndex == -1)
                {
                    pictureBoxKadr.Image = pictureBoxKadr.BackgroundImage;
                    kadrSvet = null;
                    return;
                }
                lbx_delKadr.Items.Clear();
                foreach (var item in deleteKadr[lbx_files.SelectedIndex])
                {
                    lbx_delKadr.Items.Add(item); 
                }
                trackBar1.Maximum = GetKadrCol(lbx_files.SelectedItem as string);
                zoom.picture = kadrSvet;
                return;
            }
        }
        public Bitmap ConvertArrayToBtm(int[,] _array) {
            Bitmap temp = new Bitmap(_array.GetLength(0),_array.GetLength(1)); //новый битмап по размеру массива
            int min = _array.Cast<int>().Min();
            int max = _array.Cast<int>().Max(); //LINQ IS THE POWER!!!
            for (int j = 0; j < temp.Width; j++)
                for (int i = 0; i < temp.Height; i++) {
                    byte pix = (byte)(((double)_array[j, i] - min) / (double)(max - min) * 255.0); //узнали значение пиксела в диапазоне 0..255
                    temp.SetPixel(j,i,Color.FromArgb(pix,pix,pix)); //установили значение в GrayScale
                }
            return temp;
        }
        void MakeRep(int _x, int _y) {
            string rep = "";
            rep += $"Клик Х:{_x} Y:{_y}\r\nЗначения пиксел:\r\n";
            if (string.IsNullOrEmpty(temnFile)) rep += $"темновой пиксел:{temnKadr[_x,_y]}\r\n";
            //if (string.IsNullOrEmpty(defectFile)) rep += $"дефектный пиксел:{defektKadr[_x, _y]}\r\n";
            if (lbx_files.SelectedIndex!=-1) rep += $"световой пиксел:{kadrSvet[_x, _y]}\r\n";
            rep += $"Статистика\r\nmin\tmax\r\n";
            if (temnKadr != null) {
                int minstr, minstb, maxstr, maxstb;
                minstr = (int)(chartStr.Series["ChartTemnStr"].Points.Select(s => s.YValues.Min()).Min());
                maxstr = (int)(chartStr.Series["ChartTemnStr"].Points.Select(s => s.YValues.Max()).Max());
                minstb = (int)(chartStb.Series["ChartTemnStb"].Points.Select(s => s.XValue).Min());
                maxstb = (int)(chartStb.Series["ChartTemnStb"].Points.Select(s => s.XValue).Max());
                rep += $"темн стр\r\n{minstr}\t{maxstr}\r\nтемн стб\r\n{minstb}\t{maxstb}\r\n";
            }
            if (kadrSvet != null) {
                int minstr, minstb, maxstr, maxstb;
                minstr = (int)(chartStr.Series["ChartSvetStr"].Points.Select(s => s.YValues.Min()).Min());
                maxstr = (int)(chartStr.Series["ChartSvetStr"].Points.Select(s => s.YValues.Max()).Max());
                minstb = (int)(chartStb.Series["ChartSvetStb"].Points.Select(s => s.XValue).Min());
                maxstb = (int)(chartStb.Series["ChartSvetStb"].Points.Select(s => s.XValue).Max());
                rep += $"свет стр\r\n{minstr}\t{maxstr}\r\nсвет стб\r\n{minstb}\t{maxstb}";
            }
            Tbx_report.Text = rep;
        }

        #region buttons
        private void btn_TemnSelect_Click(object sender, EventArgs e)
        {
            opfDialog_im2.Multiselect = false;
            if (opfDialog_im2.ShowDialog() == DialogResult.OK)
            {
                temnFile = opfDialog_im2.FileName;
                tbx_temnFile.Text = temnFile;
                temnKadr = LoadFile(temnFile, false, !string.IsNullOrEmpty(defectFile));
                deleteTemnKadr = new List<int>();
            }
        }
        private void btn_xmlSelect_Click(object sender, EventArgs e)
        {
            if (opfDialogXML.ShowDialog() == DialogResult.OK) xmlFile = opfDialogXML.FileName;
            tbx_xmlFile.Text = xmlFile;
        }
        private void btn_defektSelect_Click(object sender, EventArgs e)
        {
            if (opfDialogTxt.ShowDialog() == DialogResult.OK)
            {
                defectFile = opfDialogTxt.FileName;
                tbx_defektFile.Text = defectFile;
                //defektKadr = LoadFile(defectFile);
                using (StreamReader reader = File.OpenText(defectFile))
                {
                    defect = new List<List<Point[]>>();
                    defect.Add(new List<Point[]>()); defect.Add(new List<Point[]>()); defect.Add(new List<Point[]>());
                    while (!reader.EndOfStream)
                    {
                        string[] str = reader.ReadLine().Split(','); //по идее всегда должен давать string[2 или 4]
                        if (str.Length == 2) //Если только 2 числа, значит указан пиксель
                            defect[0].Add(new Point[2] { new Point(int.Parse(str[0]) - 1, int.Parse(str[1]) - 1), Point.Empty });
                        else
                        if (String.IsNullOrEmpty(str[0])) //указали дефектную строку
                            defect[2].Add(new Point[2] {new Point( -1, int.Parse(str[1]) - 1),new Point(int.Parse(str[2])-1, int.Parse(str[3])-1) });
                        else //или столбец
                        defect[1].Add(new Point[2] { new Point(int.Parse(str[0]) - 1,-1), new Point(int.Parse(str[2]) - 1, int.Parse(str[3]) - 1) });
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                progressBar1.Maximum = lbx_files.Items.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Visible = true;
                //проверочка
                if (string.IsNullOrEmpty(temnFile) || string.IsNullOrEmpty(xmlFile) || files == null || files.Count() == 0)
                    throw new ArgumentException("Не выбраны файлы!");
                w = 0; h = 0; //обнуляем
                              //if (!string.IsNullOrEmpty(defectFile)) defektKadr = LoadFile(defectFile); //грузим файлы
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(xmlFile); //грузим иксэмэльку(зачем?)

                string newFile = Path.GetFileNameWithoutExtension(temnFile) + "_sr.im2";
                newFile = Path.Combine(Path.GetDirectoryName(temnFile), newFile); //путь до нового файла
                SaveFile(newFile, LoadFile(temnFile));
                foreach (string file in files)
                { //по каждому файлу
                    newFile = Path.GetFileNameWithoutExtension(file) + "_kor.im2";
                    newFile = Path.Combine(Path.GetDirectoryName(file), newFile); //путь до нового файла
                    SaveFile(newFile, LoadFile(file, true, false));
                    progressBar1.PerformStep();
                }
                this.Enabled = true;
                progressBar1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка обработки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //defektKadr = null;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                progressBar1.Maximum = lbx_files.Items.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Visible = true;
                //проверочка
                if (string.IsNullOrEmpty(temnFile) || string.IsNullOrEmpty(xmlFile) || files == null || files.Count() == 0)
                    throw new ArgumentException("Не выбраны файлы!");
                w = 0; h = 0; //обнуляем
                              //if (!string.IsNullOrEmpty(defectFile)) defektKadr = LoadFile(defectFile); //грузим файлы
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(xmlFile); //грузим иксэмэльку(зачем?)


                string newFile = Path.GetFileNameWithoutExtension(temnFile) + "_sr.im2";
                newFile = Path.GetFileNameWithoutExtension(temnFile) + "_kord.im2";
                newFile = Path.Combine(Path.GetDirectoryName(temnFile), newFile); //путь до нового файла
                SaveFile(newFile, LoadFile(temnFile, false, true));
                foreach (string file in files)
                { //по каждому файлу
                    newFile = Path.GetFileNameWithoutExtension(file) + "_kord.im2";
                    newFile = Path.Combine(Path.GetDirectoryName(file), newFile); //путь до нового файла
                    SaveFile(newFile, LoadFile(file, true, true));
                    progressBar1.PerformStep();
                }
                this.Enabled = true;
                progressBar1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка обработки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //defektKadr = null;
            }
        }
        private void btn_svetSelect_Click(object sender, EventArgs e)
        {
            opfDialog_im2.Multiselect = true;
            if (opfDialog_im2.ShowDialog() == DialogResult.OK) files = opfDialog_im2.FileNames;
            lbx_files.Items.Clear();
            lbx_files.Items.AddRange(files);
            foreach (string s in files) deleteKadr.Add(new List<int>());
        }
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            //run(true);
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            run();
            this.Enabled = true;
        }
        private void btn_delKadr_Click(object sender, EventArgs e)
        {
            if (RB_temn_show.Checked) deleteTemnKadr.Add(trackBar1.Value);
            else if (lbx_files.SelectedIndex!=-1) deleteKadr[lbx_files.SelectedIndex].Add(trackBar1.Value);
        }
        #endregion

        #region GUI
        private void btn_TemnSelect_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Green;
        }
        private void btn_TemnSelect_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Gold;
        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void удалитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbx_files.SelectedIndex == -1) return;
            lbx_files.Items.Remove(lbx_files.SelectedItem);
        }
        private void снятьВыделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbx_files.SelectedIndex = -1;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (RB_temn_show.Checked)
            {           //Учил ли ты тернарный оператор на ночь, Дездемона?
                pictureBoxKadr.Image = temnKadr != null ? ConvertArrayToBtm(LoadKadr(temnFile, trackBar1.Value, false, true)) : pictureBoxKadr.BackgroundImage;

                zoom.bitmap = pictureBoxKadr.Image as Bitmap;
                return;
            }
            if (RB_Svet_Clear_show.Checked)
            {
                if (lbx_files.SelectedIndex == -1)
                {
                    pictureBoxKadr.Image = pictureBoxKadr.BackgroundImage;
                    kadrSvet = null;
                    return;
                }
                kadrSvet = LoadKadr(lbx_files.SelectedItem as string, trackBar1.Value);
                pictureBoxKadr.Image = ConvertArrayToBtm(kadrSvet);
            }
            if (rb_svet_def_show.Checked)
            {
                if (lbx_files.SelectedIndex == -1)
                {
                    pictureBoxKadr.Image = pictureBoxKadr.BackgroundImage;
                    kadrSvet = null;
                    return;
                }
                kadrSvet = LoadKadr(lbx_files.SelectedItem as string, trackBar1.Value, false, true);
                pictureBoxKadr.Image = ConvertArrayToBtm(kadrSvet);
            }
            if (rb_svet_temn_show.Checked)
            {
                if (lbx_files.SelectedIndex == -1)
                {
                    pictureBoxKadr.Image = pictureBoxKadr.BackgroundImage;
                    kadrSvet = null;
                    return;
                }
                kadrSvet = LoadKadr(lbx_files.SelectedItem as string, trackBar1.Value, true, true);
                pictureBoxKadr.Image = ConvertArrayToBtm(kadrSvet);
            }
            zoom.bitmap = pictureBoxKadr.Image as Bitmap;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) // Ctrl-R run
            {
                e.SuppressKeyPress = true;
                btn_run_Click(sender, new EventArgs());
            }
        }
        private void lbx_files_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void lbx_delKadr_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pointer = lbx_files.SelectedIndex;
                lbx_files.Items.RemoveAt(pointer);
            deleteKadr.RemoveAt(pointer);
        }

        #endregion

        #region picturebox
        private void pictureBoxKadr_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoom.picture == null) return;
            int l = zoom.x1; int r = e.X; int t = zoom.y1; int b = e.Y;
            //graf.Clear(Color.FromArgb(255,0,0,0));
            //if (e.X < 0 || e.Y < 0 || e.X >= picture.GetLength(0) || e.Y >= picture.GetLength(1)) return;
            if (e.X < 0) r = 0;
            if (e.Y < 0) b = 0;
            if (e.X >= zoom.picture.GetLength(0)) r = zoom.picture.GetLength(0) - 1;
            if (e.Y >= zoom.picture.GetLength(1)) b = zoom.picture.GetLength(1) - 1;
            this.Text = String.Format("строка {0} столбец {1} значение пиксела {2}", "", b + 1, r + 1, zoom.picture[r, b]);
            if (zoom.zoom == true)
            {
                try
                {
                    this.Text = String.Format("строка {0} столбец {1} значение пиксела {2}", 
                            Math.Round(zoom.zy1 + zoom.delta_y * b + 1, 2), Math.Round(zoom.zx1 + zoom.delta_x * r + 1, 2),
                            zoom.picture[(int)(zoom.zx1 + zoom.delta_x * r), (int)(zoom.zy1 + zoom.delta_y * b)]);
                }
                catch (IndexOutOfRangeException)
                {
                    this.Text = String.Format("строка {0} столбец {1}", 
                            Math.Round(zoom.zy1 + zoom.delta_y * b + 1, 2), Math.Round(zoom.zx1 + zoom.delta_x * r + 1, 2));
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left && zoom.zoom == false)
            {
                pictureBoxKadr.Image = zoom.bitmap;
                Bitmap bb = new Bitmap(pictureBoxKadr.Image);
                pictureBoxKadr.Image = bb;
                Graphics graf = Graphics.FromImage(pictureBoxKadr.Image);
                if (l > r) { int x = l; l = r; r = x; }
                if (t > b) { int x = t; t = b; b = x; }
                if (l < 0) l = 0; if (r >= w) r = w - 1;
                if (t < 0) t = 0; if (b >= h) b = h - 1;
                using (Pen pen = new Pen(Color.Green))
                {
                    graf.DrawLine(pen, l, t, r, t);
                    graf.DrawLine(pen, r, t, r, b);
                    graf.DrawLine(pen, r, b, l, b);
                    graf.DrawLine(pen, l, b, l, t);
                }
                pictureBoxKadr.Invalidate();
            }
        }
        private void pictureBoxKadr_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxKadr_MouseUp(object sender, MouseEventArgs e)
        {
            if (temnKadr == null && kadrSvet == null) return;
            if (temnKadr == null) temnKadr = kadrSvet;
            if (kadrSvet == null) kadrSvet = temnKadr;
            zoom.x2 = e.X;
            zoom.y2 = e.Y;
            if (e.X < 0) zoom.x2 = 0;
            if (e.Y < 0) zoom.y2 = 0;
            if (e.X > w) zoom.x2 = w - 1;
            if (e.Y > h) zoom.y2 = h - 1;
            if ((zoom.x1 != zoom.x2 || zoom.y1 != zoom.y2) && zoom.zoom == false)
            {
                zoom.zoom = true;
                zooming_pixelisation();
                return;
            }
            if (zoom.zoom == false)
            {
                #region not zoom
                chartStb.Series[0].Points.Clear();
                chartStr.Series[0].Points.Clear();
                chartStb.Series[1].Points.Clear();
                chartStr.Series[1].Points.Clear();
                zoom.xmin = 16000;
                zoom.xmax = 0;
                zoom.ymin = 16000;
                zoom.ymax = 0;
                for (int i = 0; i < h; i++)
                {
                    chartStb.Series[0].Points.AddXY(kadrSvet[zoom.x2, i], h - i);
                    chartStb.Series[1].Points.AddXY(temnKadr[zoom.x2, i], h - i);
                    if (zoom.ymin > zoom.picture[zoom.x2, i]) zoom.ymin = zoom.picture[zoom.x2, i];
                    if (zoom.ymax < zoom.picture[zoom.x2, i]) zoom.ymax = zoom.picture[zoom.x2, i];
                }
                for (int i = 0; i < w; i++)
                {
                    chartStr.Series[0].Points.AddXY(i + 1, kadrSvet[i, zoom.y2]);
                    chartStr.Series[1].Points.AddXY(i + 1, temnKadr[i, zoom.y2]);
                    if (zoom.xmin > zoom.picture[i, zoom.y2]) zoom.xmin = zoom.picture[i, zoom.y2];
                    if (zoom.xmax < zoom.picture[i, zoom.y2]) zoom.xmax = zoom.picture[i, zoom.y2];
                }
                chartStb.ChartAreas[0].AxisY.Minimum = 0;
                chartStb.ChartAreas[0].AxisY.Maximum = h;
                chartStb.ChartAreas[0].AxisX.Minimum = 0;
                chartStb.ChartAreas[0].AxisX.Maximum = zoom.ymax;
                chartStr.ChartAreas[0].AxisY.Minimum = zoom.xmin;
                chartStr.ChartAreas[0].AxisY.Maximum = zoom.xmax;
                chartStr.ChartAreas[0].AxisX.Minimum = 0;
                chartStr.ChartAreas[0].AxisX.Maximum = w;
                this.Text = String.Format("X={0}, Y={1} значение={2}", zoom.x2 + 1, zoom.y2 + 1, zoom.picture[zoom.x2, zoom.y2]);
                MakeRep(zoom.x2 + 1, zoom.y2 + 1);
                #endregion
            }
            else
            {
                #region zoom
                int zxmin = 16000;
                int zxmax = 0;
                int zymin = 16000;
                int zymax = 0;
                zoom.zx = (double)zoom.zx1 + zoom.delta_x * zoom.x2;
                zoom.zy = (double)zoom.zy1 + zoom.delta_y * zoom.y2;
                try
                {
                    chartStb.Series[0].Points.Clear();
                    chartStr.Series[0].Points.Clear();
                    chartStb.Series[1].Points.Clear();
                    chartStr.Series[1].Points.Clear();
                    for (int i = zoom.zy1; i < zoom.zy2; i++)
                    {
                        chartStb.Series[0].Points.AddXY(temnKadr[(int)zoom.zx, i], zoom.zy2 - (i - zoom.zy1));
                        chartStb.Series[1].Points.AddXY(kadrSvet[(int)zoom.zx, i], zoom.zy2 - (i - zoom.zy1));
                        //if (zymin > kadrSvet[(int)zoom.zx, i]) zymin = kadrSvet[(int)zoom.zx, i];
                        if (zymin > temnKadr[(int)zoom.zx, i]) zymin = temnKadr[(int)zoom.zx, i];
                        if (zymax < kadrSvet[(int)zoom.zx, i]) zymax = kadrSvet[(int)zoom.zx, i];
                    }
                    for (int i = zoom.zx1; i < zoom.zx2; i++)
                    {
                        chartStr.Series[0].Points.AddXY(i, temnKadr[i, (int)zoom.zy]);
                        chartStr.Series[1].Points.AddXY(i, kadrSvet[i, (int)zoom.zy]);
                        //if (zxmin > kadrSvet[i, (int)zoom.zy]) zxmin = kadrSvet[i, (int)zoom.zy];
                        if (zxmin > temnKadr[i, (int)zoom.zy]) zxmin = temnKadr[i, (int)zoom.zy];
                        if (zxmax < kadrSvet[i, (int)zoom.zy]) zxmax = kadrSvet[i, (int)zoom.zy];
                    }
                    chartStb.ChartAreas[0].AxisY.Minimum = zoom.zy1;
                    chartStb.ChartAreas[0].AxisY.Maximum = zoom.zy2 + 1;
                    chartStb.ChartAreas[0].AxisX.Minimum = zymin;
                    chartStb.ChartAreas[0].AxisX.Maximum = zymax;
                    chartStr.ChartAreas[0].AxisY.Minimum = zxmin;
                    chartStr.ChartAreas[0].AxisY.Maximum = zxmax;
                    chartStr.ChartAreas[0].AxisX.Minimum = zoom.zx1;
                    chartStr.ChartAreas[0].AxisX.Maximum = zoom.zx2 + 1;
                    this.Text = String.Format("X={0}, Y={1} значение={2}", Math.Round(zoom.zx + 1, 2), Math.Round(zoom.zy + 1, 2), zoom.picture[(int)zoom.zx, (int)zoom.zy]);
                    MakeRep((int)Math.Round(zoom.zx + 1, 2), (int)Math.Round(zoom.zy + 1, 2));
                }
                catch (Exception)
                {
                    this.Text = "Курсор за границей кадра";
                }
                //pictureBoxKadr.Image = bitmap;
                #endregion
            }
        }
        private void pictureBoxKadr_MouseDown(object sender, MouseEventArgs e)
        {
            zoom.x1 = e.X;
            zoom.y1 = e.Y;
        }
        #endregion

        #region zoom
        public class ForZoom {
            public int[,] picture;
            public Bitmap bitmap;
            public int x1, y1, x2, y2; //координаты точек, точка клика в масштабе, и цена пиксела в масштабе
            public int zx1, zx2, zy1, zy2;
            public double zx, zy;// границы зума, курсора в зуме
            public double delta_x, delta_y;
            public int xmin, xmax, ymin, ymax; //значения границ для графиков
            public bool zoom;
        }

        private void pictureBoxKadr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                zoom.zoom = false;
                pictureBoxKadr.Image = zoom.bitmap;
                pictureBoxKadr.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Text = String.Format("X={0}, Y={1} значение={2}", e.X + 1, e.Y + 1, zoom.picture[e.X, e.Y]);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            lbx_delKadr.SelectedIndex = -1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int pointer = lbx_delKadr.SelectedIndex;
            lbx_delKadr.Items.RemoveAt(pointer);
            if (RB_temn_show.Checked) deleteTemnKadr.RemoveAt(pointer);
            else deleteKadr[lbx_files.SelectedIndex].RemoveAt(pointer);
        }

        private void zooming_pixelisation()
        {
            if (zoom.x1 > zoom.x2) { int x = zoom.x1; zoom.x1 = zoom.x2; zoom.x2 = x; }
            if (zoom.y1 > zoom.y2) { int y = zoom.y1; zoom.y1 = zoom.y2; zoom.y2 = y; }
            zoom.zx1 = zoom.x1; zoom.zx2 = zoom.x2; zoom.zy1 = zoom.y1; zoom.zy2 = zoom.y2;
            zoom.delta_x = (double)(zoom.zx2 - zoom.zx1 + 1) / (double)w;
            zoom.delta_y = (double)(zoom.zy2 - zoom.zy1 + 1) / (double)h;
            using (Bitmap zoombitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                double pos_x = zoom.zx1;
                for (int x = 0; x < w; x++)
                {
                    if (pos_x >= w) break;
                    double pos_y = zoom.zy1;
                    for (int y = 0; y < h; y++)
                    {
                        if (pos_y >= h) break;
                        zoombitmap.SetPixel(x, y, zoom.bitmap.GetPixel((int)pos_x, (int)pos_y));
                        pos_y += zoom.delta_y;
                    }
                    pos_x += zoom.delta_x;
                }
                pictureBoxKadr.Image = (Image)zoombitmap.Clone();
            }
        }
        #endregion
    }
}
