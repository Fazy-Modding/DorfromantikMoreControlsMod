# DorfromantikMoreControlsMod
My first BepInEx mod for expanding zoom limits and allowing faster keyboard panning.

## Setup
1. Get BepInEx from their official github repository [here](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.9) (for example, on Windows 64bit, you can download BepInEx_x64_5.4.9.0.zip)
2. Unzip all the files in the BepInEx archive you downloaded into your Dorfromantik game folder. You can find this folder in Steam Library by right clicking Dorfromantik and choosing Managa > Browse local files, the path looks like "<where your Steam library is>\steamapps\common\Dorfromantik". After unzipping, your Dorfromantik folder should contain folder BepInEx as well as doorstop_config.ini, winhttp.dll and other files (that were originally there).
3. Run the game once and close it after loading. Everything should work, mod is not applied yet. 
4. Download MoreControlOptionsMod.dll from this repository, this is the mod file itself. Place it in Dorfromantik\BepInEx\plugins folder.
5. Run the game, the mod should now be active. 

## Config
After the first time you run the game with the mod present, config file called MoreControlOptions.cfg will be created in Dorfromantik\BepInEx\config. You can change config options there and turn features on/off. You have to restart the game for changes to take effect.
