﻿using System;
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
        IDictionary<EnumJob, string> DialogueJob();

        /// <summary>
        /// Dialogues the quest.
        /// </summary>
        /// <returns></returns>
        IDictionary<int, string> DialogueQuest();
    }
}
