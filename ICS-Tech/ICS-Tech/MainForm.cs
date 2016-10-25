using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICS_Tech
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Login frm = new Login(this);
            frm.MdiParent = this;
            frm.Show();
            SelectDataOrderFromDB();
            SelectDataMessageFromDB();
            timer1.Enabled = true;
            Count();
        }
        private string GetSQLOrder()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            StringBuilder sSQL = new StringBuilder("SELECT * FROM ordered  ");
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
                dataGridViewTable1.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                dataGridViewTable1.DataSource = result.ResultData.DefaultView;
            }
            ///если есть ошибка
            else
            {
                ///показываем ее в MessageBox'е
                MessageBox.Show(result.ErrorText);
            }
        }

        private string GetSQLMessage()
        {
            ///начинаем формировать запрос
            ///сначала подготавливаем общую информацию о выборке
            ///поля и таблицу для выборки
            StringBuilder sSQL = new StringBuilder("SELECT * FROM mails ");
            sSQL.Append(" ORDER BY id");
            return sSQL.ToString();
        }

        private void SelectDataMessageFromDB()
        {
            ///переменная,в которой содержится
            ///SQL-запрос на выборку
            String sSQL = GetSQLMessage();
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
                dataGridViewTable2.Columns.Clear();
                ///заполняем таблицу на основе данных запроса
                dataGridViewTable2.DataSource = result.ResultData.DefaultView;
            }
            ///если есть ошибка
            else
            {
                ///показываем ее в MessageBox'е
                MessageBox.Show(result.ErrorText);
            }
        }

        private void Count()
        {
            int kolst1 = dataGridViewTable1.Rows.Count;
            int kolst2 = dataGridViewTable2.Rows.Count;
            if (kolst1 > 0 || kolst2 > 0)
            {
                string message = ("У вас есть новые заказы: " + kolst1 + "\nУ вас есть новые сообщения: " + kolst2);
                notifyIcon1.ShowBalloonTip(500, "Сообщение", message, ToolTipIcon.Warning);
            }
        }
    }
}
