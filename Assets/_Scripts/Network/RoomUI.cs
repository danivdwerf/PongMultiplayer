﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class RoomUI : MonoBehaviour 
{
    [SerializeField]private GameObject parent;
    [SerializeField]private Font buttonFont;

    private Button[] buttons;
    private Text[] buttonLabels;
    private ListMatches matches;
    private JoinGame joinLogic;

    private void Start()
    {
        this.matches = this.GetComponent<ListMatches>();
        this.joinLogic = this.GetComponent<JoinGame>();
        matches.OnMatchFound += show;

        buttons = new Button[10];
        buttonLabels = new Text[10];
        createButtons();
    }

    private void createButtons()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            var currentButton = new GameObject("Room button " + i);
            currentButton.transform.parent = parent.transform;
            currentButton.transform.localPosition = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y, 0);
            currentButton.transform.localScale = new Vector3(1, 1, 1);

            var imageComponent = currentButton.AddComponent<Image>();
            imageComponent.rectTransform.sizeDelta = new Vector2(300, 100);

            var buttonComponent = currentButton.AddComponent<Button>();
            buttons[i] = buttonComponent;

            var labelObject = new GameObject("Label");
            var labelComponent = labelObject.AddComponent<Text>();
            labelComponent.font = buttonFont;
            labelComponent.color = Color.black;
            labelComponent.text = "Room " + i;
            labelComponent.rectTransform.sizeDelta = new Vector2(300, 100);
            labelComponent.resizeTextForBestFit = true;
            labelComponent.alignment = TextAnchor.MiddleCenter;

            labelObject.transform.parent = currentButton.transform;
            labelObject.transform.localPosition = Vector3.zero;
            labelObject.transform.localScale = new Vector3(1, 1, 1);
            buttonLabels[i] = labelComponent;

            currentButton.SetActive(false);
        }
    }

    private void show(List<Room> rooms)
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        for(var i = 0; i < rooms.Count; i++)
        {
            var index = i;
            if (buttons[index].gameObject.activeInHierarchy)
                continue;

            var button = buttons[index];
            var label = buttonLabels[index];

            label.text = rooms[index].Name + "("+rooms[index].Size+"/2)";
            button.onClick.AddListener(delegate(){joinLogic.joinGame(rooms[index].ID);});
            button.gameObject.SetActive(true);
            return;
        }
    }
}
