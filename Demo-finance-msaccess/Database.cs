using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

/**
 * Creating Database ORM with sql lite
 * src: https://softchris.github.io/pages/dotnet-orm.html#create-an-order
 */
namespace App
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<Agent> Agents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }

    public class Agent
    {
        public int AgentId { get; set; }
        public string Name { get; set; }

        /**
         * We are expressing a 1-Many relationship by the following construct on the Agent class
         * This is because Agent is able to cater to many Clients
         */
        public ICollection<Client> Clients { get; set; }
    }

    public class Collection
    {
        public int CollectionId { get; set; }
        public int Quantity { get; set; }

        public DateTime? Created { get; set; }

        /**
         * We are also expressing another database concept namely Foreign key. 
         * In the Collection entity we are saying that we have a reference to a Client
         */
        public virtual Client Client { get; set; }
    }

    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContractNumber { get; set; }

        /**
         * We are expressing a 1-Many relationship by the following construct on the Client class
         */
        public ICollection<Collection> Collections { get; set; }


        /**
         * We are also expressing another database concept namely Foreign key. 
         * In the Client entity we are saying that we have a reference to a Agent.
         * This is because every Client is assigned with 1 Agent
         */
        public virtual Agent Agent { get; set; }
    }
}
/**
 * run "dotnet ef migrations add InitialCreate" on terminal to create migration
 * created migration will generate tables for us from this class
 * then run "dotnet ef database update" to apply migration
 */