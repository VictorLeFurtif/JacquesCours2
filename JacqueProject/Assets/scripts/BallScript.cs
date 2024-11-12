using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Animation anim;

    public void AnimBall()
    {
        anim.Play("shotAnim");
    }
}