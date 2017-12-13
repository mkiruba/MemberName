using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MemberName.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberName.Frontend
{
    public class MemberControlViewModel : ViewModelBase
    {
        private string memberSearchText;
        private List<MemberNameBO> members;
        private RelayCommand<string> loadMemberCommand;
        private RelayCommand<MemberNameBO> insertMemberCommand;
        private GetMembers getMembers;
        private bool isOpened;
        public List<MemberNameBO> Members
        {
            get => members;
            set => Set(ref members, value);
        }
        public string MemberSearchText
        {
            get => memberSearchText;
            set
            {
                Set(ref memberSearchText, value);
                LoadMemberCommand.Execute(memberSearchText);
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

        public RelayCommand<MemberNameBO> InsertMemberCommand => insertMemberCommand
                 ?? (insertMemberCommand = new RelayCommand<MemberNameBO>(
                   async (member) =>
                   {
                       await InsertMember(member);
                   }));

        private Task InsertMember(MemberNameBO member)
        {
            return Task.Factory.StartNew(() =>
            {
                Globals.ThisDocument.Application.Selection.Text = member.MemberName;
                //store in cache
            });
        }

        //public MemberControlViewModel(GetMembers getMembers)
        //{
        //    this.getMembers = getMembers;
        //}

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
                IsOpened = Members.Any();
            }); 
        }
    }
}
