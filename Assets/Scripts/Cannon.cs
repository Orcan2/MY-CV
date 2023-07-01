using UnityEngine.EventSystems;

using UnityEngine;

public class Cannon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Cursor x;
    GameObject cam;
    Vector3 campos;
    public CursorDeneme f;
    public float speed,keyboardSpeed;
    bool touching;
    private void Start()
    {
        cam = Camera.main.gameObject;
        campos = cam.transform.position;

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        touching = true;

    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        touching = false;



    }

    private void Update()
    {
        float xPos =Mathf.Clamp(x.dir * speed * Time.deltaTime,-1,1 );

        if (Input.GetMouseButton(0))
            if(x.dir<0&& transform.position.x>=-22)
            transform.position += new Vector3(xPos,0,0);
        if (x.dir > 0 && transform.position.x <= 22)
            transform.position += new Vector3(xPos, 0, 0);
        if (campos == cam.transform.position) { 
        if (Input.GetKey(KeyCode.A) && !touching&& transform.position.x >= -22)
        {
            gameObject.transform.position -= new Vector3(keyboardSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && !touching && transform.position.x <= 22)
        {
            gameObject.transform.position += new Vector3(keyboardSpeed * Time.deltaTime, 0, 0);
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                f.Fire();
            }
        }
    }

    
}
