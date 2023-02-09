using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicBranch
    {
        public static List<EntityBranch> LLBranchListesi()
        {
            return DALBranch.BranchListesi();
        }
        public static List<EntityDoctor> LLIlgiliBranchDoctorListele(EntityBranch p)
        {
            return DALBranch.IlgiliBranchDoctorListele(p);
        }
        public static EntityBranch LLIlgiliBranchAdiGetir(int p)
        {
            return DALBranch.IlgiliBranchAdiGetir(p);
        }
    }
}
