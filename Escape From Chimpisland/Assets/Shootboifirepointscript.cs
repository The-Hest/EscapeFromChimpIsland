using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootboifirepointscript : MonoBehaviour
{
    private Transform _target;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector3 targ = _target.transform.position;


        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
