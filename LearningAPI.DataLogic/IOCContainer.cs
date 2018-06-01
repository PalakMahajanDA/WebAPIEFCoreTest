using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LearningAPI.Models;

namespace WebAPIEFCore.Models
{

    public class IOCContainer
    {
        private static string _type;

        public IOCContainer(string type)
        {
            _type = type;
        }
        public static IEmployeeContext GetReqDBContext()
        {
            string type = _type;
            Resolver resolver = new Resolver();
            resolver.Register<GetDBContext, GetDBContext>();
            if (type == "memory")
            {
                resolver.Register<IEmployeeContext, InMemoryContext>();
                var employeecontext = resolver.Resolve<InMemoryContext>();
                return employeecontext;
            }
            else
            {
                resolver.Register<IEmployeeContext, EmployeeContext>();
                var employeecontext = resolver.Resolve<EmployeeContext>();
                return employeecontext;
            }
        }
    }
    public class Resolver
    {
        private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public void Register<TFrom, TTo>()
        {
            dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

        private object Resolve(Type typetoresolve)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = dependencyMap[typetoresolve];
            }
            catch

            {
                throw new Exception(string.Format("could not resove type"));
            }
            var firstcontructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstcontructor.GetParameters();
            if (constructorParameters.Count() == 0)
                return Activator.CreateInstance(resolvedType);
            IList<object> parameters = new List<object>();
            foreach (var parameterToresolve in constructorParameters)
            {
                parameters.Add(Resolve(parameterToresolve.ParameterType));
            }
            return firstcontructor.Invoke(parameters.ToArray());

        }
    }
    public class InMemoryContext : DbContext, IEmployeeContext
    {
        public InMemoryContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Employees> Employees { get; set; }
    }

    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<LearningAPI.Models.Employees> Employees { get; set; }
    }


    public class GetDBContext : DbContext
    {
        private readonly IEmployeeContext employeeContext;

        public GetDBContext(IEmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
  


    }



}



