using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        // Obtén el nombre de la animación guardada en PlayerPrefs
        string chosenAnimation = PlayerPrefs.GetString("ChooseDance");

        // Si se encontró un nombre de animación válido, establece el parámetro en el Animator
        if (!string.IsNullOrEmpty(chosenAnimation))
        {
            animator.SetBool(chosenAnimation, true);
        }
    }
}
