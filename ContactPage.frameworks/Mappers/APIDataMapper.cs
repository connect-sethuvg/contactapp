using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Mappers
{
    public abstract class APIDataMapper<TEntity, TObject> where TEntity : IEntity where TObject : class, new()
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected APIDataMapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public abstract TObject ToObject(TEntity entity);
        public abstract TEntity ToEntity(TObject value);

        protected TEntity? createEntity()
        {
            TEntity? entity = (TEntity?)serviceProvider.GetService(typeof(TEntity));
            return entity;
        }

        public IEnumerable<TObject> ToObjects(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                yield return ToObject(entity);
            }

        }
        public IEnumerable<TEntity> ToEntities(IEnumerable<TObject> values)
        {
            foreach (TObject value in values)
            {
                yield return ToEntity(value);
            }



        }
    }
}