using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 角色数据的根，包含所有角色相关数据
/// </summary>
public class ActorConfig : MonoBehaviour
{
    //UI
    public Dropdown dropdown;


    public ActorAttributes attributes;

    public List<ActorInfo> actorInfos;

    private Animator animator;
    List<string> options;

    public void Awake()
    {
        animator = GetComponent<Animator>();

        var clips = animator.runtimeAnimatorController.animationClips;

        options = new List<string>();
        for (int i = 0; i < clips.Length; i++)
        {
            options.Add(clips[i].name);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
        dropdown.value = 0;
        dropdown.onValueChanged.AddListener(OnChangeAnimClips);

    }

    private void OnChangeAnimClips(int value)
    {
        animator.Play(options[value]);
    }
}
