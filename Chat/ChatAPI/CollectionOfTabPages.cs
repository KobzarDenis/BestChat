using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public class CollectionOfTabPages
    {
        #region Singleton
        private static CollectionOfTabPages unique;

        public static CollectionOfTabPages GetInstance()
        {
            return unique ?? (unique = new CollectionOfTabPages());
        }

        #endregion

        List<TabPage> collectionPages;

        private CollectionOfTabPages()
        {
            collectionPages = new List<TabPage>();
        }

        public void AddNewPage(TabPage page)
        {
            collectionPages.Add(page);
        }

        public void DeletePage(string name)
        {
            collectionPages.Remove(collectionPages.FirstOrDefault(p => p.Name == name));
        }

        public List<TabPage> GetMyDialogs()
        {
            return collectionPages;
        }
    }
}
