// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iPadSplitView.iOS
{
    [Register ("AboutViewController")]
    partial class AboutViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AlarmingDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VersionDesc { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AlarmingDesc != null) {
                AlarmingDesc.Dispose ();
                AlarmingDesc = null;
            }

            if (VersionDesc != null) {
                VersionDesc.Dispose ();
                VersionDesc = null;
            }
        }
    }
}