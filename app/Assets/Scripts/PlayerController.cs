using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    GameObject cursor;
    public float delta = 2f;
    void Start()
    {
        cursor = GameObject.Find("Cursor");
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Vector3.Distance(pos, cursor.transform.position) > delta)
        {
            pos = Vector3.Lerp(pos, cursor.transform.position, 0.04f);
        }
        pos.y = transform.position.y;
        transform.position = pos;
    }
}
