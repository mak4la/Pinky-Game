using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{

    public AudioClip flameLaunchSound; // The sound clip to play when launching the flame
    private AudioSource audioSource; // Reference to the AudioSource component

    ProjectileThrower projectileThrower;

    // Start is called before the first frame update
    void Start()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            //Add an AudioSource component if it's not already present
            audioSource = gameObject.AddComponent<AudioSource>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (audioSource != null && flameLaunchSound != null)
            {
                audioSource.PlayOneShot(flameLaunchSound);

            }
        }
    }
}