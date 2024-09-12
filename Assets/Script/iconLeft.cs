using UnityEngine;
public class iconLeft : MonoBehaviour
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
        this.oldGrowRange = this.startPosition.x - (this.startPosition.x + this.iconsValues.SlidingDistance);
    }
    private void Update()
    {
        if (!isDragging) return;

        transform.position = GetFixedPos();
        transform.localScale = GetFixedScale();

    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        if (isDragging && this.transform.position.x == this.startPosition.x + this.iconsValues.SlidingDistance)
        {
            this.isDragging = false;
            this.offsetDone = false;
            this.randomScreen.Switchto(0);
            transform.localScale = new Vector3(this.oldScale, this.oldScale, 1);
            transform.position = this.startPosition;
        }

        else
        {
            this.transform.position = this.startPosition;
            this.randomScreen.MoveScreen(new Vector3(0, 0, 5));
            transform.localScale = new Vector3(this.oldScale, this.oldScale, 1); ;
            this.isDragging = false;
            this.offsetDone = false;
        }
    }
    private Vector3 GetFixedPos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        if (!offsetDone)
        {
            this.offset = MousePos.x;
            this.offsetDone = true;
            this.randomScreen.SetScreenBehind(0);
        }

        if (MousePos.x > this.startPosition.x  && !(MousePos.x > this.startPosition.x + this.iconsValues.SlidingDistance))
        {
            this.randomScreen.MoveScreen(new Vector3(0 - (offset - MousePos.x), 0, 5));
            return new Vector3(MousePos.x, transform.position.y, 4);
        }
           
        else if (MousePos.x < this.startPosition.x)
        {
            this.randomScreen.MoveScreen(new Vector3(0, 0, 5));
            return startPosition;
        }


        else
        {
            this.randomScreen.MoveScreen(new Vector3(0 + this.iconsValues.SlidingDistance, 0, 5));
            return new Vector3(this.startPosition.x + this.iconsValues.SlidingDistance, transform.position.y, 4);
        }

    }
    private Vector3 GetFixedScale()
    {
       
        if (MousePos.x > this.startPosition.x  && !(MousePos.x > this.startPosition.x + this.iconsValues.SlidingDistance))
        {
            float newScale = ((this.MousePos.x - this.startPosition.x) * this.newGrowRange / this.oldGrowRange) + this.oldScale;
            return new Vector3(newScale, newScale, 1);
        }

        else if (MousePos.x < this.startPosition.x)
            return new Vector3(this.oldScale, this.oldScale, 1);

        else
            return new Vector3(this.oldScale + this.iconsValues.growingMax, this.oldScale + this.iconsValues.growingMax, 1);
    }
}







