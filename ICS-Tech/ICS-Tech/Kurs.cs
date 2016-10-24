using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICS_Tech
{
    public partial class Kurs : Form
    {
        string id;
        int timeLeft;
        int timeinterval = 10;

        public Kurs(string manager)
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sSQL = new StringBuilder("UPDATE kurs SET ");
            sSQL.Append("kurs='").Append(textBox1.Text).Append("'");
            sSQL.Append(" WHERE id=").Append(id.ToString());

            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String ssSQL = Convert.ToString(sSQL);
            //MessageBox.Show(ssSQL);
            ///строка подключения к БД
            ///Database-название БД MySQL
            ///Data Source-IP-адрес или имя компа,
            ///на котором крутится MySQL
            ///User ID-имя пользователя для подключения
            ///Password-он и в Африке password
            String sConnectionString = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
            ///в этой переменной будет содержаться рез-тат запроса
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            ///выполняем запрос, который возвращает результат
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(ssSQL, sConnectionString);

        }

        private void Kurs_Load(object sender, EventArgs e)
        {
            SelectDataFromDB();
            timer1.Enabled = true;
        }

        private string GetSQLString()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            StringBuilder sSQL = new StringBuilder("SELECT * FROM kurs");
            ///если поле textBoxFamily не пустое,то делаем выборку по полю FM
            //if (textBoxFamily.Text != "") sSQL.Append(" AND FM LIKE '%").Append(textBoxFamily.Text).Append("%'");
            ///если поле textBoxName не пустое,то делаем выборку по полю IM
            //if (textBoxName.Text != "") sSQL.Append(" AND IM LIKE '%").Append(textBoxName.Text).Append("%'");
            ///если поле textBoxOt не пустое,то делаем выборку по полю OT
            //if (textBoxOt.Text != "") sSQL.Append(" AND OT LIKE '%").Append(textBoxOt.Text).Append("%'");
            ///если поле textBoxTel не пустое,то делаем выборку по полю Phone
            //if (textBoxTel.Text != "") sSQL.Append(" AND Phone LIKE '%").Append(textBoxTel.Text).Append("%'");
            ///делаем сотритровку по Фамилии
            sSQL.Append(" ORDER BY id");
            return sSQL.ToString();
        }

        private void SelectDataFromDB()
        {
            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String sSQL = GetSQLString();
            ///строка подключения к БД
            ///Database-название БД MySQL
            ///Data Source-IP-адрес или имя компа,
            ///на котором крутится MySQL
            ///User ID-имя пользователя для подключения
            ///Password-он и в Африке password
            String sConnectionString = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
            ///в этой переменной будет содержаться рез-тат запроса
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            ///выполняем запрос, который возвращает результат
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(sSQL, sConnectionString);
            ///если ошибок нет
            if (result.HasError == false)
            {
                ///очищаем таблицу для вывода результата
                //dataGridViewTable.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                //dataGridViewTable.DataSource = result.ResultData.DefaultView;
                label1.Text = result.ResultData.Rows[0][1].ToString();
                id = result.ResultData.Rows[0][0].ToString();
            }
            ///если есть ошибка
            else
            {
                ///показываем ее в MessageBox'е
                MessageBox.Show(result.ErrorText);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                label2.Text = "Осталось " + timeLeft + " секунд";
                timeLeft = timeLeft - 1;
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                SelectDataFromDB();
                timeLeft = timeinterval;
                timer1.Start();
            }
        }

        /*
          
         
         */


    }
}
