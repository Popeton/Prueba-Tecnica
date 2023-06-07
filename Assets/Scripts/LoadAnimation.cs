using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        // Obt�n el nombre de la animaci�n guardada en PlayerPrefs
        string chosenAnimation = PlayerPrefs.GetString("ChooseDance");

        // Si se encontr� un nombre de animaci�n v�lido, establece el par�metro en el Animator
        if (!string.IsNullOrEmpty(chosenAnimation))
        {
            animator.SetBool(chosenAnimation, true);
        }
    }
}
