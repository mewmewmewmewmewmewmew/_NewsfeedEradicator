using UnityEngine;
public class iconRight : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    public Icons iconsValues;
    private float oldScale;
    private Vector3 MousePos;

    private float newGrowRange;
    private float oldGrowRange;

    public randomScreen randomScreen;

    private float offset;
    private bool offsetDone;

    private void Start()
    {
        this.startPosition = transform.position;
        this.oldScale = transform.localScale.x;

        this.newGrowRange = this.iconsValues.growingMin - this.iconsValues.growingMax;
        this.oldGrowRange = this.startPosition.x - (this.startPosition.x - this.iconsValues.SlidingDistance);
    }

    private void Update()
    {
        if (!isDragging) return;

        transform.position = GetFixedPos();
        transform.localScale = GetFixedScale();
    }
    private void OnMouseDown()
    {
        this.isDragging = true;

    }
    private void OnMouseUp()
    {
        if (isDragging && this.transform.position.x == this.startPosition.x - this.iconsValues.SlidingDistance)
        {
            this.isDragging = false;
            this.offsetDone = false;
            this.randomScreen.Switchto(2);
            transform.localScale = new Vector3(this.oldScale, this.oldScale, 0.1f);
            transform.position = this.startPosition;
        }

        else
        {
            this.transform.position = this.startPosition;
            this.randomScreen.MoveScreen(new Vector3(0, 0, 0));
            transform.localScale = new Vector3(this.oldScale, this.oldScale, 0.1f); 
            this.isDragging = false;
            this.offsetDone = false;
        }
    }
    private Vector3 GetFixedPos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //MousePos = Input.mousePosition;
        //Debug.Log(MousePos);

        if (!offsetDone)
        {
            this.offset = MousePos.x;
            this.offsetDone = true;
            this.randomScreen.SetScreenBehind(2);
        }

        if (MousePos.x < this.startPosition.x && !(MousePos.x < this.startPosition.x - this.iconsValues.SlidingDistance))
        {
            this.randomScreen.MoveScreen(new Vector3(0 - (offset - MousePos.x), 0, 0));
            return new Vector3(MousePos.x, transform.position.y, -1);
        }
            

        else if (MousePos.x > this.startPosition.x)
        {
            this.randomScreen.MoveScreen(new Vector3(0, 0, 0));
            return startPosition;
        }

        else
        {
            this.randomScreen.MoveScreen(new Vector3(0 - this.iconsValues.SlidingDistance, 0, 0));
            return new Vector3(this.startPosition.x - this.iconsValues.SlidingDistance, transform.position.y, -1);
        }
    }
    private Vector3 GetFixedScale()
    {

        if (MousePos.x < this.startPosition.x && !(MousePos.x < this.startPosition.x - this.iconsValues.SlidingDistance))
        {
            float newScale = ((this.MousePos.x - this.startPosition.x) * this.newGrowRange / this.oldGrowRange) + this.oldScale;
            return new Vector3(newScale, newScale, 0.1f);
        }

        else if (MousePos.x > this.startPosition.x)
            return new Vector3(this.oldScale, this.oldScale, 0.1f);

        else
            return new Vector3(this.oldScale + this.iconsValues.growingMax, this.oldScale + this.iconsValues.growingMax, 0.1f);



    }
}







