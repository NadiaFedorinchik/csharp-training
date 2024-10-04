using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : Helperbase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupsDialog();
            int count = GetGroupsCount();

            for (int i = 0; i < count; i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#" + i, "");

                groups.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialog();
            return groups;
        }

        public void CreateNewGroupIfNotEnoughPresent()
        {
            OpenGroupsDialog();
            int count = GetGroupsCount();
            while (count < 2)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "test",
                };

                Add(newGroup);
                count++;
            }
        }

        public int GetGroupsCount()
        {
            OpenGroupsDialog();
            string groupsCount = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            CloseGroupsDialog();
            return int.Parse(groupsCount);
        }

        public void Remove(int index)
        {
            OpenGroupsDialog();
            aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#" + index, "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEGROUPWINTITLE);
            aux.WinActivate(DELETEGROUPWINTITLE);
            aux.WinWaitActive(DELETEGROUPWINTITLE);
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialog();
        }
    }
}