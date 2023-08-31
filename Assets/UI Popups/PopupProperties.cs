using System.Collections;
using System.Collections.Generic;
using StaticHelpers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupProperties : MonoBehaviour
{
    RectTransform rectTransform;
        
    public float popupWindowHeight = 100;
    public float popupWindowWidth  = 70;
    public GameObject corePopup;
    public string elementName = "Element default name";
    
    public GameObject temperatureReport;
    public BasicTemperatureScript temperatureScript;
    public TextMeshProUGUI nameInputField;

    public Text temperatureTextBox;
    
    public float updateInterval = -1f;
    private float updateTimer = 0f;
    private float lastValue = 0f;
    
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        setNewHeight(popupWindowHeight, false);
        setNewWidth(popupWindowWidth);
        
        corePopup = gameObject;

        nameInputField.text = elementName;
        temperatureTextBox = ComponentFinder.FindComponentsInChildrenWithTag<Text>(corePopup, "TemperatureTextField")[0];
        updateTimer = updateInterval; //So the time update run happens immediately
    }
    void Update()
    {
        nameInputField.text = elementName;

        if (updateInterval != -1)
        {
            if (updateTimer >= updateInterval) //TODO: DO SUBSCRIBER DESIGN PATTERN FOR EFFICIENCY!!!
            {
                updateTimer = 0;
                float newValue = temperatureScript.getCurrentTemperature();
                if (lastValue != newValue)
                {
                    lastValue = newValue;
                    temperatureTextBox.text = lastValue.ToString();
                    // String randForName = Random.Range(0, 100).ToString();
                    // temperatureTextBox.text = "A"+temperatureTextBox.GetHashCode().ToString();
                }
            }
            else
            {
                updateTimer += Time.deltaTime;
            }
        }
    }

    public void ButtonClickClose()
    {
        CoreScript.closeCorePopup(corePopup);
    }

    //General
    public void setNewHeight(float newHeight, bool keepBottomCord)
    {
        float deltaHeight = popupWindowHeight - newHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, newHeight);

        if (keepBottomCord)
        {
            Vector3 existingDimensions = rectTransform.position;
            Vector3 newPosition = new Vector3(existingDimensions.x, existingDimensions.y+ (deltaHeight / 2), existingDimensions.z);
            rectTransform.position = newPosition;            
        }
        popupWindowHeight = newHeight;
    }
    public void setNewWidth(float newWidth)
    {
        rectTransform.sizeDelta = new Vector2( newWidth, rectTransform.sizeDelta.y);
        popupWindowHeight = newWidth;
    }
    
}
