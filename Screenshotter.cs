using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum DesiredSaveLocation
{
    Persistent, StreamingAssets
}

public class Screenshotter : MonoBehaviour
{
    int ID;

    string fullPath;

    public string ImagePrefix = "Image ";

    public string folder = "Screenshotter";

    public int screenshotScale = 1;

    public DesiredSaveLocation imageSaveLocation;

    public KeyCode buttonToPress;

    private void Update()
    {
        if (Input.GetKeyDown(buttonToPress))
        {


            switch (imageSaveLocation)
            {
                case DesiredSaveLocation.Persistent:
                    fullPath = Path.Combine(Application.persistentDataPath, folder);
                    CheckThenCreateDir(fullPath);
                    break;
                case DesiredSaveLocation.StreamingAssets:
                    CheckThenCreateDir(fullPath);
                    fullPath = Path.Combine(Application.streamingAssetsPath, folder);
                    break;
            }

            ID++;
            string imageName = ImagePrefix + ID + ".png";

            ScreenCapture.CaptureScreenshot(Path.Combine(fullPath, imageName), screenshotScale);
            Debug.LogFormat("Screenshot {0} saved to {1}", imageName, fullPath);
        }
    }

    private void CheckThenCreateDir(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

}
