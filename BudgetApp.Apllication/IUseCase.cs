using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Apllication
{
    public interface IUseCase<TRequest, TResponse>
    {
        public Task<TResponse> ExecuteAsync(TRequest request);
    }
}
