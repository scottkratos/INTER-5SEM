using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolShow : MonoBehaviour
{
    private Image image;
    private static ToolShow IsSelected;
    [SerializeField]
    private GameObject Effect;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Select()
    {
        IsSelected = this;
    }

    private void Update()
    {
        Effect.SetActive(IsSelected == this);
    }
}
