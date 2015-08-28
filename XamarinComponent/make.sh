#!/bin/bash
# Call this script with the component's build number

echo "build #$1"

mono xamarin-component.exe create-manually PlaceholderEnabledUITextView-$1.xam --name="Placeholder enabled UITextView" --summary="A UITextView extender so you can stop asking why UITextField has a placeholder but UITextView doesn't?!" --publisher="Robert Waggott" --website="https://github.com/robert-waggott/Xamarin.PlaceholderEnabledUITextView" --details="Details.md" --license="License.md" --getting-started="GettingStarted.md" --icon="icons/PlaceholderEnabledUITextView_128x128.png" --icon="icons/PlaceholderEnabledUITextView_512x512.png" --library="ios-unified":"lib/PlaceholderEnabledUITextView.dll" --sample="iOS Sample. Sample of how to use the component in your iOS application.":"samples/Sample.sln"