using TMPro;
using UnityEngine;

public class CreateSupporter : MonoBehaviour
{
    public TMP_Text inputText;
    public Transform supporterParent;
    public GameObject supporterObject;
    
    public void CreateNewSupporter()
    {
        GameObject supporter = Instantiate(supporterObject, supporterParent);
        supporter.transform.GetChild(0).GetComponent<TMP_Text>().text = inputText.text;
        supporter.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = inputText.text;
        inputText.text = "";
    }
}
