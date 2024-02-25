using Amit_CricketTeamBAL.ViewModel;
using Amit_CricketTeamDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamBAL.Interfaces
{
    public interface ICricketTeamServices
    {
        Task<int> CriketTeamRegistration(CriketTeamRegistrationVM entity);
        Task<int> TeamLogin(TeamLoginVM entity);
        Task<IEnumerable<CricketTeamMaster>> CriketTeamList();

    }
}
