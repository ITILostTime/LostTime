using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Interfaces
{
    public interface IDialogueCollection
    {
        /// <summary>
        /// Dialogues the standard.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> DialogueStandard();

        /// <summary>
        /// Dialogues the quest.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> DialogueQuest();
    }
}
