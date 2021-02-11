using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TitleText : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float inBetweenTime;
    private float timer;
    private bool done = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!done)
        {
            timer += Time.deltaTime;
            if (timer >= inBetweenTime)
            {
                anim.SetBool("FadingOut", true);
                done = true;
            }
        }
    }
}
