# WallpaperHourly

The goal is to change the wallpaper of your windows desktop according to the current hour.  
You have to pass an input file of this form:

```json
{
  "Folder": "C:\\path\\to\\image\\folder",
  "DefaultSetting": {
    "HourToBeSet": -1,
    "Path": "defaultWallpaper.png"
  },
  "Settings": [
    {
      "HourToBeSet": 7,
      "Path": "7hourWallpaper.png"
    },
    {
      "HourToBeSet": 8,
      "Path": "8hourWallpaper.png"
    }
  ]
}
```
- The `Folder` property indicate the path to the folder containing all the images you want to use.  
- The `Settings` property is a list of `Setting` objects indicating what image to use at what time.  
- The `DefaultSetting` property is a `Setting` object indicating what image to use if there is no setting for the hour the application is being executed.

### Example  
With the input file above:  
- If you execute the application at 7:20, the wallpaper will be changed with the image `7hourWallpaper.png` that is in the folder `C:\path\to\image\folder`.  
- If you execute the application at 8:40, the wallpaper will be changed with the image `8hourWallpaper.png`.  
- If you execute the application at 13:30, the wallpaper will be changed with the image `default.png`.  

## Scheduling the execution of the application
1. Build the application and create yout input file.
2. Create a shortcut to the executable of the application and give the path to your input file in argument.
3. Schedule the task in the windows task scheduler  
**Attention** for the application to work, you have to check the box `run only when user is logged in` when creating your task in the task scheduler, otherwise the wallpaper won't be changed.

