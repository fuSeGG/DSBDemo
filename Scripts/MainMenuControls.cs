using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControls : MonoBehaviour
{       
    [SerializeField]
    private Image playButton;
    [SerializeField]
    private Image exitButton;

    private MenuInput inputs = new MenuInput();
    public delegate void ButtonAction();
    private Button[] buttons;
    private int selectedButton = 2;
    private bool axisAlreadyActive;

    void Start()
    {
        this.buttons = new Button[2];

        this.buttons[0].image = this.playButton;
        this.buttons[0].image.color = Color.yellow;
        this.buttons[0].action = PlayButtonAction;

        this.buttons[1].image = this.exitButton;
        this.buttons[1].image.color = Color.black;
        this.buttons[1].action = ExitGameButtonAction;
    }

    void Update()
    {
        if (this.inputs.ActionInput)
        {
            this.buttons[this.selectedButton].action();
        }

        if (this.inputs.VerticalInput > 0 && (this.selectedButton < this.buttons.Length - 1) && !this.axisAlreadyActive)
        {
            this.buttons[this.selectedButton].image.color = Color.black;
            ++this.selectedButton;
            this.buttons[this.selectedButton].image.color = Color.yellow;
            this.axisAlreadyActive = true;
        }
        else if (this.inputs.VerticalInput < 0 && (this.selectedButton > 0) && !this.axisAlreadyActive)
        {
            this.buttons[this.selectedButton].image.color = Color.black;
            --this.selectedButton;
            this.buttons[this.selectedButton].image.color = Color.yellow;
            this.axisAlreadyActive = true;
        }
        else if (this.inputs.VerticalInput == 0)
        {
            this.axisAlreadyActive = false;
        }
    }

    private void PlayButtonAction()
    {
        SceneManager.LoadScene("Fly");
    }

    private void ExitGameButtonAction()
    {
        Application.Quit();
    }
}


