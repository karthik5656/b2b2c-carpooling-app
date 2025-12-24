# TGZ Package Distribution Guide

## 📦 What is a TGZ File?

A `.tgz` (tar gzip) file is a compressed archive containing your package. It's the standard format NPM uses for package distribution. This allows you to:

-   ✅ Distribute packages without publishing to NPM registry
-   ✅ Share packages internally across teams
-   ✅ Keep packages private
-   ✅ Version control your package builds

---

## 🔧 Creating TGZ Packages

### Quick Command

```bash
npm run pack
```

This command:

1. Builds the library (`npm run build:lib`)
2. Creates a `.tgz` archive
3. Outputs: `carpooling-ux-components-0.0.1.tgz`

**File size:** ~8.7 kB (compressed)

---

## 📋 Package Contents

When you run `npm run pack`, it includes only files specified in `package.json`:

```
carpooling-ux-components-0.0.1.tgz contains:
├── dist/
│   ├── index.es.js           (13.9 kB)
│   ├── index.umd.js          (9.6 kB)
│   └── ux-components.css     (1.9 kB)
├── package.json              (1.7 kB)
└── README.md                 (2.6 kB)
```

---

## 🚀 Using TGZ in Your Application

### Step 1: Generate TGZ in Component Library

```bash
cd /path/to/CarpoolingApp.Ux.Packages
npm run pack
```

Output: `carpooling-ux-components-0.0.1.tgz`

### Step 2: Copy to Your Project

Copy the `.tgz` file to a location in your application:

```
your-app/
├── src/
├── package.json
└── packages/              ← Create this folder
    └── carpooling-ux-components-0.0.1.tgz
```

### Step 3: Install in Your App

Add to `package.json`:

```json
{
	"dependencies": {
		"@carpooling/ux-components": "file:./packages/carpooling-ux-components-0.0.1.tgz"
	}
}
```

Install:

```bash
npm install
```

### Step 4: Use Components

```typescript
import { Button, Header, Page } from "@carpooling/ux-components";

export default function App() {
	return (
		<div>
			<Header title="My App" />
			<Page>
				<Button primary label="Click me" onClick={() => {}} />
			</Page>
		</div>
	);
}
```

---

## 📂 Folder Structure for Distribution

### Recommended Project Layout

```
your-company-projects/
├── components-library/        ← CarpoolingApp.Ux.Packages
│   ├── src/
│   ├── dist/
│   ├── package.json
│   └── carpooling-ux-components-0.0.1.tgz
│
└── my-app/                     ← Your consuming app
    ├── src/
    ├── package.json
    ├── packages/
    │   └── carpooling-ux-components-0.0.1.tgz (symlink/copy)
    └── node_modules/
```

---

## 🔄 Workflow: Update Components

1. **Make changes** in component library:

    ```bash
    cd CarpoolingApp.Ux.Packages
    npm run storybook  # Test changes
    ```

2. **Update version** in `package.json`:

    ```json
    "version": "0.0.2"
    ```

3. **Rebuild and pack**:

    ```bash
    npm run pack
    ```

    Output: `carpooling-ux-components-0.0.2.tgz`

4. **Update consuming app's `package.json`**:

    ```json
    {
    	"dependencies": {
    		"@carpooling/ux-components": "file:./packages/carpooling-ux-components-0.0.2.tgz"
    	}
    }
    ```

5. **Reinstall**:
    ```bash
    npm install
    ```

---

## 💡 Tips & Best Practices

### Version Management

-   Always increment version before creating new `.tgz` files
-   Keep old `.tgz` files for rollback capability
-   Document version changes in CHANGELOG

### Storage

-   Store `.tgz` files in git (with `git-lfs` for large files)
-   Or keep in a shared network/cloud storage
-   Or use CI/CD artifact storage

### Dependencies

React and React-DOM are **external dependencies** (not bundled):

```json
{
	"peerDependencies": {
		"react": "^19.0.0",
		"react-dom": "^19.0.0"
	}
}
```

Ensure your app has these installed.

### Verification

Verify the package contents:

```bash
npm pack --dry-run
```

---

## ❌ Troubleshooting

### Issue: "Cannot find module"

**Solution:** Ensure React/React-DOM are installed in consuming app:

```bash
npm install react react-dom
```

### Issue: Type definitions not found

**Solution:** Check `dist/index.d.ts` is generated:

```bash
npm run build:lib
```

### Issue: Styles not loading

**Solution:** Import the CSS file in your app:

```typescript
import "@carpooling/ux-components/dist/ux-components.css";
```

---

## 📊 Package Info

Inspect package details before distribution:

```bash
npm pack --dry-run
```

Output shows:

-   File list and sizes
-   Package integrity checksum
-   Total files and size

---

## 🎯 Next Steps

1. Run `npm run pack` in component library
2. Copy `.tgz` to your consuming app
3. Add to `package.json` with `file:` path
4. Run `npm install`
5. Import and use components!
