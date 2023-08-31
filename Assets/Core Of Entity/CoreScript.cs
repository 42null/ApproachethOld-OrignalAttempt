using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CoreScript : MonoBehaviour, IPointerClickHandler
{
    
    
    // Reference to components
    public String name;
    public BasicTemperatureScript temperatureScript;
    public BasicMassScript massScript;
    public BasicChatterScript chatterScript;
    public GameObject reportScript;
    public GameObject leftClickPopupMenu; //TODO: Rename
    private PopupProperties popupProperties;

    
    
    private GameObject spawnedPopup;

    public float verticalOffset = 20.0f;
    
    public float directableSpeed = 5f;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) { //Left click
            float triggeringElementHeight = transform.parent.GetComponent<Renderer>().bounds.size.y;
            Vector3 offset = new Vector3(0, ConstantsScript.scaledWorldEditorHeightToScreenHeight(triggeringElementHeight)/2+verticalOffset, 0);
            if (spawnedPopup == null)
            {
                spawnCorePopup(offset, 110f); //Open if not already open
            }
            else
            {
                closeCorePopup(spawnedPopup); //Close if already open
            }
        }else if (eventData.button == PointerEventData.InputButton.Right) { //Right click
            
        }else if (eventData.button == PointerEventData.InputButton.Middle) { //Middle click

        }
    }

    private void spawnCorePopup(Vector3 offset, float popupHeight)
    {
        Vector3 spritePosition = transform.position;
        // Convert the world position to screen space
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spritePosition);
        screenPosition += offset;
        screenPosition.y += popupHeight;
        
        // Instantiate the UI prefab on the Canvas at the screen position
        spawnedPopup = Instantiate(leftClickPopupMenu, screenPosition, Quaternion.identity);
        spawnedPopup.transform.SetParent(FindObjectOfType<Canvas>().transform, true);

        popupProperties = spawnedPopup.GetComponent<PopupProperties>();
        popupProperties.elementName = name;
        
        popupProperties.temperatureScript = temperatureScript;
        


    }

    public static void closeCorePopup(GameObject popupGameElement)
    {
        if (popupGameElement != null)
        {
            Destroy(popupGameElement);
        }
        else
        {
            Debug.Log("Could not destroy gameObject, value is null");
        }
    }

    // public GameObject getCorePopup()
    // {
    //     return spawnedPopup;
    // }

    void Start()
    {
    }
    void Update()
    {
    }
}