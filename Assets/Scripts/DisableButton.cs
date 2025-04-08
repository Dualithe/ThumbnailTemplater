using UnityEngine;

public class DisableButton : MonoBehaviour
{
    public GameObject button;

    public void DisableThisButton(bool active)
    {
        button.SetActive(active);
    }
}
