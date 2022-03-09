using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;

    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }

        //if (other.gameObject.tag == "apple")
        //{
        //    Debug.Log("Tag=Apple");
        //}
        //else
        //{
        //    Debug.Log("Tag=Bomb");
        //}

        //Debug.Log("catch");
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            transform.position = new Vector3(-1, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            transform.position = new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            transform.position = new Vector3(1, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            transform.position = new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            transform.position = new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            transform.position = new Vector3(-1, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            transform.position = new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            transform.position = new Vector3(1, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.position.z != 1)
            {
                transform.Translate(0, 0, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.position.z != -1)
            {
                transform.Translate(0, 0, -1);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x != -1)
            {
                transform.Translate(-1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x != 1)
            {
                transform.Translate(1, 0, 0);
            }
        }
    }
}
