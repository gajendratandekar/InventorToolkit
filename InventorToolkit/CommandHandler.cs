
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