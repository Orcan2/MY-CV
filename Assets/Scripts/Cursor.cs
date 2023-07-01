using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class Cursor : MonoBehaviour
{
    public Vector2 startPos;
    RectTransform rectTransform;
    public float slide;
    bool touching = false;
    public float dir;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition3D;
  
    }
    private void Update()
    {
        
        
        
        Vector3 CurPosition = rectTransform.anchoredPosition3D;
   
       
        dir = CurPosition.x - startPos.x;
    }
    


}
