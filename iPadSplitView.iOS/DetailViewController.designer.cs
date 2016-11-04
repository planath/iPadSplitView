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
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detailDescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmailTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstNameTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastNameTextView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detailDescriptionLabel != null) {
                detailDescriptionLabel.Dispose ();
                detailDescriptionLabel = null;
            }

            if (EmailTextView != null) {
                EmailTextView.Dispose ();
                EmailTextView = null;
            }

            if (FirstNameTextView != null) {
                FirstNameTextView.Dispose ();
                FirstNameTextView = null;
            }

            if (LastNameTextView != null) {
                LastNameTextView.Dispose ();
                LastNameTextView = null;
            }
        }
    }
}