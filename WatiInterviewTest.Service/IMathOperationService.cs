using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiInterviewTest.Model;

namespace WatiInterviewTest.Service
{
    public interface IMathOperationService
    {
        Task<int> AddAsync(Sum request);
    }
}
