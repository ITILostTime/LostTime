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
        Dictionary<EnumJob, string> DialogueJob();

        /// <summary>
        /// Dialogues the quest.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> DialogueQuest();
    }
}
