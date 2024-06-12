using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using jegyzetek.Database;
using jegyzetek.Models;
using jegyzetek.Views;

namespace jegyzetek.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Note> notes = new();

        [RelayCommand]
        async Task Delete(Note SelectedNote)
        {
            if (SelectedNote != null)
            {
                await NoteDatabase.DeleteNoteAsync(SelectedNote);
                Notes.Remove(SelectedNote);
            }
            SelectedNote = null;
        }

        [RelayCommand]
        async Task Edit(Note SelectedNote)
        {
            if (SelectedNote != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(FormPage)}?SelectedId={SelectedNote.Id}", true);
            }
        }

        [RelayCommand]
        void Appearing()
        {
            Task.Run(() =>
            {
                Notes = NoteDatabase.GetAllNotesAsync();
            });
        }
    }
}
