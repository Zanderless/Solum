using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Drawer : Interactable
{

    private Vector3 closePos;
    private float maxMoveDist = 0.65f;
    private float moveSpeed = 1.25f;

    private string ITweenName => "Drawer" + gameObject.name;

    public enum PositionType { OPEN, CLOSE };
    public PositionType positionType;

    private void Start()
    {
        
        closePos = transform.position;

    }

    public override void DoInteract()
    {

        Vector3 moveDir = closePos;

        switch (positionType)
        {
            case PositionType.CLOSE:
                moveDir += (transform.up * maxMoveDist);
                positionType = PositionType.OPEN;
                iTween.StopByName(ITweenName);
                break;
            case PositionType.OPEN:
                positionType = PositionType.CLOSE;
                iTween.StopByName(ITweenName);
                break;
            default:
                break;

        }

        Hashtable moveParm = new Hashtable();
        moveParm.Add("name", ITweenName);
        moveParm.Add("position", moveDir);
        moveParm.Add("speed", moveSpeed);
        moveParm.Add("easeType", iTween.EaseType.linear);
        iTween.MoveTo(this.gameObject, moveParm);

    }

}
