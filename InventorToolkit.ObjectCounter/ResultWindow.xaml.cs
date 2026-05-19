//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InventorToolkit.ObjectCounter
//{
//    class ResultWindow
//    {
//    }
//}




//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public partial class ResultWindow : Window
//    {
//        public ResultWindow(int total, int circle, int rectangle, int line, int arc)
//        {
//            InitializeComponent();

//            GridResult.ItemsSource = new List<object>
//{
//    new { Shape = "Total", Count = total },
//    new { Shape = "Circle", Count = circle },
//    new { Shape = "Rectangle", Count = rectangle },
//    new { Shape = "Line", Count = line },
//    new { Shape = "Arc", Count = arc }
//};
//        }
//    }
//}

//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public partial class ResultWindow : Window
//    {
//        public ResultWindow(Dictionary<string, int> data)
//        {
//            InitializeComponent();

//            foreach (var item in data)
//            {
//                GridResult.Items.Add(new
//                {
//                    Shape = item.Key,
//                    Count = item.Value
//                });
//            }
//        }
//    }
//}




using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace InventorToolkit.ObjectCounter
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(Dictionary<string, int> data)
        {
            InitializeComponent();

            var total = data.FirstOrDefault(x => x.Key == "Total");
            GridResult.Items.Add(new { Shape = total.Key, Count = total.Value });

            foreach (var item in data.Where(x => x.Key != "Total"))
            {
                GridResult.Items.Add(new
                {
                    Shape = item.Key,
                    Count = item.Value
                });
            }
        }
    }
}