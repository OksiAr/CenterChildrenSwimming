using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CenterSwimming.Components
{
    public partial class Service
    {
        public decimal TotalCost
        {
            get
            {
                if (Discount != 0)
                    return Cost - (Cost * (decimal)Discount / 100);
                else
                    return Cost;
            }

        }
        public string CostTime
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost:0} рублей за {DurationInMinutes} минут";
                else
                    return $" {Cost - (Cost * (decimal)Discount / 100):0} рублей за {DurationInMinutes} минут";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string DiscountStr
        {
            get
            {
                if (Discount == 0)
                    return null;
                else
                    return $"* скидка {Discount}%";

            }

        }
        public Brush DiscountBrush
        {
            get
            {
                if (Discount != 0)
                    return new SolidColorBrush(Colors.LightGreen);
                else
                    return new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}
