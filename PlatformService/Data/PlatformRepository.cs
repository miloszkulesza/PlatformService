﻿using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException(nameof(platform));

            _context.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
