using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutDrop : MonoBehaviour
{
    public GameObject treeTop;
    SpriteRenderer thisRenderer;

    public float speed;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        this.transform.position = treeTop.transform.position;
        thisRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        thisRenderer.sortingOrder = 3;

        time += Time.deltaTime;

        this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

        if (time >= 3)
        {
            time = 0;
            this.transform.position = treeTop.transform.position;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
