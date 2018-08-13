using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataTemplateDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DataTemplateDemo.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Init();
        }

        public int CurrentIndex { get; set; }
        public int MaxItems { get; set; }
        public ObservableCollection<Sheet> Sheets { get; set; }

        public ICommand SwipeLeftCmd { get; set; }
        public ICommand SwipeRightCmd { get; set; }

        private void Init()
        {
            MaxItems = 5;
            CurrentIndex = 0;
            Sheets = new ObservableCollection<Sheet>();
            SwipeLeftCmd = new Command(ExecuteSwipeLeft);
            SwipeRightCmd = new Command(ExecuteSwipeRight);
            InitPage();
        }

        private void InitPage()
        {
            for (int i = 0; i < MaxItems; i++)
            {
                Sheets.Add(new Sheet());
                if (i == 0 && Sheets[i] != null)
                    Sheets[i].IsCurrent = true;
            }
        }


        private void ExecuteSwipeRight(object obj)
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
                SetPage(CurrentIndex);
            }
        }

        private void ExecuteSwipeLeft(object obj)
        {
            if (CurrentIndex < MaxItems - 1)
            {
                CurrentIndex++;
                SetPage(CurrentIndex);
            }
        }

        private void SetPage(int currentIndex)
        {
            Sheets.ForEach(x=>x.IsCurrent = false);
            Sheets[currentIndex].IsCurrent = true;
        }
    }
}