# CSS Transform Tool Documentation

## Overview

The CSS Transform Tool is a component designed for manipulating CSS transformations on HTML elements. It provides a user-friendly interface with sliders to control various **css transform** properties such as **translate**, **rotate**, **skew**, and **perspective**.

### Tool Tabs

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

4. **Documentation Tab:**
   - show this documentation

---

## CSS Transform Tool Guide

Welcome to the CSS Transform Tool! This guide will help you make the most of the tool's features, starting with how to upload your own HTML and CSS for customization.

### Getting Started

The transform tool is design to work with your own html and css and provide you with new css to add to your project. The new css when added to your current stylesheets will carry over any changes you made with the tool.

1. **Uploading Your HTML and CSS:**
   - Navigate to the **Upload** tab.
   - Click on the top **Choose File** button to select your HTML file.
   - Optionally, select a CSS file by clicking on the bottom **Choose File** button.
   - Click the Upload button to to display your web-page.

2. **Selecting an Element:**
   - In the **Transform** tab, use the selector menu at the top of the tool labeled "Select Element" to choose an HTML element from your uploaded file.

3. **Transform Your HTML:**
    - use the sliders found on the **Transform** tab to change the elements on your web-page

4. **Copy Your New CSS**
    - when your finished editing, there are 2 ways to get your changes into your project. First click the **CSS** tab.
    - in this tab, you  will be able to view 

---

## Understanding Transformations

### Perspective (3D Effect):

- By default, perspective is turned off, ensuring 2D transformations. Enable it for a captivating 3D effect.

### Perspective Impact:

Enabling the perspective toggle switch influences how other transformations are perceived, adding depth to your design. The css perspective function changes the perceived distance between the back most layer and the viewer. This slider correlates exactly to the css perspective property including the effects it has on the other transform properties.

#### Nesting Elements:

The way you structure and nest HTML elements can significantly alter how transformations are applied. For instance when editing a nested object, it takes on the scope of it's outermost parent. This means that if you apply a rotation, the vertex of the rotation point will be based on the outer most html element that your target is nesting in. This can result in a rotation appearing as more of a sweeping motion rather than oriented around a point within the element.

#### **Hierarchy Matters**:

Elements are transformed based on their position in the HTML hierarchy. A child element's transformation can be influenced by its parent.
