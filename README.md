A simple plugin that adds an FPS counter to the top left of your screen while in a level / level editor in Rhythm Doctor.

## Installation
1. Download the latest version of **BepInEx 5 x86** [here](https://github.com/BepInEx/BepInEx/releases/latest). \
**Make sure you use the x86 version of BepInEx 5!** RD is x86 so the x64 version of BepInEx will not work, and BepInEx 6 is currently not yet compatible with BepInEx 5 mods.
2. Unzip the file into your RD folder. You should have a `winhttp.dll`, `doorstop_config.ini`, and `BepInEx` folder next to Rhythm Doctor.exe.
3. Launch RD once to generate BepInEx files.
4. Download the latest version of the mod from [here](https://github.com/HellUser0/FPSCounterRD/releases). It should be named `FPSCounterRD_1.x.x.zip`.
5. Unzip the file you downloaded into your Rhythm Doctor installation folder. You should now have a file at `BepInEx/plugins/FPSCounterRD/FPSCounterRD.dll`.
6. Launch the game, and the plugin should automatically enable.
7. Configure the plugin as needed in `BepInEx/config/com.rhythmdr.fpscounterrd.cfg`.
8. **Optional:** Install the [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) to configure the mod with a GUI by pressing `F1`.
9. **Optional:** To enable in-game reloading, install the [BepInEx ScriptEngine](https://github.com/BepInEx/BepInEx.Debug/releases/latest), create a `scripts` folder in the `BepInEx` folder then move the `FPSCounterRD.dll` file to that folder. You should now be able to reload the plugin by pressing `F6` in-game.

For more information, check out the [BepInEx installation guide](https://docs.bepinex.dev/articles/user_guide/installation/index.html).