﻿namespace DigitalArs_copia.DataAccess.Repositories.Interfaces
{
        public interface IRepository<T> where T : class
        {
            public Task<List<T>> GetAll();

            public Task<T> GetById(int id);

            public Task<bool> Insert(T entity);

        
    }
}
