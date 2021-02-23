using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App; //import class from Database.cs
using Microsoft.EntityFrameworkCore; //call this to call ExecuteSqlRaw method

namespace Demo_finance_msaccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using var db = new DatabaseContext();
            /**
             * use this code to execute raw sql comman
             * db.Database.ExecuteSqlRaw("delete from Clients");
             */

            /**
            * Let's add our first data to the clients table
            * Note: If an error occurs on not able to find the table do the following:
            * - In Solution Explorer, right click the project and then select Properties.
            * - Select the Debug tab in the left pane.
            * - Set Working directory to the project directory.
            * - Save the changes.
            */
            var agent = new Agent() { Name = "Agentx44" };
            db.Agents.Add(agent);
            db.SaveChanges();

            var newAgent = db.Agents.FirstOrDefault();
            var client = new Client() { Name = "Xsert Emina", Address = "P16, Poblacion, Valencia City", ContractNumber = "1412", Agent = newAgent };
            db.Clients.Add(client);
            db.SaveChanges();

            /**
             * let's add columns to our data grid view
             */
            string[] columns = new string[] { "Client ID", "Name", "Address", "Contract No.", "Agent ID", "Agent Name" };
            dgvDataTable.ColumnCount = columns.Length;
            for (var i = 0; i < columns.Length; i++)
            {
                dgvDataTable.Columns[i].HeaderText = columns[i];
                dgvDataTable.Columns[i].Name = columns[i];
            }

            /**
            * let's query our clients
            * console log the rows
            * then let's add them to our data grid view
            */
            foreach (var p in db.Clients)
            {
                dgvDataTable.Rows.Add(new object[] {
                    p.ClientId,
                    p.Name,
                    p.Address,
                    p.ContractNumber,
                    p.Agent.AgentId,
                    p.Agent.Name
                });
            }
        }
    }
}
