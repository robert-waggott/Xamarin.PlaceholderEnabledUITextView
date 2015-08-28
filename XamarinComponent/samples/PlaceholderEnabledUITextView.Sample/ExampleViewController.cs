namespace PlaceholderEnabledUITextView.Sample
{
	using System;
	using CoreGraphics;

	using Foundation;
	using UIKit;

	public partial class ExampleViewController : UIViewController
	{
		public ExampleViewController()
			: base("ExampleViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var placeholderEnabledUITextView = new PlaceholderEnabledUITextView(new CGRect(35, 115, 250, 250))
			{ 
				Editable = true,
				Placeholder = "Lorem ipsum dolor sit er elit lamet, consectetaur cillium adipisicing pecu, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
			};

			this.Add(placeholderEnabledUITextView);

			this.btnRemoveFocus.TouchUpInside += (sender, e) => 
			{
				placeholderEnabledUITextView.ResignFirstResponder();
			};
		}
	}
}