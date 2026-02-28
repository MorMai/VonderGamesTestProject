using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject promptUI;

    public void ShowPrompt(Transform player)
    {
        promptUI.SetActive(true);
    }

    public void HidePrompt(Transform player)
    {
        promptUI.SetActive(false);
    }
}
