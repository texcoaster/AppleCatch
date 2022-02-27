using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 0.7f;
    float delta = 0;
    int ratio = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            else
            {
                item = Instantiate(bombPrefab) as GameObject;
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
        }
    }
}
