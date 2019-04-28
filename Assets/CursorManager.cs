using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public enum CursorStates
    {
        normal,
        deactivated,
        interactable
    }

    public CursorStates cursorState;

    public Texture2D Curs_Normal, Curs_Deact, Curs_Inter;

    public static CursorManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetCursor();
    }

    public void ResetCursor()
    {
        SetCurstor(CursorStates.interactable);
        SetCurstor(CursorStates.normal);
    }

    public void SetCurstor(CursorStates mode)
    {
        if (mode == cursorState)
            return;

        switch(mode)
        {
            case CursorStates.normal:
                Cursor.SetCursor(Curs_Normal, new Vector2(25, 25), CursorMode.ForceSoftware);
                break;
            case CursorStates.interactable:
                Cursor.SetCursor(Curs_Inter, new Vector2(25, 25), CursorMode.ForceSoftware);
                break;
            case CursorStates.deactivated:
                Cursor.SetCursor(Curs_Deact, new Vector2(25, 25), CursorMode.ForceSoftware);
                break;

        }

        cursorState = mode;
    }
}
