Add the component to your designer however you want. The namespace, class name, and export name are all `PlaceholderEnabledUITextView`.

The control has four properties:

**Placeholder** 

* Type: `String`
* Default: `null`
* This is the placeholder text you want to appear

**PlaceholderColor**

* Type: `UIColor`
* Default: `Gray`
* The colo[u]r of the placeholder text

**PlaceholderFont**

* Type: `UIFont`
* Default: `UIFont.SystemFontOfSize(12)`
* The font name/style/size of the placeholder 

**AllowWhiteSpace**

* Type: `Boolean`
* Default: `False`
* Once the user moves focus away from the `UITextView` we check to see if they've entered any text, if not then the placeholder is re-shown. by default we do a `IsNullOrWhiteSpace` check, if you want to do a `IsNullOrEmpty` check then set this to true instead of false.
