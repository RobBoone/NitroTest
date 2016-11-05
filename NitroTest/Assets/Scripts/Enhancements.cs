using UnityEngine;
using System.Collections;


public class Enhancements : Item {

    public ItemType TypeOfItem = ItemType.Enhancements;
    public enum EnhancementType
    {
        Def,
        Att,
        hp
    };

    public EnhancementType TypeOfEnhancement;

    public Enhancements(EnhancementType typeOfEnhancement)
    {
        TypeOfItem = ItemType.Enhancements;
        TypeOfEnhancement = typeOfEnhancement;
    }
}
