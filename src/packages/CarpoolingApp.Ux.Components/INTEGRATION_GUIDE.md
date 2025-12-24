# Component Package Integration Guide

## 📦 Building the Package

### Commands

1. **Build the library:**
   ```bash
   npm run build:lib
   ```
   This creates:
   - `dist/index.es.js` - ES module format
   - `dist/index.umd.js` - UMD format (for browsers/CommonJS)
   - `dist/index.d.ts` - TypeScript type definitions

2. **Develop with Storybook:**
   ```bash
   npm run storybook
   ```
   Opens Storybook at `http://localhost:6006`

3. **Build Storybook:**
   ```bash
   npm run build-storybook
   ```
   Generates static Storybook site

4. **Run tests:**
   ```bash
   npm test
   ```

## 🔗 Integration with Other Applications

### Option 1: Local NPM Package (Recommended for Internal Use)

#### Step 1: Build the package in this repo
```bash
npm run build:lib
```

#### Step 2: In your consuming application

**A. Via package.json (Recommended for development):**
```json
{
  "dependencies": {
    "@carpooling/ux-components": "file:../path/to/CarpoolingApp.Ux.Packages"
  }
}
```

Then run:
```bash
npm install
```

**B. Via npm link:**
```bash
# In the component library directory
npm link

# In your consuming application
npm link @carpooling/ux-components
```

#### Step 3: Import components
```typescript
import { Button, Header, Page } from '@carpooling/ux-components';

// Use the components
<Button primary size="large" label="Click me" onClick={() => {}} />
```

### Option 2: NPM Registry (For Public Use)

1. Update `package.json` version
2. Create `.npmrc` if using private registry
3. Publish:
   ```bash
   npm publish
   ```

## 📋 Package.json Configuration Explained

- `main`: Points to UMD build (CommonJS/browser compatibility)
- `module`: Points to ES module build (modern bundlers)
- `types`: Points to TypeScript declarations
- `exports`: Defines package entry points
- `files`: Only `dist` folder is published

## 🎯 Adding New Components

1. Create component in `src/stories/YourComponent.tsx`
2. Export it in `src/index.ts`
3. Create stories in `src/stories/YourComponent.stories.ts`
4. Run `npm run storybook` to test
5. Build with `npm run build:lib`

## ✅ Checklist Before Publishing

- [ ] All components exported in `src/index.ts`
- [ ] TypeScript types properly exported
- [ ] `npm run build:lib` runs without errors
- [ ] Storybook shows all components: `npm run storybook`
- [ ] Test build in consuming app with `file:../path` first
- [ ] Update version in package.json
- [ ] Remove unwanted files (see cleanup section)
