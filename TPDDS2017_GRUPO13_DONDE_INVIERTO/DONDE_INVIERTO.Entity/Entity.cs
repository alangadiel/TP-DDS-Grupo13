using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Entity
{
    public class Entity<TEntity>
        where TEntity: Model.Model
    {
        private List<TEntity> entities;

        public Entity()
        {

        }

        public void Initialize()
        {
            this.entities = new List<TEntity>();
        }

        public int Save(TEntity entity)
        {
            if(entity.Id == 0)
            {
                entity.Id = GetNextId();
            }
            else
            {
                Delete(entity.Id);
            }
            this.entities.Add(entity);

            return entity.Id;
        }

        public void Delete(int Id)
        {
            this.entities.RemoveAll(x => x.Id == Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.entities.OrderBy(x => x.Id);
        }

        public TEntity Get(int Id)
        {
            return this.entities.Find(x => x.Id == Id);
        }

        private int GetNextId()
        {
            if (this.entities.Count == 0)
                return 1;
            return this.entities.OrderBy(x => x.Id).Last().Id + 1;
        }

        
        
        


       

    }
}
