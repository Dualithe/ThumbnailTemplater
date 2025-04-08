using System.Collections;
using UnityEngine; 
using UnityEngine.UI; 
using SFB; 
using UnityEngine.Networking;

public class ImageUploadMenu : MonoBehaviour { 
    string[] path; 
    public RawImage image;

    private void Awake()
    {
        image = GetComponentInChildren<RawImage>();
    }

    public void OpenExplorer()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Overwrite with png", "", "png", false);
        GetImage();
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture("file:///" + path[0]);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            image.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}