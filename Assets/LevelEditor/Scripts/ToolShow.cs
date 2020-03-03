using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolShow : MonoBehaviour
{
    public int Index;
    private LevelEditor ts;
    private Image image;
    private static ToolShow IsSelected;
    [SerializeField]
    private GameObject Effect;

    private void Start()
    {
        image = GetComponent<Image>();
        ts = FindObjectOfType<LevelEditor>();
    }

    public void Select()
    {
        IsSelected = this;
        ts.ChangeSelected(Index);
    }

    private void Update()
    {
        Effect.SetActive(IsSelected == this);
    }
}
