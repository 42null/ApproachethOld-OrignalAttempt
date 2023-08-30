using UnityEngine;

public class ConstantsScript : ScriptableObject //TODO: Split and reorganize this class into multiple classes 
{
    //Lowercase as planned to move to not readonly 
    public static readonly float cameraTop    = 15f;
    public static readonly float cameraBottom = -15f;
    public static readonly float cameraLeft   = -26.666f;
    public static readonly float cameraRight  = -15f;
    
    public static readonly float temperatureFormattingTotalMinSpaces = 4;
    
    [SerializeField] private string targetTag = "YourTargetTag";
    // private YourComponentType foundComponent;
    
    
    
    
    
    
    static public float scaledWorldEditorHeightToScreenHeight(float editorHeight) {
        return editorHeight * (Screen.height / (cameraTop - cameraBottom));
    }
    static public float scaledWorldEditorWidthToScreenWidth(float editorWidth) {
        return editorWidth / (cameraLeft - cameraRight) * Screen.width;
    }


    static public string formatTemperatureText(float numaricalValue)
    {
        string result;
        if (numaricalValue <= 0)
        {
            // result = "0.";
            // result += Math.Round(numaricalValue,2).ToString().Substring(2);
        }
        
        return "";
    } 
    
}
