---
id: 87b7701c-d551-46fa-8b2e-1fc85c5815b6
title: Change The Font  
brief: "This recipe shows how to change the font of a UILabel"
article: 
  - title: Enumerate Fonts
    url: https://github.com/xamarin/recipes/tree/master/Recipes/ios/standard_controls/fonts/enumerate_fonts/
sdk:
  - title: UILabel Class Reference
    url: https://developer.apple.com/library/ios/documentation/UIKit/Reference/UILabel_Class/index.html
---

# Recipe
This short recipe will first create a new label, and display some text in it. We will then set the font name and size, and lastly will add some aditional properties affecting how the label is displayed.


```csharp
using UIKit;
using Foundation;
using CoreGraphics;

// 1. Create a label and assign some text to display
var customLabel = new UILabel (new CGRect(10,10,300,30));
customLabel.Text ="Display this text in custom font";
customLabel.TextColor = UIColor.Magenta;

//Displays label in Sketches
customLabel 

// 2. Set the font name and size:
customLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);

// 3. Optionally set additional properties that affect the display
customLabel.AdjustsFontSizeToFitWidth = true; // gets smaller if it doesn't fit
customLabel.MinimumFontSize = 12f; // never gets smaller than this size
customLabel.LineBreakMode = UILineBreakMode.TailTruncation;
customLabel.Lines = 1; // 0 means unlimited

//Display label in simulator
RootView.AddSubview(customLabel);
```


# Additional Information

A list of fonts available on iOS 5 (refer to the [Enumerate Fonts](/Recipes/ios/standard_controls/fonts/enumerate_fonts) recipe to see how to
generate this list):

AcademyEngravedLetPlain

AmericanTypewriter-CondensedLight

AmericanTypewriter-Light

AmericanTypewriter

AmericanTypewriter-Condensed

AmericanTypewriter-Bold

AmericanTypewriter-CondensedBold

AppleColorEmoji

AppleSDGothicNeo-Medium

AppleSDGothicNeo-Bold

ArialMT

Arial-ItalicMT

Arial-BoldMT

Arial-BoldItalicMT

ArialHebrew

ArialHebrew-Bold

ArialRoundedMTBold

BanglaSangamMN-Bold

BanglaSangamMN

Baskerville

Baskerville-Italic

Baskerville-SemiBold

Baskerville-SemiBoldItalic

Baskerville-Bold

Baskerville-BoldItalic

BodoniSvtyTwoITCTT-Book

BodoniSvtyTwoITCTT-BookIta

BodoniSvtyTwoITCTT-Bold

BodoniSvtyTwoOSITCTT-Book

BodoniSvtyTwoOSITCTT-BookIt

BodoniSvtyTwoOSITCTT-Bold

BodoniSvtyTwoSCITCTT-Book

BodoniOrnamentsITCTT

BradleyHandITCTT-Bold

ChalkboardSE-Light

ChalkboardSE-Regular

ChalkboardSE-Bold

Chalkduster

Cochin

Cochin-Italic

Cochin-Bold

Cochin-BoldItalic

Copperplate-Light

Copperplate

Copperplate-Bold

Courier

Courier-Oblique

Courier-Bold

Courier-BoldOblique

CourierNewPSMT

CourierNewPS-BoldMT

CourierNewPS-BoldItalicMT

CourierNewPS-ItalicMT

DBLCDTempBlack

DevanagariSangamMN

DevanagariSangamMN-Bold

Didot

Didot-Italic

Didot-Bold

EuphemiaUCAS

EuphemiaUCAS-Italic

EuphemiaUCAS-Bold

Futura-Medium

Futura-MediumItalic

Futura-CondensedMedium

Futura-CondensedExtraBold

GeezaPro

GeezaPro-Bold

Georgia

Georgia-Italic

Georgia-Bold

Georgia-BoldItalic

GillSans-Light

GillSans-LightItalic

GillSans

GillSans-Italic

GillSans-Bold

GillSans-BoldItalic

GujaratiSangamMN

GujaratiSangamMN-Bold

GurmukhiMN

GurmukhiMN-Bold

STHeitiSC-Light

STHeitiSC-Medium

STHeitiTC-Light

STHeitiTC-Medium

Helvetica-Light

Helvetica-LightOblique

Helvetica

Helvetica-Oblique

Helvetica-Bold

Helvetica-BoldOblique

HelveticaNeue-UltraLight

HelveticaNeue-UltraLightItalic

HelveticaNeue-Light

HelveticaNeue-LightItalic

HelveticaNeue

HelveticaNeue-Italic

HelveticaNeue-Medium

HelveticaNeue-Bold

HelveticaNeue-BoldItalic

HelveticaNeue-CondensedBold

HelveticaNeue-CondensedBlack

HiraKakuProN-W3

HiraKakuProN-W6

HiraMinProN-W3

HiraMinProN-W6

HoeflerText-Regular

HoeflerText-Italic

HoeflerText-Black

HoeflerText-BlackItalic

Kailasa

Kailasa-Bold

KannadaSangamMN

KannadaSangamMN-Bold

MalayalamSangamMN

MalayalamSangamMN-Bold

Marion-Regular

Marion-Italic

Marion-Bold

MarkerFelt-Thin

MarkerFelt-Wide

Noteworthy-Light

Noteworthy-Bold

Optima-Italic

Optima-Regular

Optima-Bold

Optima-BoldItalic

Optima-ExtraBlack

OriyaSangamMN

OriyaSangamMN-Bold

Palatino-Roman

Palatino-Italic

Palatino-Bold

Palatino-BoldItalic

Papyrus

Papyrus-Condensed

PartyLetPlain

SinhalaSangamMN

SinhalaSangamMN-Bold

SnellRoundhand

SnellRoundhand-Bold

SnellRoundhand-Black

TamilSangamMN

TamilSangamMN-Bold

TeluguSangamMN

TeluguSangamMN-Bold

Thonburi

Thonburi-Bold

TimesNewRomanPSMT

TimesNewRomanPS-ItalicMT

TimesNewRomanPS-BoldMT

TimesNewRomanPS-BoldItalicMT

TrebuchetMS

TrebuchetMS-Italic

TrebuchetMS-Bold

Trebuchet-BoldItalic

Verdana

Verdana-Italic

Verdana-Bold

Verdana-BoldItalic

ZapfDingbatsITC

Zapfino
