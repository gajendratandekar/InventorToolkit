
using System;

using WpfWindow = System.Windows.Window;
using WpfMessageBox = System.Windows.MessageBox;
using WpfRoutedEventArgs = System.Windows.RoutedEventArgs;
using WinForms = System.Windows.Forms;



namespace InventorToolkit.FileManager
{
    public partial class MainWindow : WpfWindow
    {
     
        private global::Inventor.Application? _app;

        public MainWindow(global::Inventor.Application app)
        {
            InitializeComponent();
            _app = app;
        }

        private void BrowseImport_Click(object sender, WpfRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "Inventor Files (*.ipt;*.iam;*.idw;*.dwg;*.ipn)|*.ipt;*.iam;*.idw;*.dwg;*.ipn";

            if (dlg.ShowDialog() == true)
                TxtImportPath.Text = dlg.FileName;
        }

        private void OpenImport_Click(object sender, WpfRoutedEventArgs e)
        {
            if (!System.IO.File.Exists(TxtImportPath.Text))
            {
                WpfMessageBox.Show("Select valid file.");
                return;
            }

            try
            {
                

                if (_app == null)
                {
                    WpfMessageBox.Show("Inventor not connected.");
                    return;
                }

                _app.Documents.Open(TxtImportPath.Text, true);

                TxtStatus.Text = "File imported successfully.";
            }
            catch (Exception ex)
            {
                WpfMessageBox.Show(ex.Message);
            }
        }
        private void Export_Click(object sender, WpfRoutedEventArgs e)
        {
            if (_app == null || _app.ActiveDocument == null)
            {
                WpfMessageBox.Show("No active document.");
                return;
            }

            try
            {
                global::Inventor.Document doc = _app.ActiveDocument;

                string defaultName = System.IO.Path.GetFileName(doc.FullFileName);

                Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();

                saveDialog.Title = "Export Inventor File";
                saveDialog.FileName = defaultName;

                saveDialog.Filter =
                    "Inventor Part (*.ipt)|*.ipt|" +
                    "Inventor Assembly (*.iam)|*.iam|" +
                    "Inventor Drawing (*.idw)|*.idw|" +
                    "AutoCAD Drawing (*.dwg)|*.dwg|" +
                    "PDF (*.pdf)|*.pdf";

                if (saveDialog.ShowDialog() == true)
                {
                    doc.SaveAs(saveDialog.FileName, false);

                    TxtExportPath.Text = saveDialog.FileName;
                    TxtStatus.Text = "File exported successfully.";

                    WpfMessageBox.Show("File exported successfully.");
                }
            }
            catch (Exception ex)
            {
                WpfMessageBox.Show(ex.Message);
            }
        }
        private void Clear_Click(object sender, WpfRoutedEventArgs e)
        {
            TxtImportPath.Clear();
            TxtStatus.Clear();
        }
    }
}