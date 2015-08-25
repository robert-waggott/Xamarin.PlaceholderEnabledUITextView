namespace PlaceholderEnabledUITextView
{
    using System;

    using CoreGraphics;
    using Foundation;
    using UIKit;

    public class PlaceholderEnabledUITextView : UITextView
    {
        private UILabel placeholder;

        public PlaceholderEnabledUITextView() : base()
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(CGRect frame) : base(frame)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(CGRect frame, NSTextContainer container) : base(frame, container)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(NSCoder coder) : base(coder)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(NSObjectFlag t) : base(t)
        {
            this.CommonInit();
        }

        public PlaceholderEnabledUITextView(IntPtr handler) : base(handler)
        {
            this.CommonInit();
        }

        public string Placeholder { get; set; }

        public UIColor PlaceholderColor { get; set; }

        public UIFont PlaceholderFont { get; set; }

        public bool AllowWhiteSpace { get; set; }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (this.placeholder == null)
            {
                var maxSize = this.Frame.Size;
                var size = new NSString(this.Placeholder).StringSize(this.PlaceholderFont, maxSize, UILineBreakMode.WordWrap);
                var frame = new CGRect(this.Frame.Location, size);

                this.placeholder = new UILabel(frame)
                    {
                        BackgroundColor = UIColor.Clear,
                        Font = this.PlaceholderFont,
                        LineBreakMode = UILineBreakMode.WordWrap,
                        Lines = 0,
                        TextColor = this.PlaceholderColor
                    };

                this.Add(this.placeholder);
            }
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
            this.placeholder.Hidden = true;
        }

        private void OnEnded(object sender, EventArgs e)
        {
            if (this.AllowWhiteSpace)
            {
                this.placeholder.Hidden = string.IsNullOrEmpty(this.Text);
            }
            else
            {
                this.placeholder.Hidden = string.IsNullOrWhiteSpace(this.Text);
            }
        }
    }
}