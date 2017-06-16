using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using SimpleJSON;
using System.Collections;

namespace Assets.Scripts.Quest
{
    public class DialogueCollection : IDialogueCollection
    {
        public Dictionary<EnumJob, string> DialogueJob()
        {
            return new Dictionary<EnumJob, string>();
        }

        public Dictionary<int, string> DialogueQuest()
        {
            return new Dictionary<int, string>();
        }
    }
}
