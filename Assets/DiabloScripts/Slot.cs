using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot 
{
    public Item _item;
    public Rect _position;
    public bool _occupied;
    // Start is called before the first frame update
    public Slot(Rect position)
    {
        this._position = position;
    }
    public void Draw(float frameX, float frameY)
    {
        if(_item!=null)
        GUI.DrawTexture(new Rect(frameX + _position.x, frameY + _position.y,_position.width,_position.height), _item._image);
    }

}
