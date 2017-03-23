using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSS.ConnectionAPI;

namespace WSS.DialogsAPI
{
    public class ListOfDialogs
    {
        private static List<Dialog> listDialogs = new List<Dialog>();

        public static void AddDialogToList(string nameDialog, Client client)
        {
            Dialog d = new Dialog();
            d.NameDialog = nameDialog;
            d.dialog.Add(client);
            listDialogs.Add(d);
        }

        public static void DeleteDialog(string nameDialog)
        {
            listDialogs.Remove(listDialogs.FirstOrDefault(d =>d.NameDialog == nameDialog));
        }

        public static void ExitDialog(string login, string nameDialog)
        {
            listDialogs.FirstOrDefault(d => d.NameDialog == nameDialog).DeleteInDialog(login);
        }

        public static void ToComeIn(string login, string nameDialog)
        {
            listDialogs.FirstOrDefault(d => d.NameDialog == nameDialog).AddToDialog(login);
        }

        public static List<Dialog> GetListDialogs()
        {
            return listDialogs;
        }

    }
}
