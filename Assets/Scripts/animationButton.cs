using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject chooseError;
    private string currentAnimation;



    public void DanceButton(string dance)
    {
        
        if (!string.IsNullOrEmpty(currentAnimation))
            animator.SetBool(currentAnimation, false);
        

       
        animator.SetBool(dance, true);
        currentAnimation = dance;

    }

    public void ChooseDance()
    {
        if (!string.IsNullOrEmpty(currentAnimation))
        {
            PlayerPrefs.SetString("ChooseDance", currentAnimation);
            SceneManager.LoadScene(1);
        }
        else
            chooseError.SetActive(true);
    }
}
