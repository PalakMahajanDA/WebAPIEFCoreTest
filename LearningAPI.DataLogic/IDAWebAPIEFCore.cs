using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAPI.DataLogic
{
    public interface IDAWebAPIEFCore<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        int Add(TEntity b);
        int Update(U id, TEntity b);
        int Delete(U id);
        int UpdateLeaveDate(U id,DateTime b);
        int UpdateSalary(U id, decimal b);
        TEntity GetEmployeesbyName(string Name);
    }
}
