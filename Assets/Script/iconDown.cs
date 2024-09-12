using UnityEngine;
public class iconDown : MonoBehaviour
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
        this.oldGrowRange = this.startPosition.y - (this.startPosition.y + this.iconsValues.SlidingDistance);
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
        if( isDragging && this.transform.position.y == this.startPosition.y + this.iconsValues.SlidingDistance)
        {
            this.isDragging = false;
            this.offsetDone = false;
            this.randomScreen.Switchto(1);
            transform.localScale = new Vector3(this.oldScale, this.oldScale, 1);
            transform.position = this.startPosition;
        } 

        else
        {
            this.transform.position = this.startPosition;
            this.randomScreen.MoveScreen(new Vector3(0, 0, 5));
            transform.localScale =  new Vector3(this.oldScale, this.oldScale, 1); 
            this.isDragging = false;
            this.offsetDone = false;
        }
    }
    private Vector3 GetFixedPos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        if (!offsetDone)
        {
            this.offset = MousePos.y;
            this.offsetDone = true;
            this.randomScreen.SetScreenBehind(1);
        }

        if (MousePos.y > this.startPosition.y && !(MousePos.y > this.startPosition.y + this.iconsValues.SlidingDistance))
        {
            this.randomScreen.MoveScreen(new Vector3(0, MousePos.y - offset, 5));
            return new Vector3(transform.position.x, MousePos.y, 4);
        }
            

        else if (MousePos.y < this.startPosition.y)
        {
            this.randomScreen.MoveScreen(new Vector3(0, 0, 5));
            return startPosition;
        }


        else
        {
            this.randomScreen.MoveScreen(new Vector3(0, 0 + this.iconsValues.SlidingDistance, 5));
            return new Vector3(transform.position.x, startPosition.y + this.iconsValues.SlidingDistance, 4);
        }
            
    }
    private Vector3 GetFixedScale()
    {
        if (MousePos.y > this.startPosition.y && !(MousePos.y > this.startPosition.y + this.iconsValues.SlidingDistance))
        {
            float newScale = ((this.MousePos.y - this.startPosition.y) * this.newGrowRange / this.oldGrowRange) + this.oldScale;
            return new Vector3(newScale, newScale, 1);
        }

        else if (MousePos.y < this.startPosition.y)
            return new Vector3(this.oldScale, this.oldScale, 1);

        else
            return new Vector3(this.oldScale + this.iconsValues.growingMax, this.oldScale + this.iconsValues.growingMax, 1);
    }

}







