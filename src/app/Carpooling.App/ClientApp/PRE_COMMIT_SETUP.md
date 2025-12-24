# Pre-Commit Hooks Setup

## Overview
This project uses Husky and lint-staged to enforce code quality checks before commits. The pre-commit hook will prevent commits if there are any linting errors or build failures.

## What Gets Checked

### 1. **Lint Check** (`npm run lint`)
- Runs ESLint on all TypeScript/TSX files
- Checks for code style violations
- Reports any issues before the commit is allowed

### 2. **Staged File Formatting** (`npx lint-staged`)
- Automatically fixes ESLint issues in staged files
- Formats code with Prettier (ts, tsx, json, md files)
- Only processes files that are being committed

### 3. **Build Check** (`npm run build`)
- Compiles TypeScript (`tsc -b`)
- Builds the Vite application
- Ensures the project builds successfully

## How It Works

When you run `git commit`:

1. **lint-staged** automatically fixes linting and formatting issues in staged files
2. **eslint** performs a full lint check across the project
3. **tsc** performs TypeScript type checking
4. **vite build** builds the project
5. If any check fails, the commit is blocked
6. You'll need to fix the issues and stage the changes again before committing

## Configuration Files

### `.husky/pre-commit`
The main hook file that executes before each commit.

### `package.json` - `lint-staged` config
```json
"lint-staged": {
  "*.{ts,tsx}": "eslint --fix",
  "*.{ts,tsx,json,md}": "prettier --write"
}
```

## Troubleshooting

### Commit is blocked due to linting errors
Fix the errors shown in the output:
```bash
npm run lint -- --fix
```

### Commit is blocked due to build errors
Check the build output for TypeScript errors and fix them:
```bash
npm run build
```

### Pre-commit hook not running
Make sure the hook file is executable:
```bash
# On Windows, this should already be handled by Git
# On Unix/Linux/Mac, run:
chmod +x .husky/pre-commit
```

### Bypass pre-commit checks (use with caution!)
```bash
git commit --no-verify
```

## Skip Pre-Commit Checks

If you need to bypass the checks temporarily:
```bash
git commit --no-verify
```

**Note**: This should only be used in exceptional cases as it defeats the purpose of having quality checks.

## Benefits

✅ Catches errors before they reach the repository  
✅ Maintains consistent code style across the project  
✅ Ensures the build always works on the main branch  
✅ Prevents broken code from being committed  
✅ Reduces CI/CD failures  

## Development Workflow

1. Make your changes
2. Stage files: `git add .`
3. Commit: `git commit -m "Your message"`
4. Pre-commit hooks run automatically
5. If checks fail, fix the issues
6. Stage the fixes: `git add .`
7. Commit again: `git commit -m "Fixed linting/build errors"`

## Manual Checks

You can also manually run the checks anytime:

```bash
# Run linting
npm run lint

# Run build
npm run build

# Run both
npm run lint && npm run build
```

## Dependencies

- **husky** - Git hooks manager
- **lint-staged** - Run linters on staged files
- **eslint** - JavaScript/TypeScript linter
- **prettier** - Code formatter
- **typescript** - TypeScript compiler
- **vite** - Build tool
