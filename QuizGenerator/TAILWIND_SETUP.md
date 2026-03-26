# Tailwind CSS Setup Guide

## Overview
Tailwind CSS has been successfully integrated into your Blazor project. The setup uses PostCSS to process Tailwind directives and generate the final CSS file.

## Files Created/Modified

### Configuration Files
- **tailwind.config.js** - Tailwind configuration file with content paths configured for Blazor components
- **postcss.config.js** - PostCSS configuration with Tailwind CSS plugin
- **build-css.mjs** - Custom build script that processes CSS with PostCSS and Tailwind

### CSS Files
- **wwwroot/css/app.css** - Source CSS file (add custom styles here and add Tailwind directives)
- **wwwroot/css/app.generated.css** - Generated CSS file (auto-generated, don't edit directly)

### Updated Files
- **index.html** - Updated to reference the generated CSS file
- **package.json** - Added build and watch scripts
- **.gitignore** - Added entries for generated CSS and node_modules

## Development Workflow

### Build CSS for Production
```bash
npm run build:css
```

### Watch for Changes During Development
```bash
npm run watch:css
```
This will automatically rebuild the CSS whenever you change your Blazor components or the source CSS file.

## Using Tailwind Classes

You can now use Tailwind CSS utility classes in your Razor components:

```razor
<div class="flex items-center justify-center min-h-screen bg-gray-100">
    <h1 class="text-4xl font-bold text-gray-900">Welcome!</h1>
</div>
```

## Adding Custom Styles

Edit `wwwroot/css/app.css` to add custom styles alongside Tailwind directives:

```css
@tailwind base;
@tailwind components;
@tailwind utilities;

/* Your custom styles here */
.custom-button {
    @apply px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600;
}
```

## Notes

- The generated CSS file is automatically excluded from git (see .gitignore)
- Run `npm run build:css` before deploying to ensure all styles are compiled
- The build process only includes CSS for Blazor components (`.razor` files) that use Tailwind classes
- Tailwind CSS v4 with the new `@tailwindcss/postcss` plugin is configured
