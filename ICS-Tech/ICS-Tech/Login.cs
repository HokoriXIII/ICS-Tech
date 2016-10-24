using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
//Дополнительно подключены для работы
//using Newtonsoft.Json.Linq;

namespace ICS_Tech
{
    public partial class Login : Form
    {
        MainForm mainForm;
        public Login(MainForm otherform)
        {
            InitializeComponent();
            mainForm = otherform;
            LoadSettings();
            Autologin();
        }
        private void LoadSettings()
        {
            if (!File.Exists("Login.ini"))
                return;
            using (StreamReader streamReader = File.OpenText("Login.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] strArray = streamReader.ReadLine().Split(';');
                    if (strArray[0] == "1")
                    {
                        LoginSave.Checked = true;
                        LoginSaveText.Text = strArray[0];
                    }
                    if (strArray[1] == "1")
                    {
                        AvtoLogin.Checked = true;
                        AvtoLoginText.Text = strArray[1];
                    }
                    if (strArray[2] != "")
                        tLogin.Text = strArray[2];
                    if (strArray[3] != "")
                        tPassword.Text = strArray[3];
                }
            }
        }

        private void Autologin()
        {
            if (!AvtoLogin.Checked)
                return;
            UserLogin();
        }

        private void UserLogin()
        {
            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String sSQL = GetSQLString();
            //MessageBox.Show(sSQL);
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

            //MessageBox.Show(result.);
            ///если ошибок нет
            if (result.HasError == false)
            {

                ///очищаем таблицу для вывода результата
                dataGridViewTable.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                dataGridViewTable.DataSource = result.ResultData.DefaultView;

                //string result2 = Convert.ToString(result.ResultData.DefaultView);
                //MessageBox.Show(result2);

                int kolst = dataGridViewTable.Rows.Count;
                //MessageBox.Show(Convert.ToString(kolst));
                if (kolst > 0)
                {

                    Main frm = new Main(tLogin.Text);
                    frm.Owner = this;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Неверно введенные данные \n Попробуйте ввести заново",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ///если есть ошибка
            else
            {
                ///показываем ее в MessageBox'е
                MessageBox.Show(result.ErrorText);
            }
        }

        private void LoginSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AvtoLogin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveLogin()
        {
            if (!LoginSave.Checked)
                return;
            File.WriteAllText("Login.ini", string.Format("{0};{1};{2};{3}", LoginSaveText.Text, AvtoLoginText.Text, tLogin.Text, tPassword.Text));
        }

        private void bLogin_Click(object sender, System.EventArgs e)
        {
            SaveLogin();
            UserLogin();
        }

        private string GetSQLString()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            /// SELECT * FROM managers1 where login = '".$per1."' and password = '".$per2."'
            StringBuilder sSQL = new StringBuilder("SELECT * FROM managers1 where login = ");
            ///если поле textBoxFamily не пустое,то делаем выборку по полю FM
            if (tLogin.Text != "") sSQL.Append("\"").Append(tLogin.Text).Append("\"");
            ///если поле textBoxName не пустое,то делаем выборку по полю IM
            if (tPassword.Text != "") sSQL.Append(" AND password =  \"").Append(tPassword.Text).Append("\"");
            ///если поле textBoxOt не пустое,то делаем выборку по полю OT
            //if (textBoxOt.Text != "") sSQL.Append(" AND OT LIKE '%").Append(textBoxOt.Text).Append("%'");
            ///если поле textBoxTel не пустое,то делаем выборку по полю Phone
            //if (textBoxTel.Text != "") sSQL.Append(" AND Phone LIKE '%").Append(textBoxTel.Text).Append("%'");
            ///делаем сотритровку по Фамилии
            //sSQL.Append(" ORDER BY id");
            return sSQL.ToString();
        }

        private void tPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bLogin_Click(sender, e);
            }
        }
    }
}
