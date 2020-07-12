using System.Collections.Generic;
using System.Dynamic;
using AutoMapper;

namespace Core.Helpers
{
    public static class EntityHelpers
    {
        /// <summary>
        /// Return an entity of type T, without using a constructor.
        /// Simple casting doesn't work because the types don't overlap.
        /// 
        /// We are creating an anonymous mapper here because we don't
        /// need any profiles. This way we don't need to have DI or pass
        /// the mapper from the extending repositories.
        /// </summary>
        public static T CreateEntityWithId<T>(long id)
        {
            // Creating an anonymous, dynamic object didn't work.  It has to be Expando.
            dynamic dynamicEntity = new ExpandoObject();
            (dynamicEntity as IDictionary<string, object>).Add("Id", id);
            
            // Empty mapper, since this mapping is dynamic.
            var mapper = new MapperConfiguration(cfg => { }).CreateMapper();
            
            return mapper.Map<T>(dynamicEntity);
        }
    }
}