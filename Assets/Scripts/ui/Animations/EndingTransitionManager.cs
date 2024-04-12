using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransitionManager : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";//假设现在没有播放
    void Start()
    {
        // 在 Start 方法中将游戏对象设置为不活跃
        gameObject.SetActive(false);
    }
    public void OpenTransition()
    {
        ChangeAnimationState("OpenEndingTransition");//透明度0-1

    }
    public void CloseTransition()
    {
        ChangeAnimationState("CloseEndingTransition");//1-0
    }

    void ChangeAnimationState(string animation, float crossfade = 0.1f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }
}
