using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuDemo : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    private bool isOpen;

    private void Start()
    {
        if (menuUI != null)
            menuUI.SetActive(false);

        isOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (menuUI == null)
            return;

        isOpen = !isOpen;
        menuUI.SetActive(isOpen);

        if (isOpen)
            PauseGame();
        else
            ResumeGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
