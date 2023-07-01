using DG.Tweening;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorDeneme : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    
    public GameObject CannonBall, barrel,cannon;
    public float yPos;
    RectTransform rectTransform;
    bool touching = false;
    bool fire = false;
    Vector2 startpos;
    bool firstfire = false;
    public AudioSource cannonBall;
    float s = 0;
    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        startpos = gameObject.GetComponent<RectTransform>().position;


    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        touching = true;
        
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        touching = false;
        s = 0;
        Debug.Log("cek");
        rectTransform.gameObject.transform.position = startpos;
    }
    private void Update()
    {
        if (touching) { 
            yPos = Mathf.Clamp(Input.mousePosition.y, 30, 70);
            rectTransform.gameObject.transform.position = new Vector2(Input.mousePosition.x, yPos);
            //rectTransform.gameObject.transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, -22, 22), yPos);
          
            if (yPos <= 40)
            {
                Fire();
            }

        }
        if (!touching && yPos < 70)
        {
            rectTransform.gameObject.transform.position = new Vector2(rectTransform.gameObject.transform.position.x, 70);
            firstfire = false;
        }
        
        
    }

    public void Fire()
    {
       
        if (!firstfire)
        {
            Instantiate(CannonBall, barrel.transform.position, Quaternion.identity);
            cannon.transform.DORotate(new Vector3(-7, 0, 0), 0.5f).OnComplete(() => cannon.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
            cannonBall.Play();
            firstfire = true;
        }
        s += Time.deltaTime;
        if (s >= 1)
        {
            Instantiate(CannonBall, barrel.transform.position, Quaternion.identity);
            cannon.transform.DORotate(new Vector3(-7, 0, 0), 0.5f).OnComplete(() => cannon.transform.DORotate(new Vector3(0, 0, 0), 0.5f)); 
            cannonBall.Play();
            s = 0;
        }
    }

}
