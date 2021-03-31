# DorfromantikMoreControlsMod
My first BepInEx mod for expanding zoom limits and allowing faster keyboard panning.

## Setup
1. Get BepInEx from their official github repository [here](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.9) (for example, on Windows 64bit, you can download BepInEx_x64_5.4.9.0.zip)
2. Unzip all the files in the BepInEx archive you downloaded into your Dorfromantik game folder. You can find this folder in Steam Library by right clicking Dorfromantik and choosing Managa > Browse local files, the path looks like "<where your Steam library is>\steamapps\common\Dorfromantik". After unzipping, your Dorfromantik folder should contain folder BepInEx as well as doorstop_config.ini, winhttp.dll and other files (that were originally there).
3. Run the game once and close it after loading. Everything should work, mod is not applied yet. 
4. Download the [latest release of the mod](https://github.com/Fazy-Modding/DorfromantikMoreControlsMod/releases/tag/0.3) (currently MoreControlOptionsMod_v0.3.zip) from this repository, this is the mod file itself. Unzip it in the Dorfromantik\BepInEx\plugins folder.
5. Run the game, the mod should now be active. 

## Config
After the first time you run the game with the mod present, config file called MoreControlOptions.cfg will be created in Dorfromantik\BepInEx\config. You can change config options there and turn features on/off. You have to restart the game for changes to take effect.

## Warning
This mod is an alpha version. It is primitive. It might cause bugs. It *should not* affect gameplay balance, highscores. There is no reason this mod should get you VAC banned. 

Please do not trust this mod blindly. I will add complete sources for compiling but you should do your own checks if you feel the need. 

### Dependencies and compiling
Version 0.3 was built with Microsoft Visual Studio Community 2019 (Version 16.9.2), targetting .NET Standard 2.0.3.
It uses HarmonyX version 2.4.0, BepInEx version 5.4.9.0, Assembly-CSharp.dll of Dorfromantik (Steam build id 6449938) and Unity DLLs (UnityEngine.dll, UnityEngine.CoreModule.dll), both in version used by the game (which is 2020.1.17f1).
