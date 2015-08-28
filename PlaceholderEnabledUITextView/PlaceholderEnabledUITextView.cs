namespace PlaceholderEnabledUITextView
{
    using System;
    using System.ComponentModel;

    using CoreGraphics;
    using Foundation;
    using UIKit;

    [Register("PlaceholderEnabledUITextView")]
    [DesignTimeVisible(true)]
    public class PlaceholderEnabledUITextView : UITextView
    {
        private UILabel placeholderLabel;

        public PlaceholderEnabledUITextView()
            : base()
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(CGRect frame)
            : base(frame)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(CGRect frame, NSTextContainer container)
            : base(frame, container)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(NSCoder coder)
            : base(coder)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(NSObjectFlag t)
            : base(t)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(IntPtr handler)
            : base(handler)
        {
            this.CommonInit();
        }

        [Export("Placeholder")]
        [Browsable(true)]
        public string Placeholder { get; set; }

        [Export("PlaceholderColor")]
        [Browsable(true)]
        public UIColor PlaceholderColor { get; set; }

        [Export("PlaceholderFont")]
        [Browsable(true)]
        public UIFont PlaceholderFont { get; set; }

        [Export("AllowWhiteSpace")]
        [Browsable(true)]
        public bool AllowWhiteSpace { get; set; }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var inset = this.TextContainerInset;
            var leftInset = inset.Left + this.TextContainer.LineFragmentPadding;
            var rightInset = inset.Left + this.TextContainer.LineFragmentPadding;
            var maxSize = new CGSize()
                {
                    Width = this.Frame.Width - (leftInset + rightInset),
                    Height = this.Frame.Height - (inset.Top + inset.Bottom)
                };
            var size = new NSString(this.Placeholder).StringSize(this.PlaceholderFont, maxSize, UILineBreakMode.WordWrap);
            var frame = new CGRect(new CGPoint(leftInset, inset.Top), size);

            this.placeholderLabel = new UILabel(frame)
                {
                    BackgroundColor = UIColor.Clear,
                    Font = this.PlaceholderFont,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0,
                    Text = this.Placeholder,
                    TextColor = this.PlaceholderColor
                };
            
            this.Add(this.placeholderLabel);
        }

        private void CommonInit()
        {
            this.PlaceholderColor = UIColor.Gray;
            this.PlaceholderFont = UIFont.SystemFontOfSize(12);

            this.Started += this.OnStarted;

            this.Ended += this.OnEnded;
        }

        private void OnStarted(object sender, EventArgs e)
        {
            this.placeholderLabel.Hidden = true;
        }

        private void OnEnded(object sender, EventArgs e)
        {
            if (this.AllowWhiteSpace)
            {
                this.placeholderLabel.Hidden = !string.IsNullOrEmpty(this.Text);
            }
            else
            {
                this.placeholderLabel.Hidden = !string.IsNullOrWhiteSpace(this.Text);
            }
        }
    }
}