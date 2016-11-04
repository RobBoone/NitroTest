using UnityEngine;
using System.Collections;


public class Enhancements : Item {

    public ItemType TypeOfItem = ItemType.Enhancements;
    enum EnhancementType
    {
        Def,
        Att,
        hp
    };

    private EnhancementType TypeOfEnhancement;

    Enhancements()
    {
        TypeOfItem = ItemType.Enhancements;
    }
}
