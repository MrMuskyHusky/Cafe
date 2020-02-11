using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickItems : MonoBehaviour
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
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!guide)
            {
                if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Food" && Vector3.Distance(Camera.main.transform.position, hit.transform.position) < distance)
                {
                    // if it's a rigidbody, zero its physics velocity
                    if (hit.rigidbody) hit.rigidbody.velocity = Vector3.zero;
                    guide = hit.transform; // now there's an object picked
                                             // remember its distance from the camera
                    dist = Vector3.Distance(guide.position, Camera.main.transform.position);
                }
            }
        }
    }
    private void OnMouseDown()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = guide.transform.parent;
    }
    private void OnMouseUp()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
    public void RaycastHit()
    {

    }
}
