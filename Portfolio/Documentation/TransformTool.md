# Blazor CSS Transform Tool Documentation

## Overview

The Blazor CSS Transform Tool is a component designed for manipulating CSS transformations on HTML elements. It provides a user-friendly interface with sliders to control various transformation properties such as translate, rotate, skew, and perspective.

## CSS Transform Tool Guide

Welcome to the CSS Transform Tool! This guide will help you make the most of the tool's features, starting with how to upload your own HTML and CSS for customization.

### Getting Started

The transform tool is design to work with your own html and css and provide you with new css to add to your project. The new css when added to your current stylesheets will carry over any changes you made with the tool.

1. **Uploading Your HTML and CSS:**
   - Navigate to the "Upload" tab.
   - Click on the "Choose File" button to select your HTML file.
   - Optionally, select a CSS file by clicking on the "Choose File" button under the CSS section.
   - Click the "Upload" button to apply your files to the tool.

2. **Selecting an Element:**
   - In the "Transform" tab, use the dropdown menu labeled "Select Element" to choose an HTML element from your uploaded file.

### Tool Tabs

Explore the three tabs to unleash the power of CSS transformations:

1. **Transform Tab:**
   - Use sliders to modify properties like skew, rotation, and translation.
   - Experiment with the "Test" button to visualize changes on a sample object.
   - Adjust the tool's position on the screen using the alignment buttons.

2. **CSS Tab:**
   - View, copy, or download the CSS changes made in the "Transform" tab.
   - The "Copy" button instantly copies the CSS to your clipboard.

3. **Upload Tab:**
   - Easily switch between uploaded HTML and CSS files using the tab navigation.
   - Make changes to your original files and re-upload them for continuous experimentation.

## Understanding Transformations

### Perspective (3D Effect):

- By default, perspective is turned off, ensuring 2D transformations. Enable it for a captivating 3D effect.

### Transform Properties:

- **SkewX:** Tilt an element along the X-axis.
- **TranslateX, TranslateY, TranslateZ:** Move an element along the X, Y, and Z axes.
- **RotateX, RotateY, RotateZ:** Rotate an element around the X, Y, and Z axes.

### How Transformations Interact:

Perspective Impact:

Enabling perspective influences how other transformations are perceived, adding depth to your design.

Nesting Elements:

The way you structure and nest HTML elements can significantly alter how transformations are applied:

    Hierarchy Matters: Elements are transformed based on their position in the HTML hierarchy. A child element's transformation can be influenced by its parent.

    Local vs. Global Transformations: Understand how transformations on parent elements affect child elements. Experiment with nested elements to see how transformations propagate.

Troubleshooting Tips

    Check Console for Errors: If you encounter unexpected behavior, open your browser's console (usually F12) to check for any error messages.

    Inspect Element: Use your browser's developer tools to inspect individual elements and their applied styles.

Example Usage

html

<!-- Applying transformations to nested HTML elements -->
<div style="@parentTransform.TransformString">
    <p style="@childTransform.TransformString">Nested Transformations!</p>
</div>

Conclusion

The CSS Transform Tool empowers you to bring life to your web elements effortlessly. Upload your HTML and CSS files, explore, experiment, and watch your designs transform dynamically. Understanding the impact of nested elements will enhance your ability to create stunning visual effects. Happy coding!
### How Transformations Interact

#### Perspective Impact:
- Enabling perspective influences how other transformations are perceived, adding depth to your design.

#### Nesting Elements:
- The positioning and nesting of HTML elements can alter how transformations are applied.

### Example Usage

```html
<!-- Applying transformations to an HTML element -->
<div style="@tool.TransformParams.TransformString">Hello, Transform World!</div>
```

### Conclusion

The CSS Transform Tool empowers you to bring life to your web elements effortlessly. Upload your HTML and CSS files, explore, experiment, and watch your designs transform dynamically. Happy coding! 
## Getting Started

To integrate the Blazor CSS Transform Tool into your project, follow these steps:

1. Include the tool component in your Blazor page or component.
   ```csharp
   @using System.Timers
   @inject IJSRuntime JS
   @inject CssParser Parser
   @inject ToastService Toaster

   @ChildContent

   @if (Tool is not null && Tool.IsInitialized == true)
   {
       <!-- Tool UI code goes here -->
   }

   @code {
       // Code-behind logic goes here
   }
   ```

2. Initialize the tool in the `OnAfterRenderAsync` lifecycle method.
   ```csharp
   protected override async Task OnAfterRenderAsync(bool firstRender)
   {
       if (firstRender)
       {
           Tool ??= new();
           // Additional initialization logic goes here
       }
       await base.OnAfterRenderAsync(firstRender);
   }
   ```

## Tabs

### Transform Tab

The Transform Tab allows users to select an HTML element and apply transformations using sliders.

#### Usage

1. Open the Transform Tab by clicking on the "Transform" button.
2. Choose an HTML element from the dropdown list.
3. Use sliders to manipulate the element's transform properties.
4. Additional options like resetting transformations and adjusting perspective are available.

### CSS Tab

The CSS Tab provides options to view, copy, or download the generated CSS code reflecting the applied transformations.

#### Usage

1. Navigate to the CSS Tab by clicking on the "CSS" button.
2. View the generated CSS code.
3. Copy to clipboard or download the CSS file.

### File Upload Tab

The File Upload Tab allows users to upload HTML and optional CSS files for manipulation.

#### Usage

1. Go to the File Upload Tab by clicking on the "Upload" button.
2. Upload HTML and optional CSS files.
3. Make transformations using the tool.
4. Navigate to the CSS Tab to view, copy, or download the updated CSS.

## Additional Functions

- **Reset All:** Resets all transformations on the currently selected object.
- **Try Me Button:** Allows testing the tool on a predefined example object.

## Conclusion

The Blazor CSS Transform Tool simplifies the process of applying CSS transformations to HTML elements. Integrate it into your project for a seamless experience in manipulating and visualizing transformations.