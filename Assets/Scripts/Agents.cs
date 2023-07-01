using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Agents : MonoBehaviour
{
    public float transition;
    public Animator anim;
    public AudioSource hitSound;
    public GameObject text,cursor;
    GameObject cam;
    bool isReached = false;
    public Vector3 distance;
    Vector3 target;
    public float s,textL;

    private void Start()
    {
        cam = Camera.main.gameObject;

    }


    void Switch()
    {
        isReached = false;
    }
    void patrol()
    {
        int x = Random.Range(-50, 50);
        int z = Random.Range(6, 50);
        target = new Vector3(x, 0, z);
        if (target.magnitude >= 10 && gameObject.GetComponent<Animator>().enabled)
        {

            float t = (transform.position - target).magnitude / 10;
            transform.LookAt(target);
            anim.SetInteger("move", 1);
            transform.DOMove(target, t);
        }
        isReached = true;
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            
            gameObject.GetComponent<Animator>().enabled = false;
            StartCoroutine(ExampleCoroutine());
            text.SetActive(true);
            cursor.SetActive(false);
            cam.transform.DOMove(text.transform.position + distance, 2).SetEase(Ease.Flash);
            cam.transform.DORotate(new Vector3(0, 0, 0), 2);
            StartCoroutine(textCoroutine());
            hitSound.Play();
        }
    }
    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(s);
        gameObject.GetComponent<Animator>().enabled = true;

    }
    IEnumerator textCoroutine()
    {

        yield return new WaitForSeconds(textL);
        cam.transform.DOMove(new Vector3(0,36,5), 2).SetEase(Ease.Flash);
        cam.transform.DORotate(new Vector3(54, 0, 0), 2);
        text.SetActive(false);
        cursor.SetActive(true);

    }

    void Update()
    {
        if ((transform.position-target).magnitude<=transition)
        {
            anim.SetInteger("move", 2);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            
        //    gameObject.GetComponent<Animator>().enabled = !gameObject.GetComponent<Animator>().enabled; 
            
        //}
        if (!isReached)
        {
            patrol();
        }
        
        



    }
}
