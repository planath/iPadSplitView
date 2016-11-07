using System;
using System.Collections.Generic;
using System.Text;
using iPadSplitView.Core.Model;
using UIKit;

namespace iPadSplitView.iOS.Helper
{
    public static class ExtensionMethods
    {
        public static UIColor GetUIColor(this Color value)
        {
            switch (value)
            {
                case Color.Green:
                    return UIColor.Green;
                case Color.Yellow:
                    return UIColor.Yellow;
                case Color.Red:
                    return UIColor.Red;
                case Color.Orange:
                    return UIColor.Orange;
                default:
                    return UIColor.Clear;
            }
        }
    }
}
