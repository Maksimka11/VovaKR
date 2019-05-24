using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Forester
{
    /// <summary>
    /// главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //загружаем данные по областям леса
            LoadRegion();
            //загружаем данные по видам ухода
            LoadKindCare();
            //загружаем данные по запланированным задачам
            LoadTask();
        }

        /// <summary>
        /// загрузка областей леса
        /// </summary>
        private void LoadRegion()
        {
            //пишем SQL по отбору данных по областям леса, сортируем по классификации
            var sql = @"select * from Region order by rClass";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvRegion.DataSource = ds;
            dgvRegion.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvRegion.Columns["rUid"].Visible = false;
            //устанавдиваем ширину столбца
            dgvRegion.Columns["rClass"].Width = 230;
            //устанавливаем заголовок столбца
            dgvRegion.Columns["rClass"].HeaderText = @"Классификация деревьев";
            dgvRegion.Columns["rArea"].HeaderText = @"Площадь области";
            dgvRegion.Columns["rArea"].Width = 230;
            dgvRegion.Columns["rYear"].HeaderText = @"Средний возраст деревьев";
            dgvRegion.Columns["rYear"].Width = 230;
        }

        /// <summary>
        /// загрузка видов ухода
        /// </summary>
        private void LoadKindCare()
        {
            //пишем SQL по отбору данных по видам ухода, сортируем по названию
            var sql = @"select * from KindCare order by kName";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvCare.DataSource = ds;
            dgvCare.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvCare.Columns["kUid"].Visible = false;
            //устанавдиваем ширину столбца
            dgvCare.Columns["kName"].Width = 230;
            //устанавливаем заголовок столбца
            dgvCare.Columns["kName"].HeaderText = @"Название";
            dgvCare.Columns["kOpis"].HeaderText = @"Описание";
            dgvCare.Columns["kOpis"].Width = 230;
            dgvCare.Columns["kCost"].HeaderText = @"Гос. затраты";
            dgvCare.Columns["kCost"].Width = 230;
        }

        /// <summary>
        /// загрузка задач
        /// </summary>
        private void LoadTask()
        {
            //пишем SQL по отбору данных по запланированным задачам, сортируем по дате выполнения
            var sql = @"select kUid, rUid, tUid, tRegion, [tCare], tDate from [Region], [Task], [KindCare] where tCare=kUid and tRegion=rUid order by tDate desc";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvTask.DataSource = ds;
            dgvTask.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvTask.Columns["kUid"].Visible = false;
            dgvTask.Columns["rUid"].Visible = false;
            dgvTask.Columns["tUid"].Visible = false;
            //устанавдиваем ширину столбца
            dgvTask.Columns["tRegion"].Width = 230;
            //устанавливаем заголовок столбца
            dgvTask.Columns["tRegion"].HeaderText = @"Область леса";
            dgvTask.Columns["tCare"].HeaderText = @"Вид ухода";
            dgvTask.Columns["tCare"].Width = 230;
            dgvTask.Columns["tDate"].HeaderText = @"Дата выполнения";
            dgvTask.Columns["tDate"].Width = 230;
        }

        /// <summary>
        /// добавление задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTaskAdd_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmTask();
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных о задаче
                var cmd = new OleDbCommand(@"insert into Task (tRegion, tCare, tDate)
values (?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"tRegion", f.Task.Region);
                cmd.Parameters.AddWithValue(@"tCare", f.Task.Care);
                cmd.Parameters.AddWithValue(@"tDate", f.Task.Date);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTask();
            }
        }

        /// <summary>
        /// редактирование задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTaskChange_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTask.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvTask.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmTask();
            //заплняем объект класса Task данными из datagridview
            f.Task.Uid = (int)dgvTask.Rows[i].Cells["tUid"].Value;
            f.Task.Region = (int)(dgvTask.Rows[i].Cells["rUid"].Value);
            f.Task.Care = (int)(dgvTask.Rows[i].Cells["kUid"].Value);
            f.Task.Date = Convert.ToDateTime(dgvTask.Rows[i].Cells["tDate"].Value);
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных о задачи
                var cmd = new OleDbCommand(@"update Task set tRegion=?, tCare=?, tDate=? where tUid=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"tRegion", f.Task.Region);
                cmd.Parameters.AddWithValue(@"tCare", f.Task.Care);
                cmd.Parameters.AddWithValue(@"tDate", f.Task.Date);
                cmd.Parameters.AddWithValue(@"tUid", f.Task.Uid);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTask();
            }
        }

        /// <summary>
        /// удаление задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTaskDel_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTask.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvTask.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvTask.Rows[i].Cells["tUid"].Value;
            //sql по удалению задачи
            var cmd = new OleDbCommand(@"delete from Task where tUid=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"tUid", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadTask();
        }

        /// <summary>
        /// обработка двойного клика по datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnTaskChange_Click(sender, e);
        }

        /// <summary>
        /// добавление вида ухода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCareAdd_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmKindCare();
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных о виде ухода
                var cmd = new OleDbCommand(@"insert into KindCare (kName, kOpis, kCost)
values (?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"kName", f.KindCare.Name);
                cmd.Parameters.AddWithValue(@"kOpis", f.KindCare.Opis);
                cmd.Parameters.AddWithValue(@"kCost", f.KindCare.Cost);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadKindCare();
            }
        }

        /// <summary>
        /// редактирование вида ухода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCareChange_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvCare.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvCare.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmKindCare();
            //заплняем объект класса KindCare данными из datagridview
            f.KindCare.Uid = (int)dgvCare.Rows[i].Cells["kUid"].Value;
            f.KindCare.Name = Convert.ToString(dgvCare.Rows[i].Cells["kName"].Value);
            f.KindCare.Opis = Convert.ToString(dgvCare.Rows[i].Cells["kOpis"].Value);
            f.KindCare.Cost = (float)dgvCare.Rows[i].Cells["kCost"].Value;
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных о виде ухода
                var cmd = new OleDbCommand(@"update KindCare set kName=?, kOpis=?, kCost=?
 where kUid=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"kName", f.KindCare.Name);
                cmd.Parameters.AddWithValue(@"kOpis", f.KindCare.Opis);
                cmd.Parameters.AddWithValue(@"kCost", f.KindCare.Cost);
                cmd.Parameters.AddWithValue(@"kUid", f.KindCare.Uid);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadKindCare();
            }
        }

        /// <summary>
        /// удаление вида ухода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCareDel_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvCare.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvCare.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvCare.Rows[i].Cells["kUid"].Value;
            //sql по удалению вида ухода
            var cmd = new OleDbCommand(@"delete from KindCare where kUid=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"kUid", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadKindCare();
        }

        /// <summary>
        /// обработка двойного клика по datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvCare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnCareChange_Click(sender, e);
        }

        /// <summary>
        /// добавление области леса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegionAdd_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmRegion();
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных об области леса
                var cmd = new OleDbCommand(@"insert into Region (rClass, rArea, rYear)
values (?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"rClass", f.Region.Class);
                cmd.Parameters.AddWithValue(@"rArea", f.Region.Area);
                cmd.Parameters.AddWithValue(@"rYear", f.Region.Year);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadRegion();
            }
        }

        /// <summary>
        /// редактирование области леса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegionChange_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvRegion.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvRegion.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmRegion();
            //заплняем объект класса Region данными из datagridview
            f.Region.Uid = (int)dgvRegion.Rows[i].Cells["rUid"].Value;
            f.Region.Class = Convert.ToString(dgvRegion.Rows[i].Cells["rClass"].Value);
            f.Region.Area = (float)(dgvRegion.Rows[i].Cells["rArea"].Value);
            f.Region.Year = (int)dgvRegion.Rows[i].Cells["rYear"].Value;
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных об области леса
                var cmd = new OleDbCommand(@"update Region set rClass=?, rArea=?, rYear=? where rUid=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"rClass", f.Region.Class);
                cmd.Parameters.AddWithValue(@"rArea", f.Region.Area);
                cmd.Parameters.AddWithValue(@"rYear", f.Region.Year);
                cmd.Parameters.AddWithValue(@"rUid", f.Region.Uid);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadRegion();
            }
        }

        /// <summary>
        /// удаление области леса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegionDel_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvRegion.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvRegion.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvRegion.Rows[i].Cells["rUid"].Value;
            //sql по удалению области леса
            var cmd = new OleDbCommand(@"delete from Region where rUid=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"rUid", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadRegion();
        }

        /// <summary>
        /// обработка двойного клика по datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvRegion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnRegionChange_Click(sender, e);
        }
    }
}
