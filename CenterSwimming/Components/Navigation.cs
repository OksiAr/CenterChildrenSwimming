using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CenterSwimming.Components
{
    internal class Navigation
    {
        private static List<PageComponent> components = new List<PageComponent>();
        public static MainWindow mainWindow;
        public static void ClearHistory()
        {
            components.Clear();
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);

        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }
        private static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTb.Text = pageComponent.Title;
            mainWindow.BackBtn.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.ExitBtn.Visibility = App.AuthUser != null ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }


    }
    class PageComponent
    {
        public string Title { get; set; }
        public Page Page { get; set; }

        public PageComponent(string title, Page page)
        {
            Page = page;
            Title = title;
        }
    }
}

