# Quick Start - Component Library Scripts

## 📦 Build Commands

### 1. Build Library for Distribution

```bash
npm run build:lib
```

**Generates:**

-   `dist/index.es.js` - ES Module (for modern bundlers)
-   `dist/index.umd.js` - UMD Bundle (for CommonJS/browsers)
-   `dist/ux-components.css` - Bundled component styles

### 2. Create TGZ Package (for distribution)

```bash
npm run pack
```

**Generates:**

-   `carpooling-ux-components-0.0.1.tgz` - Complete package archive
-   Automatically builds library before packing

### 3. Development with Storybook

```bash
npm run storybook
```

Opens Storybook at `http://localhost:6006` to develop and test components interactively.

### 4. Build Static Storybook

```bash
npm run build-storybook
```

Generates a static site for sharing documentation.

---

## 🔗 How to Use in Your App

### Option A: TGZ File (Recommended for Distribution)

**Step 1: Generate TGZ in library**

```bash
npm run pack
```

Creates `carpooling-ux-components-0.0.1.tgz`

**Step 2: In your consumer app, add to `package.json`:**

```json
{
	"dependencies": {
		"@carpooling/ux-components": "file:../path/to/carpooling-ux-components-0.0.1.tgz"
	}
}
```

**Step 3: Install**

```bash
npm install
```

### Option B: Local File Path (Best for development)

In your consumer app's `package.json`:

```json
{
	"dependencies": {
		"@carpooling/ux-components": "file:../path/to/CarpoolingApp.Ux.Packages"
	}
}
```

Then run: `npm install`

### Option C: NPM Link

```bash
# In component library
npm link

# In consumer app
npm link @carpooling/ux-components
```

### Import Components

```typescript
import { Button, Header, Page } from "@carpooling/ux-components";

// Use in your React app
export default function App() {
	return <Button primary size="large" label="Get Started" onClick={() => alert("Clicked!")} />;
}
```

---

## 📋 File Structure

```
├── dist/                  ← Build output (publish this)
├── src/
│   ├── index.ts          ← Main export file
│   ├── assets/           ← Component assets
│   └── stories/          ← Components & Storybook stories
│       ├── Button.tsx
│       ├── Header.tsx
│       └── Page.tsx
├── .storybook/           ← Storybook config
├── package.json          ← Package configuration
└── vite.config.ts        ← Build configuration
```

---

## ✅ Workflow

1. **Develop**: `npm run storybook`
2. **Check**: View components in Storybook at `http://localhost:6006`
3. **Build**: `npm run build:lib`
4. **Test**: Link to consuming app and test integration
5. **Update version** in `package.json` before publishing

---

## 📝 Adding New Components

1. Create component: `src/stories/YourComponent.tsx`
2. Create stories: `src/stories/YourComponent.stories.ts`
3. Export in `src/index.ts`:
    ```typescript
    export { YourComponent } from "./stories/YourComponent";
    export type { YourComponentProps } from "./stories/YourComponent";
    ```
4. Run `npm run storybook` to test
5. Rebuild: `npm run build:lib`
