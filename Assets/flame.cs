using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{


    ProjectileThrower projectileThrower;

    // Start is called before the first frame update
    void Start()
    {
     projectileThrower = GetComponent<ProjectileThrower>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
