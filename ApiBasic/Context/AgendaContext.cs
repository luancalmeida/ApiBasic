using ApiBasic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBasic.Migrations;

namespace ApiBasic.Context
{
    public class AgendaContext : DbContext
    {
        //constu. para passar a conexão
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        //prop, referindo a entidade contato - class no progr. e tabela no sql
        public DbSet<Contato> Contatos { get; set; }    



    }
}
