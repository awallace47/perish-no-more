using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public static class Utils
{

    public static void FadeIn(this VisualElement v)
    {
        v.AddToClassList("fade-in");
        v.RemoveFromClassList("fade-out");
    }
    public static void FadeOut(this VisualElement v)
    {
        v.AddToClassList("fade-out");
        v.RemoveFromClassList("fade-in");
    }
}