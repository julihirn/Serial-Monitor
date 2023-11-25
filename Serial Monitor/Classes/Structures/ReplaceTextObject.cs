using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    public class ReplaceTextObject {
        private string output = "";
        public string Output {
            get { return output; }
            set { output = value; }
        }
        private string input = "";
        public string Input {
            get { return input; }
            set { input = value; }
        }
        private string textToReplace = "";
        public string TextToReplace {
            get { return textToReplace; }
            set { textToReplace = value; }
        }
        private string replaceWith = "";
        public string ReplaceWith {
            get { return replaceWith; }
            set { replaceWith = value; }
        }
        private bool isValid = false;
        public bool IsValid {
            get { return isValid; }
            set { isValid = value; }
        }
    }
}
