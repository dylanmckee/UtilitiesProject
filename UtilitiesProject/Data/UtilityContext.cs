﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UtilitiesProject.Models;

namespace UtilitiesProject.Data
{
    public class UtilityContext : DbContext
    {
        public UtilityContext(DbContextOptions options ): base(options)
        {
        }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public Utility findByName(string name)
        {
            foreach (Utility utility in Utilities) 
            {
                if (utility.Name == name)
                    return utility;
            }
            return null;
        }
        public string findUtilityNameById(Guid id)
        {

            foreach (Utility utility in Utilities)
            {
                if (utility.Id.Equals(id) || utility.Id == id)
                {
                    Console.WriteLine(utility.Id + "\n" + id);
                    return utility.Name;
                }
            }
            return "Not found";
        }
        public Bill findBillById(Guid id)
        {
            foreach (Bill bill in Bills)
            {
                if (!bill.Id.Equals(id))
                {
                    return bill;
                }
            }
            return null;
        }
    }
}
