using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine_Core.Core
{
    public static class Debug
    {
        private static ListBox listbox;

        private static string fileLocation;


        /// <summary>
        /// Initialize the Debug class with the ListBox that will be used to show debugging info. As well as the file location to the log file. Full path is required.
        /// </summary>
        /// <param name="_listBox"></param>
        /// <param name="_fileLocation"></param>
        public static void Init(ListBox _listBox, string _fileLocation = null)
        {
            listbox = _listBox;
            fileLocation = _fileLocation;
        }

        /// <summary>
        /// Shows a string to the Debugging Listbox
        /// </summary>
        /// <param name="_message"></param>
        public static void Log(string _message)
        {
            if (listbox != null)
            {
                listbox.Items.Add(_message);
            }
        }

        /// <summary>
        /// Clears the ListBox used to show debugging info.
        /// </summary>
        public static void Clear()
        {
            if (listbox != null)
            {
                listbox.Items.Clear();
            }
        }

        /// <summary>
        /// Logs a string to a file. 
        /// </summary>
        /// <param name="_message"></param>
        public static void LogToFile(string _message)
        {
            if (fileLocation != null)
            {
                File.AppendAllText(fileLocation, _message);
            }
        }
    }
}
