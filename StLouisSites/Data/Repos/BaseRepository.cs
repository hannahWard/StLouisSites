﻿using Microsoft.EntityFrameworkCore;
using StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Data.Repos
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IModel
    {

        protected ApplicationDbContext context;
        protected DbSet<TEntity> models;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.models = context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var model = this.GetById(id);
            context.Remove(model);
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return models.SingleOrDefault(m => m.Id == id);
        }

        public List<TEntity> GetModels()
        {
            return models.ToList();
        }

        public int Save(TEntity model)
        {
            context.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public void Update(TEntity model)
        {
            context.Update(model);
            context.SaveChanges();
        }
    }
}
