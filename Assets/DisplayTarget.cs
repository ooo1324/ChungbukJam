using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTarget : MonoBehaviour
{
    //[SerializeField] private Image sprite;
    [SerializeField] private GameObject effect;
    [SerializeField] private Image img;

    public void SetData(HandiCraft handi, Sprite sprite)
    {
        img.sprite = handi.craftImage;
        Instantiate(effect);
    }
}
