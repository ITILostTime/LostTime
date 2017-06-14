using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using SimpleJSON;

namespace Assets.Scripts.Quest
{
    public class DialogueCollection : IDialogueCollection
    {
        /// <summary>
        /// Dialogues the quest.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        IDictionary<int, string> IDialogueCollection.DialogueQuest()
        {
            /*using (StreamReader reader = File.OpenText(@"..\..\QuestSystemTests\JsonParser\DialogueQuest.json"))
            {
                
            }*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dialogues the standard.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        IDictionary<EnumJob, string> IDialogueCollection.DialogueJob()
        {
            throw new NotImplementedException();
        }
    }
}
