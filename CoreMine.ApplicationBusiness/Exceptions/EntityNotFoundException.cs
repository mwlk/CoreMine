using CoreMine.ApplicationBusiness.Exceptions.Enums;

namespace CoreMine.ApplicationBusiness.Exceptions
{
    public partial class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException(int id, EntityNotFoundType type) : base(GenenateMessage(id, type))
        {

        }

        private static string GenenateMessage(int id, EntityNotFoundType type)
        {
            return type switch
            {
                EntityNotFoundType.Product => $"El producto con código: {id} no fue encontrado",
                EntityNotFoundType.Location => $"La Ubicación con código: {id} no fue encontrada",
                _ => $"La entidad con código: {id} no fue encontrada"
            };
        }
    }
}
