namespace dreamCare.ApiService.Models
{
    public class ModelExtensions
    {
        public enum UserPermission
        {
            Read,
            Write,
            Read_And_Write
        }


        public enum UserGenderIdentity
        {
            Male,
            Female,
            Non_Binary,
            Prefer_Not_To_Say
        }


        public enum RoleLevel
        {
            Associate,
            Senior,
            Admin
        }

    }
}
