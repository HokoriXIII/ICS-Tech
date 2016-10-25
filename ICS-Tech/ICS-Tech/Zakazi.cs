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
    public partial class Zakazi : Form
    {

        int timeLeft;
        int timeinterval = 60;
        string ManagerUI;

        public Zakazi(string manager)
        {
            InitializeComponent();
            ManagerUI = manager;
            toolStripProgressBar1.Maximum = timeinterval;
        }

        private string GetSQLOrder()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            StringBuilder sSQL = new StringBuilder("SELECT * FROM ordered WHERE name<>'' ");
            ///если поле textBoxFamily не пустое,то делаем выборку по полю FM
            //if (textBoxFamily.Text != "") sSQL.Append(" AND name LIKE '%").Append(textBoxFamily.Text).Append("%'");
            ///если поле textBoxName не пустое,то делаем выборку по полю IM
            //if (textBoxName.Text != "") sSQL.Append(" AND opis LIKE '%").Append(textBoxName.Text).Append("%'");
            ///если поле textBoxOt не пустое,то делаем выборку по полю OT
            //if (textBoxOt.Text != "") sSQL.Append(" AND price LIKE '%").Append(textBoxOt.Text).Append("%'");
            ///если поле textBoxTel не пустое,то делаем выборку по полю Phone
            //if (textBoxTel.Text != "") sSQL.Append(" AND nsklad LIKE '%").Append(textBoxTel.Text).Append("%'");
            ///делаем сотритровку по Фамилии
            sSQL.Append(" ORDER BY id");
            return sSQL.ToString();
        }

        private void SelectDataOrderFromDB()
        {
            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String sSQL = GetSQLOrder();
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
                gridView1.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                gridControl1.DataSource = result.ResultData.DefaultView;
            }
            ///если есть ошибка
            else
            {
                ///показываем ее в MessageBox'е
                MessageBox.Show(result.ErrorText);
            }
        }


        private string GetSQLOrdered()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            StringBuilder sSQL = new StringBuilder("SELECT * FROM otrabzak");
            ///если поле textBoxFamily не пустое,то делаем выборку по полю FM
            //if (textBoxFamily.Text != "") sSQL.Append(" AND name LIKE '%").Append(textBoxFamily.Text).Append("%'");
            ///если поле textBoxName не пустое,то делаем выборку по полю IM
            //if (textBoxName.Text != "") sSQL.Append(" AND opis LIKE '%").Append(textBoxName.Text).Append("%'");
            ///если поле textBoxOt не пустое,то делаем выборку по полю OT
            //if (textBoxOt.Text != "") sSQL.Append(" AND price LIKE '%").Append(textBoxOt.Text).Append("%'");
            ///если поле textBoxTel не пустое,то делаем выборку по полю Phone
            //if (textBoxTel.Text != "") sSQL.Append(" AND nsklad LIKE '%").Append(textBoxTel.Text).Append("%'");
            ///делаем сотритровку по Фамилии
            sSQL.Append(" ORDER BY id");
            return sSQL.ToString();
        }

        private void SelectDataOrderedFromDB()
        {
            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String sSQL = GetSQLOrdered();
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
                gridView2.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                gridControl2.DataSource = result.ResultData.DefaultView;
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
                toolStripStatusLabel.Text = "Осталось " + timeLeft + " секунд";
                timeLeft = timeLeft - 1;
                toolStripProgressBar1.Value = timeinterval - timeLeft;
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                SelectDataOrderFromDB();
                SelectDataOrderedFromDB();
                timeLeft = timeinterval;
                timer1.Start();
                toolStripProgressBar1.Value = timeinterval - timeLeft;
            }
        }

        private void Zakazi_Load(object sender, EventArgs e)
        {
            SelectDataOrderFromDB();
            SelectDataOrderedFromDB();
            //timer1.Interval = 60000;
            timer1.Enabled = true;

        }

        private void ZakazOt_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString() != "")
            {
                Zakaz frm = new Zakaz(ManagerUI, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString(),"1");
                frm.Owner = this;
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            /*
            ///если выделена не пустая ячейка
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString() != "")
            {
                if (MessageBox.Show("Вы уверены,что хотите удалить запись под № " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString(),
                            "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ///формируем строку подключения к MySQL
                    String sConnectionString2 = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
                    ///выполняем SQL-запрос
                    ///
                    //string nametov = dataGridViewTable.CurrentCell.Value.ToString();




                    StringBuilder sSQL = new StringBuilder("INSERT INTO otrabzak (nametov,koltov,name,mail,tel,data,dataotr,manager) VALUES (");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "orderedprod").ToString()).Append("',");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "koltov").ToString()).Append("',");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "name").ToString()).Append("',");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "mail").ToString()).Append("',");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "telefone").ToString()).Append("',");
                    sSQL.Append("'").Append(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "data").ToString()).Append("',");
                    sSQL.Append("'").Append(DateTime.Now).Append("',");
                    sSQL.Append("'").Append(ManagerUI).Append("')");
                    string newSQL = sSQL.ToString();

                    string GetSQL = (newSQL);

                    //MessageBox.Show(GetSQL, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery(GetSQL, sConnectionString2);


                    ///формируем строку подключения к MySQL
                    String sConnectionString = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
                    ///выполняем SQL-запрос
                    MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("DELETE FROM ordered WHERE id=" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString(), sConnectionString);

                    SelectDataOrderFromDB();
                    SelectDataOrderedFromDB();
                }
            }*/
        }

        private void ZakazOt2_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString() != "")
            {
                Zakaz frm = new Zakaz(ManagerUI, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString(), "2");
                frm.Owner = this;
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        //TBGRNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GRNo").ToString();


    }
}
