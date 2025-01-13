using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.BL.Implementation.Interfaces
{
    public interface IAccountService
    {
        Task Register();
        Task Login();
        Task Logout();
    }
}
