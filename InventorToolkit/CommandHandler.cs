//using System.Windows;
//using Inventor;

//namespace InventorToolkit
//{
//    public static class CommandHandler
//    {
//        public static void RunObjectCounter(NameValueMap context)
//        {
//            MessageBox.Show("Inventor Toolkit UI loaded successfully");
//        }
//    }
//}



//using Inventor;
//using InventorToolkit.ObjectCounter;

//namespace InventorToolkit
//{
//    public static class CommandHandler
//    {
//        public static Application AppInstance;

//        public static void RunObjectCounter(NameValueMap context)
//        {
//            var result = ObjectCounterService.Count(AppInstance);

//            if (result == null)
//                return;

//            ResultWindow window = new ResultWindow(
//                result.Value.circle,
//                result.Value.rectangle,
//                result.Value.line,
//                result.Value.arc,
//                result.Value.arc);

//            window.ShowDialog();
//        }
//        public static void RunFileManager(NameValueMap context)
//        {
//            InventorToolkit.FileManager.MainWindow win =
//                new InventorToolkit.FileManager.MainWindow();

//            win.ShowDialog();
//        }
//    }
//} 

//using Inventor;
//using InventorToolkit.ObjectCounter;

//namespace InventorToolkit
//{
//    public static class CommandHandler
//    {
//        public static Application AppInstance;

//        public static void RunObjectCounter(NameValueMap context)
//        {
//            var result = ObjectCounterService.Count(AppInstance);

//            if (result == null)
//                return;

//            //ResultWindow window = new ResultWindow(
//            //    result.Value.circle,
//            //    result.Value.rectangle,
//            //    result.Value.line,
//            //    result.Value.arc,
//            //    result.Value.arc);

//            ResultWindow window = new ResultWindow(
//    result.Value.total,
//    result.Value.circle,
//    result.Value.rectangle,
//    result.Value.line,
//    result.Value.arc);

//            window.ShowDialog();
//        }

//        public static void RunFileManager(NameValueMap context)
//        {
//            var win = new InventorToolkit.FileManager.MainWindow(AppInstance);
//            win.ShowDialog();
//        }
//    }
//}


using Inventor;
using InventorToolkit.ObjectCounter;

namespace InventorToolkit
{
    public static class CommandHandler
    {
        public static Application AppInstance;

        public static void RunObjectCounter(NameValueMap context)
        {
            var result = ObjectCounterService.Count(AppInstance);

            if (result == null)
                return;

            ResultWindow window = new ResultWindow(result);
            window.ShowDialog();
        }

        public static void RunFileManager(NameValueMap context)
        {
            var win = new InventorToolkit.FileManager.MainWindow(AppInstance);
            win.ShowDialog();
        }
    }
}