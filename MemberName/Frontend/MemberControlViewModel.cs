using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MemberName.Service;
using Word= Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace MemberName.Frontend
{
    public class MemberControlViewModel : ViewModelBase
    {       
        private string memberSearchText;
        private List<MemberNameBO> members;
        private MemberNameBO selectedMember;
        private ContributionType selectedContributionType;
        private RelayCommand<string> loadMemberCommand;
        private RelayCommand<Window> insertMemberCommand;
        private RelayCommand windowLoadedCommand;
        private GetMembers getMembers;
        private bool isOpened;
        private SynchronizationContext context;
        public List<MemberNameBO> Members
        {
            get => members;
            set => Set(ref members, value);
        }
        public MemberNameBO SelectedMember
        {
            get => selectedMember;
            set
            {
                Set(ref selectedMember, value);
                SelectedContributionType = IsPreviousQuestion() ? ContributionType.Answer : ContributionType.Question;
            }
        }

        public ContributionType SelectedContributionType
        {
            get => selectedContributionType;
            set => Set(ref selectedContributionType, value);
        }

        public string MemberSearchText
        {
            get => memberSearchText;
            set
            {
                if (memberSearchText != value && SelectedMember?.MemberName != value && value.Length > 0)
                {
                    Set(ref memberSearchText, value);
                    LoadMemberCommand.Execute(memberSearchText);
                }               
            }
        }
        public bool IsOpened
        {
            get => isOpened;
            set => Set(ref isOpened, value);
        }

        public RelayCommand<string> LoadMemberCommand => loadMemberCommand
                  ?? (loadMemberCommand = new RelayCommand<string>(
                    async (searchText) =>
                    {
                        await LoadMember(searchText);
                    }));

        public RelayCommand<Window> InsertMemberCommand => insertMemberCommand
                 ?? (insertMemberCommand = new RelayCommand<Window>(
                   async (window) =>
                   {
                       await InsertMember(window);
                   }));

        public RelayCommand WindowLoadedCommand => windowLoadedCommand
                ?? (windowLoadedCommand = new RelayCommand(
                  () =>
                  {
                      context = SynchronizationContext.Current ?? new SynchronizationContext();
                      SetDefaults();
                  }));

        private void SetDefaults()
        {
            var document = Globals.ThisDocument;
            var bookmarks = document.Application.Selection.Bookmarks;
            if (bookmarks.Count > 0)
            {
                var ccs = bookmarks[1].Range.ContentControls;
                if (ccs.Count > 0)
                {
                    var memberId = int.Parse(ccs[1].Tag);
                    SelectMember(memberId);
                    SelectedContributionType = (ContributionType)Enum.Parse(typeof(ContributionType), ccs[1].Title);
                }
            }
        }

        private Task InsertMember(Window window)
        {
            return Task.Factory.StartNew(() =>
            {
                var document = Globals.ThisDocument;
                var name = Guid.NewGuid().ToString();
               
                var contentControl = document.Controls.AddRichTextContentControl(document.Application.Selection.Range, name);
                
                contentControl.Text = HasMember() ? 
                $"{SelectedMember.MemberName}: " : 
                $"{SelectedMember.MemberName} ({SelectedMember.Constituency}) ({SelectedMember.Party}): ";
                contentControl.Title = SelectedContributionType.ToString();
                contentControl.Tag = SelectedMember.MemberId.ToString();
                
                var range = contentControl.Range;
                range.Select();
                document.Application.Selection.MoveEnd(Word.WdUnits.wdCharacter, 1 );
                var bookmark = document.Bookmarks.Add($"BK_{name.Replace('-', '_')}", document.Application.Selection.Range);
                range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                document.Application.Selection.MoveRight(Word.WdUnits.wdCharacter, 2);
                context.Post(x => window.Close(), null);
                //store in cache
            });
        }

        private bool HasMember()
        {
            foreach (Word.ContentControl contentControl in Globals.ThisDocument.ContentControls)
            {
                if (contentControl.Tag == SelectedMember.MemberId.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPreviousQuestion()
        {           
            if (Globals.ThisDocument.Bookmarks.Count > 0)
            {
                var lastBookmarkRange = Globals.ThisDocument.Bookmarks[Globals.ThisDocument.Bookmarks.Count].Range;
                //lastBookmarkRange.Select();
                if (lastBookmarkRange.ContentControls.Count > 0)
                {
                    if (lastBookmarkRange.ContentControls[1].Title == ContributionType.Question.ToString())
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public MemberControlViewModel()
        {            
            this.getMembers = new GetMembers();
        }
        private Task LoadMember(string searchText)
        {
            return Task.Factory.StartNew(() =>
            {
                var allMembers = getMembers.GetMembersAsync();
                Members = allMembers.Where(s => s.MemberName.ToLower().Contains(searchText.ToLower())).ToList();
                Members.AddRange(allMembers.Where(s => s.Constituency.ToLower().Contains(searchText.ToLower())).ToList());
                IsOpened = Members.Any();
            }); 
        }

        private void SelectMember(int memberId)
        {
            Members = getMembers.GetMembersAsync();
            SelectedMember = Members.Where(s => s.MemberId == memberId).FirstOrDefault();
        }
    }
}
