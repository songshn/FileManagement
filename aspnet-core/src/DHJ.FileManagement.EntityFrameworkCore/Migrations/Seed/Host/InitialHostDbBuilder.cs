﻿using DHJ.FileManagement.EntityFrameworkCore;

namespace DHJ.FileManagement.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly FileManagementDbContext _context;

        public InitialHostDbBuilder(FileManagementDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
