using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using jegyzetek.Database;
using jegyzetek.Models;
using jegyzetek.Views;

namespace jegyzetek.ViewModels
{
    [QueryProperty(nameof(SelectedId), "SelectedId")]
    public partial class FormViewModel : ObservableObject
    {
        [ObservableProperty]
        public Note aktNote = new Note();
        [ObservableProperty]
        public List<string> categorys = new() { "Munka", "Szabadidő", "Pénzügy", "Emlékeztető", "Találkozó" };
        [ObservableProperty]
        public int selectedId;

        partial void OnSelectedIdChanged(int value)
        {
            if (SelectedId != 0)
            {
                AktNote = NoteDatabase.GetNoteAsync(SelectedId);
            }
        }

        [RelayCommand]
        public async Task ButtonPressed()
        {
            if (CheckForm() && AktNote != null)
            {
                AktNote.Date = DateTime.Now;
                await Task.Run(() =>
                {
                    NoteDatabase.SaveNoteAsync(AktNote);
                    AktNote = new Note();
                    SelectedId = 0;
                });
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
            }
        }

        private bool CheckForm()
        {
            if (AktNote is not null)
            {
                if (String.IsNullOrWhiteSpace(AktNote.Title))
                {
                    Shell.Current.DisplayAlert("Hiba!", "Adjon a bejegyzésnek címet", "Ok");
                    return false;
                }
                if (String.IsNullOrWhiteSpace(AktNote.Text))
                {
                    Shell.Current.DisplayAlert("Hiba!", "A jegyzet szövege nem lehet üres", "Ok");
                    return false;
                }
                if (AktNote.Category == "" || AktNote.Category == null)
                {
                    AktNote.Category = "Kategorizálatlan";
                    return true;
                }
                return true;
            }
            return false;
        }
    }
}
