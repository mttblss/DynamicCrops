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

There are two approaches to applying focal-point positions in your views.

### Option 1 — Inline styles

Add the calculated position directly to an element via an inline `style` attribute.

**For an `<img>` tag:**

```html
<img src="@Model.BannerImage.Url()" style="@Model.BannerImage.ObjectPositionCss()" alt="">
```

**For a background image:**

```html
<div style="background-image: url('@Model.BannerImage.Url()'); @Model.BannerImage.BackgroundPositionCss()">
```

These extension methods accept a `MediaWithCrops` object and output the calculated focal-point position, for example `object-position: 30% 66%;` or `background-position: 30% 66%;`.

> **Note:** Inline styles require `unsafe-inline` in your Content Security Policy.

### Option 2 — CSS classes (CSP-friendly for `<img>` elements)

The package includes a pre-built stylesheet (minified, 5 KB) that replaces inline styles with utility classes. For `<img>` tags this approach is fully compatible with a strict CSP — the image URL goes in the `src` attribute, not a style, so no inline styles are required at all.

**1. Add the stylesheet to your layout**

```html
<link rel="stylesheet" href="/App_Plugins/DynamicCrops/css/dynamiccrops.css">
```

**2. Use `ObjectPositionClass()` in your view**

```html
<img src="@Model.BannerImage.Url()" class="@Model.BannerImage.ObjectPositionClass()" alt="">
```

This outputs three classes — a scoped marker and two position utility classes, for example `dc-op opx30 opy66`. The marker class (`dc-op`) applies `object-fit: cover` and `object-position`, reading the values from CSS custom properties (`--dc-x`, `--dc-y`) set by the position classes and scoped entirely to that element.

> **Background images and CSP:** `BackgroundPositionClass()` is included for completeness and handles `background-position` via CSS classes, but a content-managed background image still requires an inline style for the URL itself, `style="background-image: url('...')`, which cannot be avoided without JavaScript. For strict CSP, the recommended approach is to use an `<img>` tag with `object-fit: cover` rather than a CSS background image — it achieves the same visual result, is more accessible, and works fully within a strict CSP.

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).
