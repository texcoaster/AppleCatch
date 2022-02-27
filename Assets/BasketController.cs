using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "apple")
        {
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
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
    }
}
