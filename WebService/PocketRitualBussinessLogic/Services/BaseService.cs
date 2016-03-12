using PocketRitual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketRitualBussinessLogic.Services
{
    public abstract class BaseService
    {
        protected IPocketRitualDbContext Context { get; }
        protected BaseService(IPocketRitualDbContext context)
        {
            this.Context = context;
        }

    }
}
