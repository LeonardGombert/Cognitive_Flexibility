using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
        MoveTarget();
    }

    private void MoveTarget()
    {
        if(target != null)
        {
            target.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    private void MouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);//, Mathf.Infinity, );

            if (hit.collider.tag == "Object")
            {
                target = hit.collider.gameObject;
            }

            if (!hit) return;
        }

        if (Input.GetMouseButtonUp(0)) target = null;
    }
}
