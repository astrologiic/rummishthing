﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemGainedText : MonoBehaviour
{

    public Animator animator;
    private Text itemText;

    // Use this for initialization
    void OnEnable()
    {

        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);

        itemText = animator.GetComponent<Text>();

    }

    public void SetText(string text)
    {
        animator.GetComponent<Text>().text = text;
    }
}
