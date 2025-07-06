using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystemApp.Interfaces
{
    public interface ISearchable
    {
        bool MatchesId(int id);
        bool MatchesModel(string model);
        bool MatchesStatus(string status);
    }
}
