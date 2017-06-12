using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class Dialogue : IDialogueCollection
    {
        /// <summary>
        /// Dialogues the quest.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        IDictionary<string, string> IDialogueCollection.DialogueQuest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dialogues the standard.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        IDictionary<string, string> IDialogueCollection.DialogueStandard()
        {
            throw new NotImplementedException();
        }
    }
}
