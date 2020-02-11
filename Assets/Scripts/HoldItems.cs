using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoldItems : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide = null;

    public RaycastHit hit;
    private Vector3 newPos;
    private float dist;
    public float distance = 5;

    private void Start()
    {
        
    }

    private void Update()
    {

    }
    void OnMouseDown()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = guide.transform.parent;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Table" && item != null)
        {
            Debug.Log("Food Place On Table");
            //Vector3 newPosition = col.gameObject.transform.position;
            //newPosition = new Vector3(10, 10, 10);
            // col.gameObject.transform.position = newPosition;

            item.transform.position = col.transform.position + new Vector3(0,0.1f,0);
            item.transform.rotation = col.transform.rotation;
            item.transform.parent = null;
        }
    }
}

