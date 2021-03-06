﻿using UnityEngine;
using System.Collections;
using FlowContainer;

public class RullProcess : Arrange {
	
	
    public override void ActiveCheck()
    {
        if (!IsDone)
        {
            if (_curActive >= 0)
            {   
                int doneCount = 0;
                Attribute [] atts = transform.GetChild(_curActive).GetComponents<Attribute>();
                foreach (Attribute a in atts)
                {
                    if (a.IsDone)
                        ++doneCount;
                }

                if (doneCount == atts.Length)
                {
                    transform.GetChild(_curActive).gameObject.SetActive(false);
                    for (int i = 0; i < atts.Length; ++i)
                    {
                        atts[i].Reset();
                    }
                    if (ReturnActive.Length > 0)
                    {
                        if (ReturnActive == "UootThrow")
                        {
                            _isDone = true;
                            Reset();
                            transform.parent.GetComponent<Attribute>().ReturnActive = ReturnActive;
                        }
                        else
                        {
                            for (int i = 0; i < transform.childCount; ++i)
                            {
                                if (transform.GetChild(i).name == ReturnActive)
                                {
                                    transform.GetChild(i).gameObject.SetActive(true);
                                    _curActive = i;
                                    break;
                                }
                            }
                        }

                        _returnActive = "";

                    }
                    else
                    {
                        ++_curActive;
                        if (transform.childCount == _curActive)
                        {   
                            _isDone = true;
                        }
                        else
                        {
                            transform.GetChild(_curActive).gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
