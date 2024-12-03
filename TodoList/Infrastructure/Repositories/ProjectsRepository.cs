using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly DataContext _context;

        public ProjectsRepository(DataContext context)
        {
            _context = context;
        }

        public Project CreateProduct(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return project;
        }
    }
}
