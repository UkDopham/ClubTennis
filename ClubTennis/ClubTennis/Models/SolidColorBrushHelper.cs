﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClubTennis.Models
{
    public static class SolidColorBrushHelper
    {
        public static SolidColorBrush Green()
        {
            return new SolidColorBrush(Color.FromRgb(90, 193, 142));
        }

        public static SolidColorBrush DarkGreen()
        {
            return new SolidColorBrush(Color.FromRgb(81, 173, 127)); 
        }
        public static SolidColorBrush Transparent()
        {
            return new SolidColorBrush(Colors.Transparent);
        }
    }
}
