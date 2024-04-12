using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMiddleDialogueManager : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation = "";//假设现在没有播放
    
    public void OpenMiddleDialogue()
    {
        ChangeAnimationState("OpenMiddleDialogue");
    }
    public void CloseTransition()
    {
        ChangeAnimationState("CloseMiddleDialogue");
    }

    void ChangeAnimationState(string animation, float crossfade = 0.1f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);//播放动画
        }
    }
}
