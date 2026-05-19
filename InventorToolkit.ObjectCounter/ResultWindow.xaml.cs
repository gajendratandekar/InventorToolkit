
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