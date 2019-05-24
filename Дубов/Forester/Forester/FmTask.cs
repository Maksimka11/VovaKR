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
    public partial class FmTask : Form
    {
        /// <summary>
        /// форма ввода и редактирования запланированных задач
        /// </summary>
        public FmTask()
        {
            InitializeComponent();
            //заполняем комбобокс видов ухода
            LoadKindCare();
            //заполняем комбобокс областей леса
            LoadRegion();
            //по-умолчанию дата выполнения - сегодняшнее число
            Task.Date = DateTime.Today;
        }
        //объект класса Task
        public Task Task = new Task();

        private void LoadKindCare()
        {
            //пишем SQL по отбору данных по видам ухода, сортируем по названию
            var sql = @"select * from KindCare order by kName";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом комбобокс
            cbCare.DataSource = ds.Tables[0];
            cbCare.DisplayMember = "kName";
            cbCare.ValueMember = "kUid";
        }

        private void LoadRegion()
        {
            //пишем SQL по отбору данных по областям леса, сортируем по размеру площади
            var sql = @"select * from Region order by rArea";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом комбобокс
            cbRegion.DataSource = ds.Tables[0];
            cbRegion.DisplayMember = "rClass";
            cbRegion.ValueMember = "rUid";
        }

        private void FmTask_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            cbCare.SelectedValue = Task.Care;
            cbRegion.SelectedValue = Task.Region;
            dtpDate.Value = Task.Date;
        }

        /// <summary>
        /// обработка кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            //проверяем выбор вида ухода
            if (cbCare.SelectedIndex < 0)
            {
                //сообщение
                MessageBox.Show(@"Выберите вид ухода!");
                //устанавливаем фокус
                cbCare.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }            //проверяем выбор области леса
            if (cbRegion.SelectedIndex < 0)
            {
                MessageBox.Show(@"Выберите область!");
                cbRegion.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //присваиваем данные из компонентов объекту классса Task
            Task.Care = (int)cbCare.SelectedValue;            Task.Region = (int)cbRegion.SelectedValue;            Task.Date = dtpDate.Value;
        }


    }
}
