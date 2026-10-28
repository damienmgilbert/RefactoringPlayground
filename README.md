# RefactoringPlayground

A .NET 10 (LTS) / C# 14 class library that is **intentionally written the old way**, so Visual Studio 2026 and the .NET SDK analyzers have something to fix. Nothing in it is meant to be good code.

## How to use it

1. Open `RefactoringPlayground.slnx` in Visual Studio 2026 (or open the folder in VS Code with the C# Dev Kit).
2. Open any file in `src/RefactoringPlayground/Examples/`. Each flagged spot has a `// REFACTOR [rule]: ...` comment above it.
3. Put the caret on the code and press `Ctrl+.` (or `Alt+Enter`) to apply the quick action, or use **Fix all in document / project / solution** from the same menu.
4. Run **Code Cleanup** with `Ctrl+K, Ctrl+E`.

Command line (commit or stash first, because this rewrites the files):

```bash
dotnet build
dotnet format style --diagnostics IDE0066 --severity info     # one rule, e.g. switch statement -> expression
dotnet format style --severity info                           # every style rule at suggestion level
dotnet format analyzers --diagnostics CA1510 CA1511 CA1512 CA1513 --severity info   # throw helpers
dotnet format --verify-no-changes --severity info             # shows what is left to fix, changes nothing
```

All rules are set to `suggestion` in `.editorconfig`, so the project builds clean. Change a rule to `warning` or `error` to see it in the build output.

## What is where

The project folders mirror the .NET code analysis categories, and each namespace matches its folder (IDE0130). Everything lives under `src/RefactoringPlayground/`.

### `CodeStyle/` (IDE rules)

| Folder | Files | Rules |
|---|---|---|
| `CodeBlock/` | `BraceExamples` | IDE0011 always use braces, even for one-line `if` / `else` / `foreach` / `for` / `while` / `do` / `using` / `lock` bodies |
| `ExpressionLevel/` | `AssignmentExamples`, `InitializationExamples`, `DelegateExamples`, `ConditionalExamples` | IDE0054, IDE0180, IDE0018, IDE0042, IDE0059, IDE0017, IDE0028, IDE0300 / IDE0301 / IDE0305, IDE1005, IDE0200, IDE0039, IDE0062, IDE0320, IDE0053, IDE0350, IDE0045 / IDE0046 and more |
| | `RangeIndexExamples` | IDE0056 index operator, IDE0057 range operator |
| | `LinqExamples` | IDE0120 simplify LINQ expression, IDE0121 simplify LINQ type check and cast (`OfType<T>()`), IDE0220 explicit cast in `foreach` |
| | `ConditionalSimplificationExamples` | IDE0075 simplify conditional expression, IDE0100, IDE0045, IDE0046 |
| | `NameofExamples` | IDE0082 `typeof` to `nameof`, IDE0280 `nameof` in attributes, CA1507 |
| | `SimplifyNewExamples` | IDE0090 simplify `new` expression |
| `PatternMatching/` | `PatternMatchingExamples` | IDE0066, IDE0019, IDE0020 / IDE0038, IDE0078, IDE0083, IDE0170 |
| | `NullCheckOverTypeCheckExamples` | IDE0150 prefer `null` check over type check, IDE0041 |
| `NullChecking/` | `NullHandlingExamples` | IDE0029 / IDE0030 `??`, IDE0074 `??=`, IDE0270, IDE0031, IDE0016 |
| | `NullPropagationExamples` | IDE0031 null propagation (`?.`, `?[]`) |
| | `NullCheckSimplificationExamples` | IDE0029 / IDE0030 / IDE0270 / IDE0074 null check simplification, IDE0016 throw expression |
| `Members/` | `ClassStructureExamples` | IDE0290, IDE0032, IDE0044, IDE0021 / IDE0022 / IDE0025 / IDE0027 |
| `ModernCSharp/` | `CSharp14Examples` | `field` keyword, `?.=`, IDE0340, IDE0330, extension blocks |
| `UnnecessaryCode/` | `LegacyStyleExamples`, `UnusedCodeExamples` | IDE0161, IDE0065, IDE0005, IDE0003, IDE0004, IDE0034, IDE0036, IDE0037, IDE0040, IDE0047, IDE0049, IDE0051, IDE0052, IDE0058, IDE0059, IDE0060 |
| `Formatting/` | `WrappingExamples` | IDE0055 wrapping (`csharp_preserve_single_line_statements` / `_blocks`), IDE2000, IDE2001, IDE2003 |
| `Naming/` | `NamingExamples` | IDE1006 naming rules (interfaces, private fields, constants, async suffix, parameters) |
| `Miscellaneous/` | `SuppressionExamples` | IDE0079 unnecessary suppression |

### `CodeQuality/` (CA rules)

| Folder | Rules |
|---|---|
| `Design/` | CA1000, CA1002, CA1024, CA1051, CA1052 |
| `Documentation/` | CA1200 |
| `Globalization/` | CA1304, CA1305, CA1307, CA1309, CA1310, CA1311 |
| `Interoperability/` | CA1401, CA1416, SYSLIB1054 |
| `Maintainability/` | CA1507, CA1508, CA1510 / CA1511 / CA1512 / CA1513 (`GuardClauseExamples`) |
| `Naming/` | CA1707, CA1710, CA1716, CA1720 |
| `Performance/` | CA1805, CA1822, CA1825, CA1829, CA1834, CA1847, CA1860, CA1861, CA1862 |
| `Portability/` | CA1418 |
| `Reliability/` | CA2007, CA2008, CA2013, CA2016 |
| `Security/` | CA5350, CA5351, CA5394 |
| `Usage/` | CA2200, CA2201, CA2208, CA2211, CA2214, CA2227, CA2241, CA2249 |

Code quality rules are set to `suggestion` in `.editorconfig`, like the style rules. To see a whole category in the build output, use `dotnet_analyzer_diagnostic.category-Performance.severity = warning`.

## Caveats

- Which quick actions appear depends on your Visual Studio / SDK version. The `field`, `?.=` and `Lock` suggestions in particular need a current VS 2026 build; if one doesn't show up, apply it by hand.
- IDE0005 (unnecessary usings) only reports on build because `GenerateDocumentationFile` is on in the `.csproj`.
- Some fixes interact. For example, applying IDE0290 (primary constructor) on a class that also has IDE0016 / CA1510 guard code changes what the other suggestions look like. Apply them one at a time and rebuild.
- IDE0079 (unnecessary suppression) only reports inside the IDE, not in `dotnet build`.
- IDE2000 / IDE2001 / IDE2003 are experimental formatting rules and may change or disappear in a later SDK.
- Several examples trigger more than one rule (for example a null check that is also CA1510). The `// REFACTOR` comment names the rule the example is about.
