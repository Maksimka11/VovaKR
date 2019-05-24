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
    public partial class FmKindCare : Form
    {
        /// <summary>
        /// форма ввода и редактирования видов ухода
        /// </summary>
        public FmKindCare()
        {
            InitializeComponent();
        }

        //объект класса KindCare
        public KindCare KindCare = new KindCare();

        private void FmKindCare_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            txtCost.Text = KindCare.Cost.ToString();
            txtName.Text = KindCare.Name;
            txtOpis.Text = KindCare.Opis;

        }

        /// <summary>
        /// обработка кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            //проверяем на заполненность названия
            if (string.IsNullOrEmpty(txtName.Text))
            {
                //сообщение
                MessageBox.Show(@"Введите название!");
                //устанавливаем фокус
                txtName.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем на заполненность описания
            if (string.IsNullOrEmpty(txtOpis.Text))
            {
                //сообщение
                MessageBox.Show(@"Введите описание!");
                //устанавливаем фокус
                txtOpis.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода гос. затрат
            Single d = 0; if (!Single.TryParse(txtCost.Text, out d))
            {
                MessageBox.Show(@"Неправильно введены гос.затраты!");
                txtCost.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //присваиваем данные из компонент объекту классса KindCare
            KindCare.Name = txtName.Text;
            KindCare.Opis = txtOpis.Text;
            KindCare.Cost = Convert.ToSingle(txtCost.Text);


        }
    }
}
