using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIRS
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объявление нового экземпляра списка контактов
        /// </summary>
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для сохранения файла с выбором дериктории
        /// </summary>
        private void SaveFileAs()
        {
            SaveFileDialog saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = "(*.S2P) | *.S2P";
            saveFileAs.ShowDialog();
            string fileName = saveFileAs.FileName;
            ProjectManager.SaveFile(_project, fileName);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string fileName = openFile.FileName;
            _project = ProjectManager.LoadFile(_project, fileName);
           // FillListView(_project.Contacts);
        }
    }
}
