using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject great;
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject bad;

    private Action onFinish;

    private static WordsManager instance;

    private void Awake()
    {
        instance = this;
        perfect.SetActive(false);
        great.SetActive(false);
        good.SetActive(false);
        bad.SetActive(false);
    }

    public static void EnableGood(Action listener)
    {
        instance.onFinish += listener;
        instance.good.SetActive(true);
        instance.animator.SetTrigger("animate");
    }

    public void OnFinishGoodOutro()
    {
        onFinish?.Invoke();
    }
}
