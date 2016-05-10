using UnityEngine;
using System.Collections;

public class Choose : MonoBehaviour
{
    private Animation anim;
    public AnimationClip animIdle;
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim.CrossFade(animIdle.name);
    }
}