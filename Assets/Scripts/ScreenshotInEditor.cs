#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
 
public class ScreenshotGrabber
{
    [MenuItem("Screenshot/Grab")]
    public static void Grab()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png", 1);
    }

    [MenuItem("Screenshot/Grab 5, wait 5 seconds, grab 1 a second")]
    public static async void Grab5()
    {
        await System.Threading.Tasks.Task.Delay(5000);
        
        ScreenCapture.CaptureScreenshot("Screenshot.png", 3);

        for (int i=0; i < 10; i++) {
            await System.Threading.Tasks.Task.Delay(1000);
            ScreenCapture.CaptureScreenshot("Screenshot" + i + ".png", 3);
        }
    }
}
#endif