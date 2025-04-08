using System.Collections;
using System.IO;
using UnityEngine;

public class CreateScreenshot : MonoBehaviour
{
    public GameObject[] uiElements;
    private int numOfThumbnail = 1;
    public GameObject supportersObject;
    
    IEnumerator TakeScreenshotCoroutine()
    {
        foreach (var element in uiElements)
        {
            element.SetActive(false);
            
            foreach (var supporter in supportersObject.GetComponentsInChildren<DisableButton>())
            {
                supporter.DisableThisButton(false);
            }
        }
        
        if (File.Exists("Thumbnail.png"))
        {
            while (File.Exists("Thumbnail(" + numOfThumbnail + ").png"))
            {
                numOfThumbnail++;
            }
            ScreenCapture.CaptureScreenshot("Thumbnail(" + numOfThumbnail + ").png");
        }
        else
        {
            ScreenCapture.CaptureScreenshot("Thumbnail.png");
        }
        
        yield return new WaitForSeconds(1f); 

        
        foreach (var element in uiElements)
        {
            element.SetActive(true);
            foreach (var supporter in supportersObject.GetComponentsInChildren<DisableButton>())
            {
                supporter.DisableThisButton(true);
            }
        }
    }
    
    public void TakeScreenshot()
    {
        StartCoroutine(TakeScreenshotCoroutine());
    }
}