using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public List<Armor> _armorInspector;
    public static List<Armor> _armor;

    private void Start()
    {
        _armor = _armorInspector;
    }
    public static Armor getArmor(int id)
    {
        Armor armor = new Armor();
        armor._image = Items._armor[id]._image;
        armor.width = Items._armor[id].width;
        armor.height = Items._armor[id].height;
        return armor;
    }
}
