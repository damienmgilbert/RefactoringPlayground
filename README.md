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

| File | Quick actions it exercises |
|---|---|
| `PatternMatchingExamples.cs` | IDE0066 switch statement to expression, if/else chain to switch, IDE0019 / IDE0020 / IDE0038 `as` and `is` + cast, IDE0078 `or` / `and` patterns, IDE0083 `is not`, IDE0041, IDE0150, IDE0170 |
| `NullHandlingExamples.cs` | IDE0029 / IDE0030 `??`, IDE0074 `??=`, IDE0270, IDE0031 `?.`, IDE0016 throw expression |
| `AssignmentExamples.cs` | IDE0054 compound assignment, IDE0180 tuple swap, IDE0018 inline `out`, IDE0042 deconstruction, IDE0059 unnecessary assignment, foreach to LINQ |
| `InitializationExamples.cs` | IDE0017 object initializer, IDE0028 collection initializer, IDE0090 target-typed `new()`, IDE0300 / IDE0301 / IDE0305 collection expressions |
| `DelegateExamples.cs` | IDE1005 `handler?.Invoke`, IDE0200 remove unnecessary lambda, IDE0039, IDE0062, IDE0320, IDE0053, IDE0350 |
| `ConditionalExamples.cs` | IDE0045 / IDE0046, merge nested `if`, merge consecutive `if`, IDE0075, IDE0100, IDE0048, IDE0011, IDE0056 / IDE0057, IDE0120, for to foreach, IDE0063, interpolated strings, IDE0071, IDE0082 |
| `GuardClauseExamples.cs` | CA1510 / CA1511 / CA1512 / CA1513 throw helpers, invert `if` to flatten arrow code |
| `ClassStructureExamples.cs` | IDE0290 primary constructor, IDE0032 auto property, IDE0044 readonly field, IDE0021 / IDE0022 / IDE0025 / IDE0027 expression bodies |
| `CSharp14Examples.cs` | `field` keyword, `?.=`, IDE0340 `nameof(List<>)`, IDE0330 `Lock`, extension block migration |
| `LegacyStyleExamples.cs` | IDE0161 file-scoped namespace, IDE0065, IDE0005, IDE0003, IDE0004, IDE0034, IDE0036, IDE0037, IDE0040, IDE0047, IDE0049 |

## Caveats

- Which quick actions appear depends on your Visual Studio / SDK version. The `field`, `?.=` and `Lock` suggestions in particular need a current VS 2026 build; if one doesn't show up, apply it by hand.
- IDE0005 (unnecessary usings) only reports on build because `GenerateDocumentationFile` is on in the `.csproj`.
- Some fixes interact. For example, applying IDE0290 (primary constructor) on a class that also has IDE0016 / CA1510 guard code changes what the other suggestions look like. Apply them one at a time and rebuild.
