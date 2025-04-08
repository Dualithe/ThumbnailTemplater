using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using SFB;

public class UploadFont : MonoBehaviour
{
    public GameObject supporterParent;
    private string[] path;
    private TMP_FontAsset currentFontAsset;
    
    private void swapFonts(string newFont)
    {
        string[] fontPaths = Font.GetPathsToOSFonts();
        Font osFont = new Font(fontPaths[1]);
        TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(osFont);

        for (int i = 0; i < supporterParent.transform.childCount; i++)
        {
            supporterParent.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().font = fontAsset;
            supporterParent.transform.GetChild(i).GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().font = fontAsset;
        }
    }

    public void OpenExplorer()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "otf", false);
        GetFont();
    }

    void GetFont()
    {
        if (path != null)
        {
            UpdateFont();
        }
    }

    void UpdateFont()
    {
        StartCoroutine(DownloadFont());
    }

    IEnumerator DownloadFont()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture("file:///" + path[0]);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            swapFonts("file:///" + path[0]);
    }
}