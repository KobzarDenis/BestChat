using System.Collections.Generic;
using System.Linq;

namespace Chat
{
    public class CollectionOfDialogsView
    {
        #region Singleton
        private static CollectionOfDialogsView unique;

        public static CollectionOfDialogsView GetInstance()
        {
            return unique ?? (unique = new CollectionOfDialogsView());
        }

        #endregion

        List<DialogView> collections;

        private CollectionOfDialogsView()
        {
            collections = new List<DialogView>();
        }

        public void AddDialogView(string key, DialogView dialogView)
        {
            dialogView.Key = key;
            collections.Add(dialogView);
        }

        public DialogView GetSelectedDialogView(string key)
        {
            return collections.FirstOrDefault(d => d.Key == key);
        }

        public void DeleteDialog(string key)
        {
            collections.Remove(collections.FirstOrDefault(d => d.Key == key));
        }

        public void GetMessage(string loginSender, string message, string key)
        {
            foreach (DialogView dialogView in collections)
            {
                if(dialogView.Key == key)
                {
                    dialogView.SetMessage(loginSender, message);
                }
            }
        }

        public bool FindDialog(string dialogName)
        {
            foreach(DialogView d in collections)
            {
                if (d.Key == dialogName)
                    return true;
            }
            return false;
        }
    }
}
