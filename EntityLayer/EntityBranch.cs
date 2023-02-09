using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBranch
    {
        private int branchID;
        private string branchName;

        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
    }
}
