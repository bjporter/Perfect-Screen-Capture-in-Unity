using UnityEngine;
using System.Collections;
using System.IO;
 
/*Thank you to Elmar Talibzade (http://appgoodies.net/unity/recording-a-video-in-unity/)  for the initial script.
*/
public class ScreenCapture : MonoBehaviour {
 
    public int maxFrames; //amount of frames you want to record before closing the game
 
    int shotCount;
 
    void Awake () {
        //Application.targetFrameRate = 1; //forces frame rate to 1
        if (!System.IO.Directory.Exists("Screenshots")) //check if "Screenshots" folder exists
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "/Screenshots");
        }
    }

    void Start() {
        Time.captureFramerate = 60;
    }

    void Update () {
        if (shotCount <= maxFrames) //we don't want to include the first frame since it's a mess
        {
            //Application.CaptureScreenshot(Application.dataPath + "/Screenshots/" + "shot" + shotCount + ".png");
            Application.CaptureScreenshot(Application.dataPath + "/Screenshots/" + shotCount.ToString("D5") + ".png");
            shotCount += 1;
        }
        else //keep making screenshots until it reaches the max frame amount
        {
            StopRecording(); //quit game
        }
    }
 
    public void StopRecording() //you can call this function for different reasons (e.g camera animation stops)
    {
        Application.Quit();
    }
}