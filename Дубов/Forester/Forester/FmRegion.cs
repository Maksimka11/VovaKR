using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forester
{
    public partial class FmRegion : Form
    {
        /// <summary>
        /// форма ввода и редактирования области леса
        /// </summary>
        public FmRegion()
        {
            InitializeComponent();
        }
        //объект класса Region
        public new Region Region = new Region();

        /// <summary>
        /// обработка кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            //проверяем на заполненность классификации деревьев
            if (string.IsNullOrEmpty(txtClass.Text))
            {
                //сообщение
                MessageBox.Show(@"Введите классификаю деревьев!");
                //устанавливаем фокус
                txtClass.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода площади
            Single d = 0; if (!Single.TryParse(txtArea.Text, out d))
            {
                MessageBox.Show(@"Неправильно введена площадь области!");
                txtArea.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода среднего возраста
            int f = 0; if (!Int32.TryParse(txtYear.Text, out f))
            {
                MessageBox.Show(@"Неправильно введен средний возраст деревьев!");
                txtYear.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //присваиваем данные из компонент объекту классса Region
            Region.Area = Convert.ToSingle(txtArea.Text);
            Region.Class = txtClass.Text;
            Region.Year = Convert.ToInt32(txtYear.Text);
        }

        private void FmRegion_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            txtArea.Text = Region.Area.ToString();
            txtClass.Text = Region.Class;
            txtYear.Text = Region.Year.ToString();

        }
    }
}
