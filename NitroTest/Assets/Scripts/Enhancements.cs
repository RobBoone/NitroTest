using UnityEngine;
using System.Collections;


public class Enhancements : Item {

	enum EnhancementType
    {
        Def,
        Att,
        hp
    };

    private EnhancementType TypeOfEnhancement;
}
