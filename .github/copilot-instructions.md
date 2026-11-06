# GitHub Copilot Instructions for Grenades Expanded (Continued)

## Mod Overview and Purpose

Grenades Expanded (Continued) is a mod for RimWorld that expands the arsenal of grenades available to players in the game. The mod was updated to use Asset Bundles to reduce the size of the mod and is compatible with versions of RimWorld starting from 1.6. The mod adds new grenades, unique effects, and sounds, as well as a Nuclear Bomb and Grenade Launcher. The mod also includes a new animal, the Killer Rabbit, and a secret incident.

## Key Features and Systems

Grenades Expanded (Continued) adds several new features and systems to RimWorld, including:

- 22 new grenades, each with unique effects and sounds
- A Nuclear Bomb and Grenade Launcher
- A new animal, the Killer Rabbit
- A secret incident that can be triggered randomly
- No camera shake on explosions

The mod also includes support for other mods such as RimBees and Misc. Bees'n'Honey.

## Coding Patterns and Conventions

The code for Grenades Expanded (Continued) follows some common coding patterns and conventions used in RimWorld modding. These include:

- The use of XML files to define game objects and their properties
- The use of Harmony patches to modify existing game code
- The use of C# files to define new game objects and their behaviors

## XML Integration

XML files are an important part of RimWorld modding, and Grenades Expanded (Continued) makes extensive use of them. The mod includes several XML files that define game objects such as damage types, thing definitions, and hediff definitions. These files are used to define the properties of the new grenades and other game objects added by the mod.

## Harmony Patching

Harmony patches are a powerful tool for modifying existing game code, and Grenades Expanded (Continued) uses them extensively. The mod includes several Harmony patches that modify the behavior of existing game objects such as explosions and pawns. These patches are used to implement the new features and systems added by the mod.

## Suggestions for Copilot

To make the most of GitHub Copilot, here are some suggestions for using it with Grenades Expanded (Continued):

- When working with XML files, use Copilot to generate templates for new game objects and their properties. This can help you quickly define the properties of new grenades and other game objects.
- When working with C# files, use Copilot to generate templates for new game objects and their behaviors. This can help you quickly implement new features and systems.
- When working with Harmony patches, use Copilot to generate templates for modifying existing game code. This can help you quickly implement new features and systems that modify the behavior of existing game objects.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

