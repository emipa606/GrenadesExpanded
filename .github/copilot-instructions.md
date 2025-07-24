# GitHub Copilot Instructions for RimWorld Mod Project

## Mod Overview and Purpose

This RimWorld mod, developed in C#, enhances gameplay by introducing new mechanics and expanding the functionality of grenades. Specifically, it aims to modify certain damage behaviors related to explosions and introduces unique incidents involving wildlife. Such alterations are designed to enrich the player's experience by diversifying the challenges and tactical options available in the game.

## Key Features and Systems

1. **Bomb Damage Modification**:
   - The `DamageWorker_BombNoCamShake` class derives from `DamageWorker_AddInjury` and aims to modify the damage behavior of bombs, specifically reducing or eliminating camera shakes during explosions to improve performance and user experience.

2. **Wildlife Incidents**:
   - The `IncidentWorker_BunnyPack` class introduces a new incident where packs of bunnies may invade or interact with the player's colony, adding a quirky challenge.
   - The `DeathActionWorker_KillerRabbit` class builds on this by handling specific death-related actions tied to these wildlife incidents.

3. **Mod Settings Configuration**:
   - The mod includes setting configurations via `GrenadesExpendedMod` and `GrenadesExpendedSettings` classes, allowing players to customize aspects of the grenade features introduced in the mod.

4. **Custom Incident Definitions**:
   - `CrazyRabbitIncidentDefOf` and associated attribute classes are used to define and categorize custom incidents within the game, making integration seamless with existing RimWorld mechanics.

## Coding Patterns and Conventions

- **Class Naming**: Classes are named in a clear and descriptive manner to reflect their purpose (e.g., `DamageWorker_BombNoCamShake`, `IncidentWorker_BunnyPack`).
- **Method Accessibility**: Methods within these classes are defined with appropriate access modifiers (`public`, `internal`) to encapsulate functionality and maintain clean interfaces.
- **Inheritance**: Key classes like `DamageWorker_BombNoCamShake` utilize inheritance to extend or modify base game functionality.

## XML Integration

- The mod likely includes XML files for defining custom incidents, damage types, and other game configurations. Copilot should assist in generating properly structured XML entries to integrate seamlessly with the game's existing data systems.

## Harmony Patching

- Harmony is not explicitly mentioned in the provided summary, but when modding RimWorld, it is common practice to use Harmony for patching game methods. 
- Copilot should assist in creating Harmony patches by guiding where to apply `Prefix`, `Postfix`, and `Transpiler` patches, ensuring compatibility and reducing conflicts with other mods.

## Suggestions for Copilot

### C# Code Suggestions

- **Generating Classes**: Suggest class structures for new features, following the existing naming conventions and patterns.
- **Method Implementation**: Provide code examples for common methods like `GetSettings` and configuration handling, aligning with RimWorld's modding framework.
- **Harmony Integration**: Offer templates for creating Harmony patches with suitable annotations and logic to ensure compatibility.

### XML Code Suggestions

- **Incident Definitions**: Generate XML templates for new incident definitions, ensuring they adhere to RimWorld's expected schema.
- **Settings Files**: Provide examples of XML settings configuration that can be dynamically loaded by the mod's C# classes.

By following these instructions, contributors and developers can effectively extend and maintain the mod, ensuring high-quality additions to the game.
