using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public interface IEntityRepo<TEntity>
        where TEntity : BaseEntity {
        IList<TEntity> GetAll();
        TEntity? GetById(int id);
        void Create(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
    }
}

