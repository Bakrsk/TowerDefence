using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Item
{
    public Texture2D _image;
    [SerializeField] public int x;
    [SerializeField] public int y;
    [SerializeField] public int width;
    [SerializeField] public int height;

    public abstract void performAction();
}
