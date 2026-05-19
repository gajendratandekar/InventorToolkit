////////using System.Text;
////////using System.Windows;
////////using System.Windows.Controls;
////////using System.Windows.Data;
////////using System.Windows.Documents;
////////using System.Windows.Input;
////////using System.Windows.Media;
////////using System.Windows.Media.Imaging;
////////using System.Windows.Navigation;
////////using System.Windows.Shapes;

////////namespace InventorToolkit.FileManager
////////{
////////    /// <summary>
////////    /// Interaction logic for MainWindow.xaml
////////    /// </summary>
////////    public partial class MainWindow : Window
////////    {
////////        public MainWindow()
////////        {
////////            InitializeComponent();
////////        }
////////    }
////////}



////using System;
////using System.IO;
////using System.Runtime.InteropServices;
////using System.Windows;
////using Inventor;
////using Microsoft.Win32;
////using Forms = System.Windows.Forms;

////namespace InventorToolkit.FileManager
////{
////    public partial class MainWindow : Window
////    {
////        private Inventor.Application _app;

////        public MainWindow()
////        {
////            InitializeComponent();
////            ConnectInventor();
////        }

////        private void ConnectInventor()
////        {
////            try
////            {
////                _app = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");
////            }
////            catch
////            {
////                try
////                {
////                    Type inventorType = Type.GetTypeFromProgID("Inventor.Application");
////                    _app = (Inventor.Application)Activator.CreateInstance(inventorType);
////                    _app.Visible = true;
////                }
////                catch
////                {
////                    MessageBox.Show("Inventor is not installed or could not start.");
////                }
////            }
////        }

////        private void BrowseImport_Click(object sender, RoutedEventArgs e)
////        {
////            OpenFileDialog dlg = new OpenFileDialog();
////            dlg.Filter = "Inventor Files (*.ipt;*.iam;*.idw;*.dwg;*.ipn)|*.ipt;*.iam;*.idw;*.dwg;*.ipn";

////            if (dlg.ShowDialog() == true)
////                TxtImportPath.Text = dlg.FileName;
////        }

////        private void OpenImport_Click(object sender, RoutedEventArgs e)
////        {
////            if (!File.Exists(TxtImportPath.Text))
////            {
////                MessageBox.Show("Select a valid file.");
////                return;
////            }

////            try
////            {
////                _app.Documents.Open(TxtImportPath.Text);
////                TxtStatus.Text = "File imported successfully into Inventor.";
////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show(ex.Message);
////            }
////        }

////        private void BrowseExport_Click(object sender, RoutedEventArgs e)
////        {
////            using (Forms.FolderBrowserDialog dlg = new Forms.FolderBrowserDialog())
////            {
////                if (dlg.ShowDialog() == Forms.DialogResult.OK)
////                    TxtExportPath.Text = dlg.SelectedPath;
////            }
////        }

////        private void Export_Click(object sender, RoutedEventArgs e)
////        {
////            if (_app?.ActiveDocument == null)
////            {
////                MessageBox.Show("No active Inventor document.");
////                return;
////            }

////            if (string.IsNullOrWhiteSpace(TxtExportPath.Text))
////            {
////                MessageBox.Show("Select export folder.");
////                return;
////            }

////            try
////            {
////                Document doc = _app.ActiveDocument;
////                string fileName = Path.GetFileName(doc.FullFileName);
////                string savePath = Path.Combine(TxtExportPath.Text, fileName);

////                doc.SaveAs(savePath, false);

////                TxtStatus.Text = "File exported successfully.";
////            }
////            catch (Exception ex)
////            {
////                MessageBox.Show(ex.Message);
////            }
////        }

////        private void Clear_Click(object sender, RoutedEventArgs e)
////        {
////            TxtImportPath.Text = "";
////            TxtExportPath.Text = "";
////            TxtStatus.Text = "";
////        }
////    }
////}




//using System;
//using System.Runtime.InteropServices;
//using System.Windows;
//using Inventor;
//using Microsoft.Win32;
//using System.Windows.Forms;
//using System;
//using System.Runtime.InteropServices;
//using Inventor;
//using Microsoft.Win32;

//using WpfWindow = System.Windows.Window;
//using WpfMessageBox = System.Windows.MessageBox;
//using WinForms = System.Windows.Forms;

//namespace InventorToolkit.FileManager
//{
//    public partial class MainWindow : WpfWindow
//    {
//        private Inventor.Application? _app;

//        public MainWindow()
//        {
//            InitializeComponent();
//            ConnectInventor();
//        }

//        //private void ConnectInventor()
//        //{
//        //    try
//        //    {
//        //        _app = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");
//        //    }
//        //    catch
//        //    {
//        //        try
//        //        {
//        //            Type? inventorType = Type.GetTypeFromProgID("Inventor.Application");

//        //            if (inventorType != null)
//        //            {
//        //                _app = (Inventor.Application)Activator.CreateInstance(inventorType)!;
//        //                _app.Visible = true;
//        //            }
//        //        }
//        //        catch
//        //        {
//        //            MessageBox.Show("Inventor not available.");
//        //        }
//        //    }
//        //}

//        private void ConnectInventor()
//        {
//            try
//            {
//                Type? inventorType = Type.GetTypeFromProgID("Inventor.Application");

//                if (inventorType != null)
//                {
//                    _app = (Inventor.Application)Activator.CreateInstance(inventorType)!;
//                    _app.Visible = true;
//                }
//            }
//            catch
//            {
//                WpfMessageBox.Show("Inventor not available.");
//            }
//        }

//        private void BrowseImport_Click(object sender, RoutedEventArgs e)
//        {
//            OpenFileDialog dlg = new OpenFileDialog();
//            dlg.Filter = "Inventor Files (*.ipt;*.iam;*.idw;*.dwg;*.ipn)|*.ipt;*.iam;*.idw;*.dwg;*.ipn";

//            if (dlg.ShowDialog() == true)
//                TxtImportPath.Text = dlg.FileName;
//        }

//        private void OpenImport_Click(object sender, RoutedEventArgs e)
//        {
//            if (!System.IO.File.Exists(TxtImportPath.Text))
//            {
//                MessageBox.Show("Select valid file.");
//                return;
//            }

//            try
//            {
//                _app?.Documents.Open(TxtImportPath.Text);
//                TxtStatus.Text = "File imported successfully.";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void BrowseExport_Click(object sender, RoutedEventArgs e)
//        {
//            FolderBrowserDialog dlg = new FolderBrowserDialog();

//            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//                TxtExportPath.Text = dlg.SelectedPath;
//        }

//        private void Export_Click(object sender, RoutedEventArgs e)
//        {
//            if (_app?.ActiveDocument == null)
//            {
//                MessageBox.Show("No active document.");
//                return;
//            }

//            if (string.IsNullOrWhiteSpace(TxtExportPath.Text))
//            {
//                MessageBox.Show("Select export folder.");
//                return;
//            }

//            try
//            {
//                Document doc = _app.ActiveDocument;

//                string fileName = System.IO.Path.GetFileName(doc.FullFileName);
//                string savePath = System.IO.Path.Combine(TxtExportPath.Text, fileName);

//                doc.SaveAs(savePath, false);

//                TxtStatus.Text = "File exported successfully.";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void Clear_Click(object sender, RoutedEventArgs e)
//        {
//            TxtImportPath.Clear();
//            TxtExportPath.Clear();
//            TxtStatus.Clear();
//        }
//    }
//}





//using System;
//using Inventor;
using System;

using WpfWindow = System.Windows.Window;
using WpfMessageBox = System.Windows.MessageBox;
using WpfRoutedEventArgs = System.Windows.RoutedEventArgs;
using WinForms = System.Windows.Forms;



namespace InventorToolkit.FileManager
{
    public partial class MainWindow : WpfWindow
    {
        //private Inventor.Application? _app;
        private global::Inventor.Application? _app;

        public MainWindow(global::Inventor.Application app)
        {
            InitializeComponent();
            _app = app;
        }

        //public MainWindow()
        //{
        //    InitializeComponent();
        //    ConnectInventor();
        //}

        //private void ConnectInventor()
        //{
        //    try
        //    {
        //        Type? inventorType = Type.GetTypeFromProgID("Inventor.Application");

        //        if (inventorType != null)
        //        {
        //            //_app = (Inventor.Application)Activator.CreateInstance(inventorType)!;
        //            _app = (global::Inventor.Application)Activator.CreateInstance(inventorType)!;
        //            _app.Visible = true;
        //        }
        //    }
        //    catch
        //    {
        //        WpfMessageBox.Show("Inventor not available.");
        //    }
        //}

        //private void ConnectInventor()
        //{
        //    try
        //    {
        //        _app = (global::Inventor.Application)
        //            System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application");
        //    }
        //    catch
        //    {
        //        WpfMessageBox.Show("Open Autodesk Inventor first, then use File Manager.");
        //    }
        //}

        //private void ConnectInventor()
        //{
        //    _app = InventorToolkit.CommandHandler.AppInstance;

        //    if (_app == null)
        //    {
        //        WpfMessageBox.Show("Inventor application not found.");
        //    }
        //}

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
                //_app?.Documents.Open(TxtImportPath.Text);
                //_app.Documents.Open(TxtImportPath.Text, true);

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


        //private void BrowseExport_Click(object sender, WpfRoutedEventArgs e)
        //{
        //    WinForms.FolderBrowserDialog dlg = new WinForms.FolderBrowserDialog();

        //    if (dlg.ShowDialog() == WinForms.DialogResult.OK)
        //        TxtExportPath.Text = dlg.SelectedPath;
        //}

        //private void BrowseExport_Click(object sender, WpfRoutedEventArgs e)
        //{
        //    WinForms.FolderBrowserDialog dlg = new WinForms.FolderBrowserDialog();

        //    if (dlg.ShowDialog() == WinForms.DialogResult.OK)
        //        TxtExportPath.Text = dlg.SelectedPath;
        //}

        //private void Export_Click(object sender, WpfRoutedEventArgs e)
        //{
        //    if (_app?.ActiveDocument == null)
        //    {
        //        WpfMessageBox.Show("No active document.");
        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(TxtExportPath.Text))
        //    {
        //        WpfMessageBox.Show("Select export folder.");
        //        return;
        //    }

        //    try
        //    {
        //        //Document doc = _app.ActiveDocument;
        //        global::Inventor.Document doc = _app.ActiveDocument;

        //        string fileName = System.IO.Path.GetFileName(doc.FullFileName);
        //        string savePath = System.IO.Path.Combine(TxtExportPath.Text, fileName);

        //        doc.SaveAs(savePath, false);

        //        TxtStatus.Text = "File exported successfully.";
        //        WpfMessageBox.Show("File exported successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        WpfMessageBox.Show(ex.Message);
        //    }
        //}

        //private void Export_Click(object sender, WpfRoutedEventArgs e)
        //{
        //    if (_app == null || _app.ActiveDocument == null)
        //    {
        //        WpfMessageBox.Show("No active document.");
        //        return;
        //    }

        //    try
        //    {
        //        global::Inventor.Document doc = _app.ActiveDocument;

        //        string defaultName = System.IO.Path.GetFileName(doc.FullFileName);

        //        Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();

        //        saveDialog.Title = "Export Inventor File";
        //        saveDialog.FileName = defaultName;

        //        saveDialog.Filter =
        //            "Inventor Part (*.ipt)|*.ipt|" +
        //            "Inventor Assembly (*.iam)|*.iam|" +
        //            "Inventor Drawing (*.idw)|*.idw|" +
        //            "AutoCAD Drawing (*.dwg)|*.dwg|" +
        //            "PDF (*.pdf)|*.pdf";

        //        if (saveDialog.ShowDialog() == true)
        //        {
        //            doc.SaveAs(saveDialog.FileName, false);

        //            //TxtExportPath.Text = saveDialog.FileName;
        //            TxtStatus.Text = "File exported successfully.";

        //            WpfMessageBox.Show("File exported successfully.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WpfMessageBox.Show(ex.Message);
        //    }
        //}

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

        //private void Clear_Click(object sender, WpfRoutedEventArgs e)
        //{
        //    TxtImportPath.Clear();
        //    TxtExportPath.Clear();
        //    TxtStatus.Clear();
        //}



        private void Clear_Click(object sender, WpfRoutedEventArgs e)
        {
            TxtImportPath.Clear();
            TxtStatus.Clear();
        }
    }
}