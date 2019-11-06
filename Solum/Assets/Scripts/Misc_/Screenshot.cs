using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    private int screenshotCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {

            string screenshotFilename = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Screenshots");

            if (!System.IO.Directory.Exists(screenshotFilename))
            {
                System.IO.Directory.CreateDirectory(screenshotFilename);
                Debug.Log(screenshotFilename + " was not found");
                Debug.Log("Creating folder");
            }

            do
            {
                screenshotCount++;
                screenshotFilename = System.IO.Path.Combine(screenshotFilename, "screenshot(" + screenshotCount + ").png");
            } while (System.IO.File.Exists(screenshotFilename));

            ScreenCapture.CaptureScreenshot(screenshotFilename);
            Debug.Log("Screenshot Captured" + "\n" + "File: " + screenshotFilename);

        }
    }

}
