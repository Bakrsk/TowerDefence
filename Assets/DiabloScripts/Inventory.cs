using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Rect _position;
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] int slotWidthSize = 10;
    [SerializeField] int slotHeightSize = 4;

    public Slot[,] slots;
    public int slotX;
    public int slotY;
    public int width = 29;
    public int height = 30;

    private Item _temp;
    private Vector2 _selected;
    private Vector2 _secondSelected;
    private bool _test;

    // Start is called before the first frame update
    void Start()
    {
        SetSlots();
        _test = false;
    }
    void testMethod()
    {
        _test = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_test)
        {
            testMethod();
        }
    }
    void drawTempItem()
    {
        if(_temp!= null)
        {
           GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, _temp.width * width, _temp.height * height), _temp._image);
        }

    }
    private void OnGUI()
    {
        drawInventory();
        drawSlots();
        drawItems();
        DetectGuiAxction();
        drawTempItem();
    }
    void drawInventory()
    {
        _position.x = Screen.width - _position.width;
        GUI.DrawTexture(_position, _texture);
    }
    void drawSlots()
    {
        for (int x = 0; x < slotWidthSize; x++)
        {
            for (int y = 0; y < slotHeightSize; y++)
            {
                slots[x, y].Draw(_position.x, _position.y);
            }
        }
    }
    void SetSlots()
    {
        slots = new Slot[slotWidthSize, slotHeightSize];
        for (int x = 0; x < slotWidthSize; x++)
        {
            for (int y = 0; y < slotHeightSize; y++)
            {
                slots[x, y] = new Slot(new Rect(slotX + width * x, slotY + height * y, width, height));
            }
        }
    }
    public bool AddItem(Item item)
    {
        for (int x = 0; x < slotWidthSize; x++)
        {
            for (int y = 0; y < slotHeightSize; y++)
            {
                if (addItem(x, y, item))
                {
                    return true;
                }
            }
        }
        return false;
    }
    bool addItem(int x, int y, Item item)
    {
        for (int sX = 0; sX < item.width; sX++)
        {
            for (int sY = 0; sY < item.height; sY++)
            {
                if (slots[x, y]._occupied)
                {
                    return false;
                }
            }
        }
        if (x + item.width > slotWidthSize)
        {
            return false;
        }
        else if (y + item.height > slotHeightSize)
        {
            return false;
        }
        item.x = x;
        item.y = y;
        items.Add(item);
        for (int sX = x; sX < item.width + x; sX++)
        {
            for (int sY = y; sY < item.height + y; sY++)
            {
                slots[sX, sY]._occupied = true;
            }
        }
        return true;
    }
    void drawItems()
    {
        for (int count = 0; count < items.Count; count++)
        {
            GUI.DrawTexture(new Rect(slotX + _position.x + items[count].x * width, slotY + _position.y + items[count].y * height, items[count].width * width, items[count].height * height), items[count]._image);
        }
    }
    void detectMouseAction()
    {
        for (int x = 0; x < slotWidthSize; x++)
        {
            for (int y = 0; y < slotHeightSize; y++)
            {
                Rect slot = new Rect(_position.x + slots[x, y]._position.x, _position.y + slots[x, y]._position.y, width, height);
                if (slot.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                {
                    if (Event.current.isMouse && Input.GetMouseButtonDown(0))
                    {
                        _selected.x = x;
                        _selected.y = y;
                        for (int index = 0; index < items.Count; index++)
                        {
                            for (int countX = items[index].x; countX < items[index].x + items[index].width; countX++)
                            {
                                for (int CountY = items[index].y; CountY < items[index].y + items[index].height; CountY++)
                                {
                                    if(countX == x && CountY == y)
                                    {
                                        _temp = items[index];
                                        RemoveItem(_temp);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else if (Event.current.isMouse && Input.GetMouseButtonUp(0))
                    {
                        _secondSelected.x = x;
                        _secondSelected.y = y;

                        if (_secondSelected.x != _selected.x || _secondSelected.y != _selected.y)
                        {
                            if (_temp != null)
                            {
                                if (addItem((int)_secondSelected.x, (int)_secondSelected.y, _temp))
                                {

                                }
                                else
                                {
                                    addItem(_temp.x, _temp.y, _temp);
                                }
                                _temp = null;
                            }
                        }
                        else
                        {
                            addItem(_temp.x, _temp.y, _temp);
                            _temp = null;
                        }
                    }
                    return;
                }
            }
        }
    }
    void DetectGuiAxction()
    {
        if (Input.mousePosition.x > _position.x && Input.mousePosition.x < _position.x + _position.width)
        {
            if (Screen.height - Input.mousePosition.y > _position.y && Screen.height - Input.mousePosition.y < _position.y + _position.height)
            {
                detectMouseAction();
                return;
            }
        }
    }
    void RemoveItem(Item item)
    {
        for (int x = item.x; x < item.x + item.width; x++)
        {
            for (int y = item.y; y < item.y + item.height; y++)
            {
                slots[x, y]._occupied = false;
            }
        }
        items.Remove(item);
    }

}
