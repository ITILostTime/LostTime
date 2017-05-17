using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    class QuestController
    {
        int _questId;
        string _questName;
        string _questDescription;
        int _questSteps; //a préciser entre une classe elle même, un string ou un int comme ici

        ObjectLibrary _objectLibrary; //appel de la classe objectLibrary qui contient les objets de la quête sous forme de liste 

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
