# Dynamic Crops 

[![Downloads](https://img.shields.io/nuget/dt/mttblss.DynamicCrops?color=cc9900)](https://www.nuget.org/packages/mttblss.DynamicCrops/)
[![NuGet](https://img.shields.io/nuget/vpre/mttblss.DynamicCrops?color=0273B3)](https://www.nuget.org/packages/mttblss.DynamicCrops)
[![GitHub license](https://img.shields.io/github/license/mttblss/DynamicCrops?color=8AB803)](../LICENSE)

An extension for the Umbraco CMS to handle images in variable aspect ratio containers, ensuring that the focal point of the image is always respected.

<!--
Including screenshots is a really good idea! 

If you put images into /docs/screenshots, then you would reference them in this readme as, for example:

<img alt="..." src="https://github.com/mttblss/DynamicCrops/blob/develop/docs/screenshots/screenshot.png">
-->

## Installation

Add the package to an existing Umbraco website (v13+) from nuget:

`dotnet add package mttblss.DynamicCrops`

## Usage

Once installed, visit the 'Settings' section in the Umbraco back office:

- Create a new 'Data Type'
   - Name it appropriately for the dynamically sized content it will be used to select from the media library (for example 'Banner Image Picker'
   - Select the 'Media Picker' (Umbraco.MediaPicker3) property editor
   - Add 'Image' to the Accepted Types
   - Check the 'Enable Focal Point' option
   - Add two 'Image Crops' 
      - The fist crop should represent the widest, or most letter-box aspect-ratio that the image could be displayed in the frontend.  
      - The second crop should represent the tallest, or most portrait aspect-ratio that the image could be displayed in the frontend.
      - For both crops the actual pixel count does not matter, what is important here is the correct ratio between the width and height.
   - Save the Data Type

![Data Type Screenshot](https://raw.githubusercontent.com/mttblss/DynamicCrops/main/docs/screenshots/banner-picker.png)

- Use your new data type in the appropriate document type(s)
- Wire up the positioning in your view(s)

## Views

In a view we can set a focal-point position using an inline `style` attribute to the element to define the calculated position based on the crops.  

- For an `<img>` tag add `style="@Model.Image.ObjectPositionCss()"`
- For a background image use `@Model.Image.BackgroundPositionCss()` in the style tag (you are most likely already injecting the URL here too)

These extension methods take the standard Umbraco `MediaWithCrops` object and output the following markup respectively
- `object-position: `[left]`% `[top]`%;` or
- `background-position: `[left]`% `[top]`%;`


## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).

## Acknowledgments

TODO