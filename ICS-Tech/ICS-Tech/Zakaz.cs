using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICS_Tech
{
    public partial class Zakaz : Form
    {
        string ManagerUI;
        string OrdId;
        string FormFrom;
        public Zakaz(string manager, string Id, string fromform)
        {
            InitializeComponent();
            ManagerUI = manager;
            OrdId = Id;
            FormFrom = fromform;
            GetData();
            if (FormFrom != "1")
            {
                button1.Visible = false;
            }
        }

        private void GetData()
        {
            ///формируем строку подключения к MySQL
            String sConnectionString2 = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
            ///выполняем SQL-запрос
            ///
            string newSQL = "";

            if (FormFrom == "1")
            {
                StringBuilder sSQL = new StringBuilder("SELECT * FROM ordered WHERE id=");
                sSQL.Append("'").Append(OrdId).Append("'");
                newSQL = sSQL.ToString();

                string GetSQL = (newSQL);
                
                MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
                ///выполняем запрос, который возвращает результат
                result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(GetSQL, sConnectionString2);
                ///если ошибок нет
                if (result.HasError == false)
                {
                    ///очищаем таблицу для вывода результата
                    ///заполняем таблицу на основе данных запроса
                    orderedprod.Text = result.ResultData.Rows[0][1].ToString();
                    koltov.Text = result.ResultData.Rows[0][2].ToString();
                    name.Text = result.ResultData.Rows[0][3].ToString();
                    mail.Text = result.ResultData.Rows[0][4].ToString();
                    telefone.Text = result.ResultData.Rows[0][5].ToString();
                    data.Text = result.ResultData.Rows[0][6].ToString();
                }
                ///если есть ошибка
                else
                {
                    ///показываем ее в MessageBox'е
                    MessageBox.Show(result.ErrorText);
                }
            }
            else
            {
                StringBuilder sSQL = new StringBuilder("SELECT * FROM otrabzak WHERE id=");
                sSQL.Append("'").Append(OrdId).Append("'");
                newSQL = sSQL.ToString();
                string GetSQL = (newSQL);
                
                MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
                ///выполняем запрос, который возвращает результат
                result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(GetSQL, sConnectionString2);
                ///если ошибок нет
                if (result.HasError == false)
                {
                    ///очищаем таблицу для вывода результата
                    ///заполняем таблицу на основе данных запроса
                    orderedprod.Text = result.ResultData.Rows[0][2].ToString();
                    koltov.Text = result.ResultData.Rows[0][3].ToString();
                    name.Text = result.ResultData.Rows[0][4].ToString();
                    mail.Text = result.ResultData.Rows[0][5].ToString();
                    telefone.Text = result.ResultData.Rows[0][6].ToString();
                    data.Text = result.ResultData.Rows[0][7].ToString();
                }
                ///если есть ошибка
                else
                {
                    ///показываем ее в MessageBox'е
                    MessageBox.Show(result.ErrorText);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*///если выделена не пустая ячейка
            if (id != "")
            {*/
            if (MessageBox.Show("Вы уверены,что хотите удалить запись под № " + OrdId,
                        "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ///формируем строку подключения к MySQL
                String sConnectionString2 = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
                ///выполняем SQL-запрос
                ///
                //string nametov = dataGridViewTable.CurrentCell.Value.ToString();

                StringBuilder sSQL = new StringBuilder("INSERT INTO otrabzak (oldid,nametov,koltov,name,mail,tel,data,dataotr,manager) VALUES (");
                sSQL.Append("'").Append(OrdId).Append("',");
                sSQL.Append("'").Append(orderedprod.Text).Append("',");
                sSQL.Append("'").Append(koltov.Text).Append("',");
                sSQL.Append("'").Append(name.Text).Append("',");
                sSQL.Append("'").Append(mail.Text).Append("',");
                sSQL.Append("'").Append(telefone.Text).Append("',");
                sSQL.Append("'").Append(data.Text).Append("',");
                sSQL.Append("'").Append(DateTime.Now).Append("',");
                sSQL.Append("'").Append(ManagerUI).Append("')");
                string newSQL = sSQL.ToString();

                string GetSQL = (newSQL);

                //MessageBox.Show(GetSQL, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery(GetSQL, sConnectionString2);


                ///формируем строку подключения к MySQL
                String sConnectionString = "Database=ics-tech2;Data Source=195.64.225.66;User Id=ics-tech2;Password=SheytUgnud;charset=utf8;";
                ///выполняем SQL-запрос
                MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("DELETE FROM ordered WHERE id=" + OrdId, sConnectionString);

                /*SelectDataOrderFromDB();
                SelectDataOrderedFromDB();*/
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
