using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public JetskiMovement jk;
    Vector3 dir;
    public float speed;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);

            }
        }
    }
}
