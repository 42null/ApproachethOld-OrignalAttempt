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
    public delegate void MenuValueChangedDelegate(string newValue);
    public event MenuValueChangedDelegate OnMenuValueChanged;
    
    public float popupWindowHeight = 100;
    public float popupWindowWidth  = 70;
    public GameObject corePopup;
    public string elementName = "Element default name";
    
    public GameObject temperatureReport;
    public BasicTemperatureScript temperatureScript;
    // public TextMeshProUGUI nameInputField;
    // public TextMeshProUGUI nameInputField;
    public TMP_InputField nameInputField; // Change the field type to TMP_InputField
    
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

        nameInputField = ComponentFinder.FindComponentsInChildrenWithTag<TMPro.TMP_InputField>(corePopup, "Popup Name Field")[0];
        nameInputField.text = elementName;
        nameInputField.onValueChanged.AddListener(onNameFieldChanged);


        temperatureTextBox = ComponentFinder.FindComponentsInChildrenWithTag<Text>(corePopup, "TemperatureTextField")[0];
        updateTimer = updateInterval; //So the time update run happens immediately
    }
    void Update()
    {

        if (updateInterval != -1)
        {
            if (updateTimer >= updateInterval) //TODO: DO SUBSCRIBER DESIGN PATTERN FOR EFFICIENCY!!!
            {
                updateTimer = 0;
                float newValue = temperatureScript.getCurrentTemperature();
                if (lastValue != newValue)
                {
                    lastValue = newValue;
                    temperatureTextBox.text =  temperatureScript.getCurrentTemperature().ToString();
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

    private void onNameFieldChanged(string newStringValue)
    {
        Debug.Log("\""+newStringValue+"\"");
        elementName = newStringValue;
        OnMenuValueChanged?.Invoke(elementName);
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
